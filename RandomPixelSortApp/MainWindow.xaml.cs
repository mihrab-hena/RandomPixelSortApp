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
        Dictionary<int, Color> dictionaryRandomPixels = new Dictionary<int, Color>();
        Dictionary<int, Color> dictionarySortedPixelsByHue = new Dictionary<int, Color>();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void RandomColorButton_Click(object sender, RoutedEventArgs e)
        {
            
            dictionaryRandomPixels = pixelHandler.GenerateRandomPixels();
            ImageHandler imageHandler = new ImageHandler(pixelHandler.HeightOfImage, pixelHandler.WidthOfImage);
            this.ImageViewer.Source = imageHandler.MakeImage(dictionaryRandomPixels);
        }

        private void ColorSortingButton_Click(object sender, RoutedEventArgs e)
        {
            dictionarySortedPixelsByHue = pixelHandler.SortPixelsByHue(dictionaryRandomPixels);
            ImageHandler imageHandler = new ImageHandler(pixelHandler.HeightOfImage, pixelHandler.WidthOfImage);
            this.ImageViewer.Source = imageHandler.MakeImage(dictionarySortedPixelsByHue);
        }
    }
}
