using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;

namespace RandomPixelSortApp
{
    public class PixelHandler
    {
        //heightOfImage and widthOfImage should be in pixels                
        public readonly int heightOfImage = 300;
        public readonly int widthOfImage = 400;

        public int HeightOfImage
        {
            get { return heightOfImage; }
        }

        public int WidthOfImage
        {
            get { return widthOfImage; }
        }

        /// <summary>
        /// Generates pixels with random argb values for a given height and width
        /// </summary>        
        public List<Color> GenerateRandomPixels()
        {
            Random rand = new Random();
            List<Color> listOfPixels = new List<Color>();

            int totalNumberOfPixels = heightOfImage * widthOfImage;
            int a = 0;
            int r = 0;
            int g = 0;
            int b = 0;

            for (int index = 0; index < totalNumberOfPixels; index++)
            {
                a = rand.Next(256);
                r = rand.Next(256);
                g = rand.Next(256);
                b = rand.Next(256);
                listOfPixels.Add(Color.FromArgb(a, r, g, b));
            }

            return listOfPixels;
        }
        

        /// <summary>
        /// Sort the given pixels with an asending order of HUE value
        /// </summary>
        /// <param name="listOfPixels"></param>
        /// <returns></returns>
        public List<Color> SortPixelsByHue(List<Color> listOfPixels)
        {
            var sortedPixels = from pixel in listOfPixels
                orderby pixel.GetHue() ascending
                select pixel;

            return sortedPixels.ToList();
        }
    }
}
