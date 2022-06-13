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
        

       public static int Counter = 0;
        static int MaxCounter = 0;


        static string[] tab;
        public int FindMaxCounter(string entranse = @"C:\Users\mikol\source\repos\DriksApp\DriksApp\Resorces\Nazwa.txt", char stoper = '\n', bool normal = true)
        {
            string readText;
            if (normal)
            {
            string path = entranse;
            readText = File.ReadAllText(path);
            }
            else
            {
                readText = entranse;
            }
            
            int maxcounter = 0;
            foreach (char c in readText)
            {
                if (c == stoper )
                {
                    maxcounter++;
                }
            }
            return maxcounter;
        }
        

       public string Cut(int x , string entrance, char c = '\n')
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
            
            MaxCounter = FindMaxCounter() + 1;
            tab = new string[MaxCounter];
            InitializeComponent();
            for (int i = 0; i < tab.Length; i++)
            {
               
                tab[i] = Cut(i,readText);
            }
            MaxCounter--;
            Right_Click();
            
        }

        public string SetText(string[] tabb ,int t = 0 , int cut = -10)
        {
            string text;
            if (cut== -10)
            {
                text = tabb[Counter];
            }
            else
            {
                 text = tabb[cut];
            }
            string finale = Cut(t, text,'|') ;
            return finale.Remove(0,1);
        }

        public  BitmapImage SetImage(string patch)
        {
            Uri newImage;       
            newImage = new Uri(patch, UriKind.Relative);
            
            return new BitmapImage(newImage); 
        }

        public int FindNumber(string target)
        {
            for (int i = 0; i < target.Length; i++)
            {
                if(target[i] == '1'|| target[i] == '2' || target[i] == '3' || target[i] == '4' || target[i] == '5' || target[i] == '6' || target[i] == '7' || target[i] == '8' || target[i] == '9')
                {
                    return i;
                }
            }
            return 0;
        } 
        public bool IsPossibleToMake(string igrediens)
        {
            int fucktymczas = 2;
            IsOkToMake.Text = " ";
            int CounterOfIgredniens = FindMaxCounter(igrediens,'.',false);
            string[] tab  = new string[CounterOfIgredniens];
            
            for (int i = 0; i < CounterOfIgredniens; i++)
            {
                string x = Cut(i, igrediens, '.');
                tab[i] = x;
            }
            IsOkToMake.Text += tab[fucktymczas];
            for (int i = 0; i < CounterOfIgredniens; i++)
            {
                if (i == 0)
                {

                }
                else
                {
                    tab[i] = tab[i].Remove(0, 2);
                }
                
                int end = FindMaxCounter(tab[i], ' ', false);
                tab[i] = tab[i].Remove(tab[i].Length  - end +1 );
            }
            string[] tab2 = new string[CounterOfIgredniens];
            int[] intTab = new int[CounterOfIgredniens];
            IsOkToMake.Text += tab[fucktymczas];

            for (int i = 0; i < CounterOfIgredniens; i++)
            {
                int x = FindNumber(tab[i]);
                for (int k = 0; k < x; k++)
                {
                    string kk =   tab[i].Substring(x);
                    kk.Remove(2);
                    intTab[i] = int.Parse(kk);
                }
            }
          
            IsOkToMake.Text +=   tab2[fucktymczas];
            return false;
        }
        public void SetAll()
        {
            DrinkNumber.Text = "Drink nr. " + SetText(tab,0);
            DriksName.Text = SetText(tab,1);
            DrinkImage.Source = SetImage(SetText(tab,2));          
            Ingredients.Text = SetText(tab,3);
            Instruction.Text = SetText( tab ,4);
            if(IsPossibleToMake(SetText(tab, 3)))
            {

                Gri.Background = Brushes.Blue;
            }

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
        private void Right_Click()
        {
            Counter++;
            if (Counter == tab.Length)
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

        private void BarButton_Click(object sender, RoutedEventArgs e)
        {
            Bar bar = new Bar();
            bar.Show();
            Close();
        }
    }
}
