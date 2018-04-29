using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace RandomPixelSortApp
{
    class ImageHandler
    {
        private int heightOfImage;
        private int widthOfImage;

        public ImageHandler(int heightOfImage, int widthOfImage)
        {
            this.heightOfImage = heightOfImage;
            this.widthOfImage = widthOfImage;
        }        

        /// <summary>
        /// Fills the area of Image with given pixels for predefined height and width of the Image
        /// </summary>
        /// <param name="dictionaryPixels"></param>
        /// <returns>BitmapImage as Image</returns>
        public BitmapImage MakeImage(Dictionary<int, Color> dictionaryPixels)
        {
            int x = 0;
            int y = 0;
            Bitmap bitmap = new Bitmap(widthOfImage, heightOfImage);
            foreach (var pixel in dictionaryPixels)
            {
                if (x % widthOfImage == 0 && x != 0)
                {
                    if (y % heightOfImage == 0 && y != 0)
                    {
                        break;
                    }

                    x = 0;
                    y++;
                }
                bitmap.SetPixel(x, y, pixel.Value);
                x++;
            }


            using (MemoryStream memory = new MemoryStream())
            {
                bitmap.Save(memory, ImageFormat.Png);
                memory.Position = 0;
                BitmapImage bitmapImage = new BitmapImage();
                bitmapImage.BeginInit();
                bitmapImage.StreamSource = memory;
                bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
                bitmapImage.EndInit();
                return bitmapImage;
            }            
        }       
    }
}
