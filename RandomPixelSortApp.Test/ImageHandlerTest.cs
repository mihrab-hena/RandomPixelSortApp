using System;
using System.Collections.Generic;
using System.Drawing;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace RandomPixelSortApp.Test
{
    [TestClass]
    public class ImageHandlerTest
    {
        [TestMethod]
        public void MakeBitmapOfImage_ShouldReturnBitmap_BitmapOfCertainHeightAndWidth()
        {
            //Arrange
            int height = 3;
            int width = 4;
            

            ImageHandler imageHandler = new ImageHandler(height, width);

            List<Color> listOfPixels = new List<Color>();

            listOfPixels.Add(Color.FromArgb(100, 255, 64, 0));
            listOfPixels.Add(Color.FromArgb(100, 255, 191, 0));
            listOfPixels.Add(Color.FromArgb(100, 191, 255, 0));
            listOfPixels.Add(Color.FromArgb(100, 0, 255, 0));
            listOfPixels.Add(Color.FromArgb(100, 0, 255, 64));
            listOfPixels.Add(Color.FromArgb(100, 0, 255, 128));
            listOfPixels.Add(Color.FromArgb(100, 0, 255, 255));
            listOfPixels.Add(Color.FromArgb(100, 0, 128, 255));
            listOfPixels.Add(Color.FromArgb(100, 0, 0, 255));
            listOfPixels.Add(Color.FromArgb(100, 64, 0, 255));
            listOfPixels.Add(Color.FromArgb(100, 64, 45, 255));
            listOfPixels.Add(Color.FromArgb(100, 64, 79, 255));

            //Act
            var bitmapOfImage = imageHandler.MakeBitmapOfImage(listOfPixels);

            //Assert
            Assert.AreEqual(height, bitmapOfImage.Height);
            Assert.AreEqual(width, bitmapOfImage.Width);
        }
    }
}
