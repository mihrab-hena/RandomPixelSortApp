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
    public class ImageHandler
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
        /// <param name="listOfPixels"></param>        
        public Bitmap MakeBitmapOfImage(List<Color> listOfPixels)
        {
            int x = 0;
            int y = 0;
            Bitmap bitmap = new Bitmap(widthOfImage, heightOfImage);

            /* x stands for the width of the Image.
               y stands for the height of the Image.

                Pixels of the Image are stored in a lenear way. X and y selects the position of the pixel 
                and place the pixel on the desired position of the Image.
             */
            foreach (var pixel in listOfPixels)
            {
                if (y % bitmap.Height == 0 && y != 0)
                {
                    if (x % bitmap.Width == 0 && x != 0)
                    {
                        break;
                    }

                    y = 0;
                    x++;
                }

                bitmap.SetPixel(x, y, pixel);
                y++;
            }

            return bitmap;
            //return ConvertToBitmapImage(bitmap);
        }

        public BitmapImage ConvertToBitmapImage(Bitmap bitmap)
        {
            //Following 'using' block takes the bitmap and returns a Bitmap image. 
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
