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

       
           

          
        

        private  void  AddNew_Click(object sender, RoutedEventArgs e)
        {
            Uri newImage;
            if (o%2 == 0)
            {
             newImage = new Uri("/Resorces/hhh.jpg", UriKind.Relative);
            }
            else {  newImage = new Uri("/Resorces/Kamikadze.PNG", UriKind.Relative); }
            o++;
            DrinkImage.Source = new BitmapImage(newImage);
           
        }

        private void Right_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Left_Click(object sender, RoutedEventArgs e)
        {

        }

        private  void Exit_Button_Click(object sender, RoutedEventArgs e)
        {
            
        }
    }
}
