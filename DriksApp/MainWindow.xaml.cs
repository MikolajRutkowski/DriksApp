using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
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

namespace DriksApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        static int o = 1;
        public MainWindow()
        {
            InitializeComponent();
        }

       
           

          
        

        private async void  AddNew_Click(object sender, RoutedEventArgs e)
        {
            Uri newImage;
            if (o%2 == 0)
            {
             newImage = new Uri("/Resorces/hhh.jpg", UriKind.Relative);
            }
            else {  newImage = new Uri("/Resorces/Kamikadze.PNG", UriKind.Relative); }
            o++;
            DrinkImage.Source = new BitmapImage(newImage);
            string text =
           "A class is the most powerful data type in C#. Like a structure, " +
           "a class defines the data and behavior of the data type. ";
            await File.WriteAllTextAsync("/Resorces/Nazwa.txt", text);
        }

        private void Right_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Left_Click(object sender, RoutedEventArgs e)
        {

        }

        private async void Exit_Button_Click(object sender, RoutedEventArgs e)
        {
            
        }
    }
}
