namespace CaptchaDbTool
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.lvStatistic = new System.Windows.Forms.ListView();
            this.Property = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.value = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cbxTag = new System.Windows.Forms.ComboBox();
            this.btnRemove = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.liTags = new System.Windows.Forms.ListBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.lblHash = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnNext = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.btnReload = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.btnTagRemove = new System.Windows.Forms.Button();
            this.btnTagAdd = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.txbTagEdit = new System.Windows.Forms.TextBox();
            this.btnRemoveItem = new System.Windows.Forms.Button();
            this.lblImageItemName = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.liTagsOfItem = new System.Windows.Forms.ListBox();
            this.liImageItems = new System.Windows.Forms.ListBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(256, 256);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.groupBox5);
            this.groupBox1.Controls.Add(this.cbxTag);
            this.groupBox1.Controls.Add(this.btnRemove);
            this.groupBox1.Controls.Add(this.btnAdd);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.liTags);
            this.groupBox1.Location = new System.Drawing.Point(274, 64);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(453, 372);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "groupBox1";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.lvStatistic);
            this.groupBox5.Location = new System.Drawing.Point(209, 16);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(238, 350);
            this.groupBox5.TabIndex = 6;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Statistic";
            // 
            // lvStatistic
            // 
            this.lvStatistic.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Property,
            this.value});
            this.lvStatistic.HideSelection = false;
            this.lvStatistic.Location = new System.Drawing.Point(6, 19);
            this.lvStatistic.Name = "lvStatistic";
            this.lvStatistic.Size = new System.Drawing.Size(226, 325);
            this.lvStatistic.TabIndex = 0;
            this.lvStatistic.UseCompatibleStateImageBehavior = false;
            this.lvStatistic.View = System.Windows.Forms.View.Details;
            // 
            // Property
            // 
            this.Property.Text = "Property";
            this.Property.Width = 120;
            // 
            // value
            // 
            this.value.Text = "Value";
            this.value.Width = 80;
            // 
            // cbxTag
            // 
            this.cbxTag.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbxTag.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbxTag.FormattingEnabled = true;
            this.cbxTag.Location = new System.Drawing.Point(7, 34);
            this.cbxTag.Name = "cbxTag";
            this.cbxTag.Size = new System.Drawing.Size(115, 21);
            this.cbxTag.TabIndex = 5;
            // 
            // btnRemove
            // 
            this.btnRemove.Location = new System.Drawing.Point(128, 63);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(75, 23);
            this.btnRemove.TabIndex = 4;
            this.btnRemove.Text = "Remove";
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(128, 34);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 3;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Tag name";
            // 
            // liTags
            // 
            this.liTags.FormattingEnabled = true;
            this.liTags.Location = new System.Drawing.Point(6, 90);
            this.liTags.Name = "liTags";
            this.liTags.Size = new System.Drawing.Size(197, 108);
            this.liTags.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnSave);
            this.groupBox2.Controls.Add(this.lblHash);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.btnNext);
            this.groupBox2.Location = new System.Drawing.Point(274, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(453, 45);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "groupBox2";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(372, 16);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 3;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // lblHash
            // 
            this.lblHash.AutoSize = true;
            this.lblHash.Location = new System.Drawing.Point(134, 21);
            this.lblHash.Name = "lblHash";
            this.lblHash.Size = new System.Drawing.Size(16, 13);
            this.lblHash.TabIndex = 2;
            this.lblHash.Text = "...";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(90, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Name:";
            // 
            // btnNext
            // 
            this.btnNext.Location = new System.Drawing.Point(6, 16);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(75, 23);
            this.btnNext.TabIndex = 0;
            this.btnNext.Text = "Next";
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Location = new System.Drawing.Point(12, 442);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(736, 10);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            // 
            // groupBox6
            // 
            this.groupBox6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox6.Controls.Add(this.btnReload);
            this.groupBox6.Controls.Add(this.groupBox4);
            this.groupBox6.Controls.Add(this.liImageItems);
            this.groupBox6.Controls.Add(this.pictureBox2);
            this.groupBox6.Location = new System.Drawing.Point(12, 458);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(736, 283);
            this.groupBox6.TabIndex = 8;
            this.groupBox6.TabStop = false;
            // 
            // btnReload
            // 
            this.btnReload.Location = new System.Drawing.Point(275, 19);
            this.btnReload.Name = "btnReload";
            this.btnReload.Size = new System.Drawing.Size(161, 23);
            this.btnReload.TabIndex = 11;
            this.btnReload.Text = "Reload";
            this.btnReload.UseVisualStyleBackColor = true;
            this.btnReload.Click += new System.EventHandler(this.btnReload_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.btnTagRemove);
            this.groupBox4.Controls.Add(this.btnTagAdd);
            this.groupBox4.Controls.Add(this.btnUpdate);
            this.groupBox4.Controls.Add(this.txbTagEdit);
            this.groupBox4.Controls.Add(this.btnRemoveItem);
            this.groupBox4.Controls.Add(this.lblImageItemName);
            this.groupBox4.Controls.Add(this.label3);
            this.groupBox4.Controls.Add(this.liTagsOfItem);
            this.groupBox4.Location = new System.Drawing.Point(446, 19);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(275, 251);
            this.groupBox4.TabIndex = 10;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Image item info";
            // 
            // btnTagRemove
            // 
            this.btnTagRemove.Location = new System.Drawing.Point(194, 114);
            this.btnTagRemove.Name = "btnTagRemove";
            this.btnTagRemove.Size = new System.Drawing.Size(75, 23);
            this.btnTagRemove.TabIndex = 8;
            this.btnTagRemove.Text = "Remove";
            this.btnTagRemove.UseVisualStyleBackColor = true;
            this.btnTagRemove.Click += new System.EventHandler(this.btnTagRemove_Click);
            // 
            // btnTagAdd
            // 
            this.btnTagAdd.Location = new System.Drawing.Point(194, 85);
            this.btnTagAdd.Name = "btnTagAdd";
            this.btnTagAdd.Size = new System.Drawing.Size(75, 23);
            this.btnTagAdd.TabIndex = 7;
            this.btnTagAdd.Text = "Add";
            this.btnTagAdd.UseVisualStyleBackColor = true;
            this.btnTagAdd.Click += new System.EventHandler(this.btnTagAdd_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(194, 56);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(75, 23);
            this.btnUpdate.TabIndex = 6;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // txbTagEdit
            // 
            this.txbTagEdit.Location = new System.Drawing.Point(16, 58);
            this.txbTagEdit.Name = "txbTagEdit";
            this.txbTagEdit.Size = new System.Drawing.Size(167, 20);
            this.txbTagEdit.TabIndex = 5;
            // 
            // btnRemoveItem
            // 
            this.btnRemoveItem.Location = new System.Drawing.Point(178, 22);
            this.btnRemoveItem.Name = "btnRemoveItem";
            this.btnRemoveItem.Size = new System.Drawing.Size(91, 23);
            this.btnRemoveItem.TabIndex = 4;
            this.btnRemoveItem.Text = "Remove object";
            this.btnRemoveItem.UseVisualStyleBackColor = true;
            this.btnRemoveItem.Click += new System.EventHandler(this.btnRemoveItem_Click);
            // 
            // lblImageItemName
            // 
            this.lblImageItemName.AutoSize = true;
            this.lblImageItemName.Location = new System.Drawing.Point(57, 27);
            this.lblImageItemName.Name = "lblImageItemName";
            this.lblImageItemName.Size = new System.Drawing.Size(16, 13);
            this.lblImageItemName.TabIndex = 3;
            this.lblImageItemName.Text = "...";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 27);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Name:";
            // 
            // liTagsOfItem
            // 
            this.liTagsOfItem.FormattingEnabled = true;
            this.liTagsOfItem.Location = new System.Drawing.Point(16, 84);
            this.liTagsOfItem.Name = "liTagsOfItem";
            this.liTagsOfItem.Size = new System.Drawing.Size(167, 147);
            this.liTagsOfItem.TabIndex = 1;
            this.liTagsOfItem.SelectedIndexChanged += new System.EventHandler(this.liTagsOfItem_SelectedIndexChanged);
            // 
            // liImageItems
            // 
            this.liImageItems.FormattingEnabled = true;
            this.liImageItems.Location = new System.Drawing.Point(275, 45);
            this.liImageItems.Name = "liImageItems";
            this.liImageItems.Size = new System.Drawing.Size(162, 225);
            this.liImageItems.TabIndex = 9;
            this.liImageItems.SelectedIndexChanged += new System.EventHandler(this.liImageItems_SelectedIndexChanged);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Location = new System.Drawing.Point(6, 19);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(256, 256);
            this.pictureBox2.TabIndex = 8;
            this.pictureBox2.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(773, 753);
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.pictureBox1);
            this.Name = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox liTags;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label lblHash;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ComboBox cbxTag;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.ListView lvStatistic;
        private System.Windows.Forms.ColumnHeader Property;
        private System.Windows.Forms.ColumnHeader value;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.Button btnReload;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button btnTagRemove;
        private System.Windows.Forms.Button btnTagAdd;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.TextBox txbTagEdit;
        private System.Windows.Forms.Button btnRemoveItem;
        private System.Windows.Forms.Label lblImageItemName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ListBox liTagsOfItem;
        private System.Windows.Forms.ListBox liImageItems;
        private System.Windows.Forms.PictureBox pictureBox2;
    }
}

