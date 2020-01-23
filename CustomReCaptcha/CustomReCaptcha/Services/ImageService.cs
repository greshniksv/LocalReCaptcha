using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using CustomReCaptcha.Services.Interfaces;

namespace CustomReCaptcha.Services
{
    public class ImageService : IImageService
    {
        private readonly IList<IDistortionAlgorithm> distortionServices;

        public ImageService(IDistortionAlgorithm[] distortionServices)
        {
            this.distortionServices = distortionServices.ToList();
        }

        public Stream Generate(string captcha, string lang)
        {
            Random random = new Random(captcha.Length + lang[0]);
            var alg = random.Next(0, distortionServices.Count - 1);
            IDistortionAlgorithm algorithm = distortionServices[alg];

            int height = 30;
            int width = 100;
            Bitmap bmp = new Bitmap(width, height);
            RectangleF rectangle = new RectangleF(10, 5, 0, 0);
            Graphics g = Graphics.FromImage(bmp);
            g.Clear(Color.White);
            algorithm.Before(g);
            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.InterpolationMode = InterpolationMode.HighQualityBicubic;
            g.PixelOffsetMode = PixelOffsetMode.HighQuality;
            g.DrawString(" "+captcha,
                new Font("Thaoma", 12, FontStyle.Italic), Brushes.Green, rectangle);
            g.DrawRectangle(new Pen(Color.Red), 1, 1, width - 2, height - 2);
            algorithm.After(g);
            g.Flush();

            algorithm.Common(bmp);
            var memoryStream = new MemoryStream();
            bmp.Save(memoryStream, ImageFormat.Png);
            memoryStream.Position = 0;
            return memoryStream;
        }
    }
}