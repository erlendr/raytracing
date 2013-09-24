using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

namespace Raytracer
{
    public class ImageHandler
    {
        public Bitmap CreateBitmap(int width, int height, PixelFormat format)
        {
            return new Bitmap(width, height, format);
        }

        public void CreateImage(int width, int height)
        {
            using (var bitmap = CreateBitmap(width, height, PixelFormat.Format24bppRgb))
            {
                var color = Color.Blue;

                for (var i = 0; i < bitmap.Width; i++)
                {
                    for (var j = 0; j < bitmap.Height; j++)
                    {
                        if ((i > 200) && (i < 300))
                        {
                            bitmap.SetPixel(i, j, color);
                        }
                    }
                }

                SaveImage(bitmap);
            }
        }

        public void SaveImage(Bitmap bitmap)
        {
            bitmap.Save("bitmap.bmp");
        }
    }
}