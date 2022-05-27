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
        

        static int Counter = 0;

        static string[] tab;
        public int FindMaxCounter()
        {
            string path = @"C:\Users\mikol\source\repos\DriksApp\DriksApp\Resorces\Nazwa.txt";
            string readText = File.ReadAllText(path);
            int maxcounter = 0;
            foreach (char c in readText)
            {
                if (c == '\n')
                {
                    maxcounter++;
                }
            }
            return maxcounter;
        }

        string cut(int x , string entrance, char c = '\n')
        {

            string readText = entrance;
            int coun = 0;
            int start = 0, end = 0;
            for (int i = 0; i < readText.Length; i++)
            {
                if (readText[i] == c)
                {
                    
                    coun++;
                    if (coun == x)
                    {
                        start = i;
                    }
                    if (coun == x + 1)
                    {
                        end = i;
                        break;
                    }
                }
            }
            
            
            string cos = readText.Remove(0, start);
            if (end != 0)
            {
                string finale = cos.Remove(end - start);
                Console.WriteLine(finale);
                return finale;
            }
            return cos;
        }

        public MainWindow()
        {
            string path = @"C:\Users\mikol\source\repos\DriksApp\DriksApp\Resorces\Nazwa.txt";
            string readText = File.ReadAllText(path);
            
            
            tab = new string[FindMaxCounter()+1];
            InitializeComponent();
            for (int i = 0; i < tab.Length; i++)
            {

                tab[i] = cut(i,readText);
            }
            
        }

        public string SetText(int t = 0)
        {
          string  text = tab[Counter];
            string finale = cut(t, text,'|') ;
            return finale.Remove(0,1);
        }

        public  BitmapImage SetImage(string patch)
        {
            Uri newImage;
            //"/Resorces/hhh.jpg"
            newImage = new Uri(patch, UriKind.Relative);
            
            return new BitmapImage(newImage); 
        }

        public void SetAll()
        {
            DrinkNumber.Text = "Drink nr. " + SetText(0);
            DriksName.Text = SetText(1);
            DrinkImage.Source = SetImage(SetText(2));          
            Ingredients.Text = SetText(3);
            Instruction.Text = SetText(4);

        }

        private  void  AddNew_Click(object sender, RoutedEventArgs e)
        {
            NewDrinkWindow win2 = new NewDrinkWindow(FindMaxCounter() );
            win2.Show();
            Close();   


        }

        private void Right_Click(object sender, RoutedEventArgs e)
        {
            Counter++;
            if(Counter == tab.Length)
            {
                Counter = 1;
            }
            SetAll();
        }

        private void Left_Click(object sender, RoutedEventArgs e)
        {
            Counter--;
            
            if (Counter == 0)
            {
                Counter = tab.Length - 1;
            }
            SetAll();
        }

        private  void Exit_Button_Click(object sender, RoutedEventArgs e)
        {
          Application.Current.Shutdown();
        }
    }
}
