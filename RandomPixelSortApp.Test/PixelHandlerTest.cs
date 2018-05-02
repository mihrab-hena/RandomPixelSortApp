using System;
using System.Collections.Generic;
using System.Drawing;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace RandomPixelSortApp.Test
{
    [TestClass]
    public class PixelHandlerTest
    {
        [TestMethod]
        public void GenerateRandomPixels_ShouldGeneratePixles_ListOfPixelsWithCertainLength()
        {
            //Arrange
            PixelHandler pixelHandler = new PixelHandler();
            int heightOfImage = pixelHandler.HeightOfImage;
            int widthOfImage = pixelHandler.WidthOfImage;
            int totalLength = heightOfImage * widthOfImage;
            List<Color> listOfRandomPixels = new List<Color>();

            //Act
            listOfRandomPixels = pixelHandler.GenerateRandomPixels();

            //Assert
            Assert.AreEqual(totalLength, listOfRandomPixels.Count);

        }

        [TestMethod]
        public void SortPixelsByHue_SortPixelsInAscendingOrder_SortedPixels()
        {
            //Arrange
            List<Color> listOfPixelsToBeSorted = new List<Color>();
            List<Color> listOfPixelsExpected = new List<Color>();
            List<Color> listOfPixelsActual = new List<Color>();

            listOfPixelsToBeSorted.Add(Color.FromArgb(100, 0, 255, 255));
            listOfPixelsToBeSorted.Add(Color.FromArgb(100, 0, 255, 0));
            listOfPixelsToBeSorted.Add(Color.FromArgb(100, 0, 0, 255));
            listOfPixelsToBeSorted.Add(Color.FromArgb(100, 255, 191, 0));
            listOfPixelsToBeSorted.Add(Color.FromArgb(100, 255, 64, 0));
            listOfPixelsToBeSorted.Add(Color.FromArgb(100, 64, 0, 255));
            listOfPixelsToBeSorted.Add(Color.FromArgb(100, 0, 255, 64));
            listOfPixelsToBeSorted.Add(Color.FromArgb(100, 0, 255, 128));
            listOfPixelsToBeSorted.Add(Color.FromArgb(100, 0, 128, 255));
            listOfPixelsToBeSorted.Add(Color.FromArgb(100, 191, 255, 0));

            listOfPixelsExpected.Add(Color.FromArgb(100, 255, 64, 0));
            listOfPixelsExpected.Add(Color.FromArgb(100, 255, 191, 0));
            listOfPixelsExpected.Add(Color.FromArgb(100, 191, 255, 0));
            listOfPixelsExpected.Add(Color.FromArgb(100, 0, 255, 0));
            listOfPixelsExpected.Add(Color.FromArgb(100, 0, 255, 64));
            listOfPixelsExpected.Add(Color.FromArgb(100, 0, 255, 128));
            listOfPixelsExpected.Add(Color.FromArgb(100, 0, 255, 255));
            listOfPixelsExpected.Add(Color.FromArgb(100, 0, 128, 255));
            listOfPixelsExpected.Add(Color.FromArgb(100, 0, 0, 255));
            listOfPixelsExpected.Add(Color.FromArgb(100, 64, 0, 255));
            
            PixelHandler pixelHandler = new PixelHandler();


            //Act
            listOfPixelsActual = pixelHandler.SortPixelsByHue(listOfPixelsToBeSorted);            

            //Assert
            CollectionAssert.AreEqual(listOfPixelsExpected, listOfPixelsActual);
            
        }

        
    }
}
