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
    /// Interaction logic for Bar.xaml
    /// </summary>

    public partial class Bar : Window
    {

        static string[] tabb;
        static int Counter;
        static int Max;
        void Plus()
        {
            Counter++;
            if(Counter > Max)
            {
                Counter = 0;
            }
            if(Counter < 0)
            {
                Max = Counter;
            }
        }

        MainWindow MW;
        void FillIn()
        {
            MW = new MainWindow();
            

            NameOne.Text = MW.SetText(tabb, 1,Counter);
            QuantityOne.Text = MW.SetText(tabb, 2, Counter);
            One.Source = MW.SetImage(MW.SetText(tabb, 3, Counter));
            int tymaczas = Counter;
            Plus();
            
            NameTwo.Text = MW.SetText(tabb, 1, Counter);
            QuantityTwo.Text = MW.SetText(tabb, 2, Counter);
            Two.Source = MW.SetImage(MW.SetText(tabb, 3, Counter));

            Plus();

            NameThree.Text = MW.SetText(tabb, 1, Counter);
            QuantityThree.Text = MW.SetText(tabb, 2, Counter);
            Three.Source = MW.SetImage(MW.SetText(tabb, 3, Counter));

            Plus();

            NameFour.Text = MW.SetText(tabb, 1, Counter);
            QuantityFour.Text = MW.SetText(tabb, 2, Counter);
            Four.Source = MW.SetImage(MW.SetText(tabb, 3, Counter));

            Plus();

            NameFive.Text = MW.SetText(tabb, 1, Counter);
            QuantityFive.Text = MW.SetText(tabb, 2, Counter);
            Five.Source = MW.SetImage(MW.SetText(tabb, 3, Counter));
            Counter = tymaczas;
           
        }
        public Bar()
        {



                         
            string path = @"C:\Users\mikol\source\repos\DriksApp\DriksApp\Resorces\Bar.txt";
            string readText = File.ReadAllText(path);

            MW = new MainWindow();
            tabb = new string[MW.FindMaxCounter(path) + 1];
            Max = MW.FindMaxCounter(path);

            InitializeComponent();
            for (int i = 0; i < tabb.Length; i++)
            {

                tabb[i] = MW.Cut(i, readText);
            }

            InitializeComponent();
            FillIn();

        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            Counter--;
            if (Counter < 0)
            {
                Counter = Max;
            }
            FillIn();
        }

        private void Exit_Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow win2 = new MainWindow();
            win2.Show();
            Close();
        }

        private void Next_Click(object sender, RoutedEventArgs e)
        {
            Counter++;
            if (Counter > Max)
            {
                Counter = 0;
            }
            FillIn();
        }

        private void NewButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
