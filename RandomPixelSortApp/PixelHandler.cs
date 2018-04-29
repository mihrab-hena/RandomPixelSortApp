using System;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;

namespace RandomPixelSortApp
{
    class PixelHandler
    {
        //heightOfImage and widthOfImage should be in pixels
        public const int heightOfImage = 300;
        public const int widthOfImage = 400;

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
        public Dictionary<int, Color> GenerateRandomPixels()
        {
            Random rand = new Random();
            Dictionary<int, Color> dictionaryRandomPixels = new Dictionary<int, Color>();

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
                dictionaryRandomPixels.Add(index, Color.FromArgb(a, r, g, b));
            }

            return dictionaryRandomPixels;
        }

        /// <summary>
        /// Sort the given pixels with an asending order of HUE value
        /// </summary>
        /// <param name="dictionaryPixels"></param>        
        public Dictionary<int, Color> SortPixelsByHue(Dictionary<int, Color> dictionaryPixels)
        {
            var sortedPixels = from pair in dictionaryPixels
                orderby pair.Value.GetHue() ascending
                select pair;

            return sortedPixels.ToDictionary(p => p.Key, p => p.Value);
        }

    }
}
