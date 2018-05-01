using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Color = System.Drawing.Color;

namespace RandomPixelSortApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        PixelHandler pixelHandler = new PixelHandler();        
        List<Color> listOfRandomPixels = new List<Color>();        
        List<Color> listOfSortedPixelsByHue = new List<Color>();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void RandomColorButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                listOfRandomPixels = pixelHandler.GenerateRandomPixels();
                ImageHandler imageHandler = new ImageHandler(pixelHandler.HeightOfImage, pixelHandler.WidthOfImage);
                ImageViewer.Source = imageHandler.MakeImage(listOfRandomPixels);
            }
            catch (ArgumentException argumentException)
            {
                MessageBox.Show("Invalid A/R/G/B values \n Details:" + argumentException.Message);
                
            }
            catch (Exception exceptionObj)
            {
                Console.WriteLine("Error Occured. \n Details:" + exceptionObj.Message);
            }
      
        }

        private void ColorSortingButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                listOfSortedPixelsByHue = pixelHandler.SortPixelsByHue(listOfRandomPixels);
                ImageHandler imageHandler = new ImageHandler(pixelHandler.HeightOfImage, pixelHandler.WidthOfImage);
                ImageViewer.Source = imageHandler.MakeImage(listOfSortedPixelsByHue);
            }
            catch (Exception exceptionObj)
            {
                Console.WriteLine("Error Occured. \n Details:" + exceptionObj.Message);
            }            
        }
    }
}
