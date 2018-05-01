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
        public void TestMethod1()
        {
            //Arrange
            Dictionary<int , Color> dictionaryToBeSorted = new Dictionary<int, Color>();
            Dictionary<int, Color> dictionaryExpected = new Dictionary<int, Color>();
            Dictionary<int, Color> dictionaryActual = new Dictionary<int, Color>();

            dictionaryToBeSorted.Add(0 ,Color.FromArgb(100, 0, 255, 255));
            dictionaryToBeSorted.Add(1 ,Color.FromArgb(100, 0, 255, 0));
            dictionaryToBeSorted.Add(2 ,Color.FromArgb(100, 0, 0, 255));
            dictionaryToBeSorted.Add(3 ,Color.FromArgb(100, 255, 191, 0));
            dictionaryToBeSorted.Add(4 ,Color.FromArgb(100, 255, 64, 0));
            dictionaryToBeSorted.Add(5 ,Color.FromArgb(100, 64, 0, 255));
            dictionaryToBeSorted.Add(6 ,Color.FromArgb(100, 0, 255, 64));
            dictionaryToBeSorted.Add(7 ,Color.FromArgb(100, 0, 255, 128));
            dictionaryToBeSorted.Add(8 ,Color.FromArgb(100, 0, 128, 255));
            dictionaryToBeSorted.Add(9 ,Color.FromArgb(100, 191, 255, 0));

            dictionaryExpected.Add(4 ,Color.FromArgb(100, 255, 64, 0));
            dictionaryExpected.Add(3 ,Color.FromArgb(100, 255, 191, 0));
            dictionaryExpected.Add(9 ,Color.FromArgb(100, 191, 255, 0));
            dictionaryExpected.Add(1 ,Color.FromArgb(100, 0, 255, 0));
            dictionaryExpected.Add(6 ,Color.FromArgb(100, 0, 255, 64));
            dictionaryExpected.Add(7 ,Color.FromArgb(100, 0, 255, 128));
            dictionaryExpected.Add(0 ,Color.FromArgb(100, 0, 255, 255));
            dictionaryExpected.Add(8 ,Color.FromArgb(100, 0, 128, 255));
            dictionaryExpected.Add(2 ,Color.FromArgb(100, 0, 0, 255));
            dictionaryExpected.Add(5 ,Color.FromArgb(100, 64, 0, 255));
            
            PixelHandler pixelHandler = new PixelHandler();


            //Act
            dictionaryActual = pixelHandler.SortPixelsByHue(dictionaryToBeSorted);            

            //Assert
            CollectionAssert.AreEqual(dictionaryExpected, dictionaryActual);
            
        }
    }
}
