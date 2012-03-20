using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Drawing.Imaging;
using Common.Domain;

namespace Core.Web
{
    public class ImageGenerator
    {
        public byte[] Resize(byte[] image, int size)
        {
            return Resize(image, size, size);
        }

        public byte[] Resize(byte[] image, int height, int width)
        {
            using (var stream = new MemoryStream(image))
            {
                return Generate((Bitmap)Image.FromStream(stream), height, width);
            }
        }

        public byte[] Generate(string path)
        {
            return Generate(path, 0);
        }

        public byte[] Generate(string path, int size)
        {
            return Generate(path, size, size);
        }

        public byte[] Generate(string path, int height, int width)
        {
            return Generate(new Bitmap(path), height, width);
        }

        private byte[] Generate(Bitmap image, int height, int width)
        {
            double y = image.Height, x = image.Width;

            double factor = 1;
            if (width > 0)
                factor = width / x;
            else if (height > 0)
                factor = height / y;

            var thumbnail = new Bitmap((int)(x * factor), (int)(y * factor));
            var g = Graphics.FromImage(thumbnail);

            g.Clear(Color.Black);

            g.CompositingQuality = CompositingQuality.HighQuality;
            g.InterpolationMode = InterpolationMode.HighQualityBicubic;
            g.SmoothingMode = SmoothingMode.HighQuality;

            g.DrawImage(image, new Rectangle(-1, -1, (int)(factor * x) + 1, (int)(factor * y) + 1),
                new Rectangle(0, 0, (int)x, (int)y), GraphicsUnit.Pixel);

            var stream = new MemoryStream();
            thumbnail.Save(stream, ImageFormat.Jpeg);

            var array = stream.ToArray();
            stream.Close();

            return array;
        }
    }
}
