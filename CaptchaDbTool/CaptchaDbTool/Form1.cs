using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Windows.Forms;
using CaptchaDbTool.Models;
using Crc32C;
using LiteDB;

namespace CaptchaDbTool
{
    public partial class Form1 : Form
    {
        private MemoryStream currentMemoryStream;
        private readonly LiteDatabase liteDatabase;
        private readonly LiteCollection<ImageItem> liteCollection;
        private ImageItem imageItem;

        public Form1()
        {
            InitializeComponent();
            liteDatabase = new LiteDatabase("ImageDatabase.ldb");
            liteCollection = liteDatabase.GetCollection<ImageItem>();
            liteCollection.EnsureIndex(x => x.Id);

            imageItem = new ImageItem()
            {
                Tags = new List<string>()
            };

            LoadStatistic();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            cbxTag.Items.Clear();
            foreach (var item in liteCollection.FindAll().ToList())
            {
                cbxTag.Items.AddRange(item.Tags.ToArray());
            }

            if (currentMemoryStream != null && currentMemoryStream.CanRead)
            {
                currentMemoryStream.Dispose();
            }

            liTags.Items.Clear();
            imageItem = new ImageItem()
            {
                Tags = new List<string>()
            };

            lblHash.Text = "Loading";
            Application.DoEvents();

            WebClient client = new WebClient();
            var data = client.DownloadData(
                "https://source.unsplash.com/random/256x256");

            lblHash.Text = "Loading..";
            Application.DoEvents();

            var hash = Crc32CAlgorithm.Compute(data).ToString();

            lblHash.Text = "Loading....";
            Application.DoEvents();

            currentMemoryStream = new MemoryStream(data);

            pictureBox1.Image = Image.FromStream(currentMemoryStream);
            lblHash.Text = hash;
            imageItem.Id = hash;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            liteDatabase.Dispose();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (liteCollection.FindOne(x => x.Id == imageItem.Id) != null)
            {
                MessageBox.Show("Already exist");
                return;
            }

            imageItem.Tags = liTags.Items.Cast<string>().ToList();
            liteCollection.Insert(imageItem);

            currentMemoryStream.Position = 0;
            liteDatabase.FileStorage.Upload(imageItem.Id,
                imageItem.Id, currentMemoryStream);

            btnNext_Click(sender, e);
            LoadStatistic();
        }

        private void btnReload_Click(object sender, EventArgs e)
        {
            var collection = liteDatabase.GetCollection<ImageItem>();
            liImageItems.Items.Clear();

            foreach (var item in collection.FindAll())
            {
                liImageItems.Items.Add(item.Id);
            }
        }

        private void liImageItems_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (liImageItems.SelectedItem is string selected)
            {
                var item = liteCollection.Find(x =>
                    x.Id == selected).FirstOrDefault();
                if (item != null)
                {
                    lblImageItemName.Text = item.Id;
                    liTagsOfItem.Items.Clear();
                    txbTagEdit.Text = "";

                    using (var ms = new MemoryStream())
                    {
                        liteDatabase.FileStorage.Download(item.Id, ms);
                        pictureBox2.Image = Image.FromStream(ms);

                        foreach (var itemTag in item.Tags)
                        {
                            liTagsOfItem.Items.Add(itemTag);
                        }
                    }
                }
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (liTags.SelectedItem != null)
            {
                liTags.Items.Remove(liTags.SelectedItem);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            liTags.Items.Add(cbxTag.Text.ToLower());
            cbxTag.Text = "";
        }

        private void btnRemoveItem_Click(object sender, EventArgs e)
        {
            if (liImageItems.SelectedItem != null)
            {
                if (liImageItems.SelectedItem != null)
                {
                    liteCollection.Delete(x =>
                        x.Id == liImageItems.SelectedItem as string);
                }

                liImageItems.Items.Remove(liImageItems.SelectedItem);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (txbTagEdit.Tag != null)
            {
                var value = txbTagEdit.Text;
                liTagsOfItem.Items.Remove(txbTagEdit.Tag);
                liTagsOfItem.Items.Add(value);

                txbTagEdit.Text = "";
                txbTagEdit.Tag = null;

                var item =
                    liteCollection.Find(x =>
                        x.Id == liImageItems.SelectedItem as string).FirstOrDefault();

                if (item != null)
                {
                    item.Tags = liTagsOfItem.Items.Cast<string>().ToList();
                    liteCollection.Update(item);
                }
            }
        }

        private void liTagsOfItem_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (liTagsOfItem.SelectedItem != null)
            {
                txbTagEdit.Text = (string)liTagsOfItem.SelectedItem;
                txbTagEdit.Tag = liTagsOfItem.SelectedItem;
            }
        }

        private void btnTagAdd_Click(object sender, EventArgs e)
        {
            liTagsOfItem.Items.Add(txbTagEdit.Text);

            txbTagEdit.Text = "";
            txbTagEdit.Tag = null;

            var item =
                liteCollection.Find(x =>
                    x.Id == liImageItems.SelectedItem as string).FirstOrDefault();

            if (item != null)
            {
                item.Tags = liTagsOfItem.Items.Cast<string>().ToList();
                liteCollection.Update(item);
            }
        }

        private void btnTagRemove_Click(object sender, EventArgs e)
        {
            if (txbTagEdit.Tag != null)
            {
                liTagsOfItem.Items.Remove(txbTagEdit.Tag);
                txbTagEdit.Text = "";
                txbTagEdit.Tag = null;

                var item =
                    liteCollection.Find(x =>
                        x.Id == liImageItems.SelectedItem as string).FirstOrDefault();

                if (item != null)
                {
                    item.Tags = liTagsOfItem.Items.Cast<string>().ToList();
                    liteCollection.Update(item);
                }
            }
        }

        private void LoadStatistic()
        {
            lvStatistic.Items.Clear();
            ListViewItem li;
            var items = liteCollection.FindAll().ToList();

            var ii = items.Where(x => x.Tags.Contains(null));

            foreach (var item in ii)
            {
                if (item.Tags.Contains(null))
                {
                    item.Tags.Remove(null);
                }

                liteCollection.Update(item);
            }

            Dictionary<string, int> exp = new Dictionary<string, int>();

            foreach (var item in items)
            {
                foreach (var itemTag in item.Tags)
                {
                    if (itemTag != null)
                    {
                        if (exp.ContainsKey(itemTag))
                        {
                            exp[itemTag]++;
                        }
                        else
                        {
                            exp.Add(itemTag, 1);
                        }
                    }
                }
            }

            var itemsListVew = new List<ListViewItem>();
            var res = exp.OrderByDescending(x => x.Value).ToList();
            int available = 0;
            for (int i = 0; i < 100; i++)
            {
                if (res[i].Value < 3)
                {
                    break;
                }

                li = new ListViewItem();
                li.SubItems[0].Text = res[i].Key;
                li.SubItems.Add(res[i].Value.ToString());
                //lvStatistic.Items.Add(li);
                itemsListVew.Add(li);
                available++;
            }

            li = new ListViewItem();
            li.SubItems[0].Text = "Total:";
            li.SubItems.Add(items.Count.ToString());
            lvStatistic.Items.Add(li);

            li = new ListViewItem();
            li.SubItems[0].Text = "Available:";
            li.SubItems.Add(available.ToString());
            lvStatistic.Items.Add(li);

            li = new ListViewItem();
            li.SubItems[0].Text = "---------";
            li.SubItems.Add("---");
            lvStatistic.Items.Add(li);

            lvStatistic.Items.AddRange(itemsListVew.ToArray());
        }
    }
}
