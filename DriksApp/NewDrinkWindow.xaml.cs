using System;
using System.IO;
using System.Collections.Generic;
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
using System.Globalization;
using Microsoft.Win32;
using System.Diagnostics;

namespace DriksApp
{
    /// <summary>
    /// Interaction logic for NewDrinkWindow.xaml
    /// </summary>
    public partial class NewDrinkWindow : Window
    {
        string NameOfDrink;
        public int Counter ;
        public NewDrinkWindow()
        {
            InitializeComponent();
        }
        public NewDrinkWindow(int counter)
        {
            Counter = counter;
            InitializeComponent();
        }

        private void AddImage_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog OTWIERACZ = new OpenFileDialog();

            string fileName = @" ";
            string sourcePath = @" ";
            if (OTWIERACZ.ShowDialog() == true)
            {
                fileName = OTWIERACZ.SafeFileName;
                sourcePath = OTWIERACZ.FileName;

            }
            

           
            string targetPath = @"C:\Users\mikol\source\repos\DriksApp\DriksApp\Resorces";

            // Use Path class to manipulate file and directory paths.
            
            string destFile = System.IO.Path.Combine(targetPath, fileName);

        
            try
            {
                // To copy a file to another location and
                // overwrite the destination file if it already exists.
                MessageBox.Show(sourcePath);
                File.Copy(sourcePath, destFile, true);
                
                OutPut.Text = destFile.ToString() + Igrediens.ToString();
                NameOfDrink = destFile.ToString();
                NameOfDrink = NameOfDrink.Remove(0, 45);
                NameOfDrink = NameOfDrink.Replace(@"\", @"/");
            }
            catch (IOException iox)
            {
                MessageBox.Show("Dodanie pliku nie powiodło sie");
            }

            NewImage.Source = SetImage(fileName);

        }

        public BitmapImage SetImage(string patch)
        {
            Uri newImage;
            //"/Resorces/hhh.jpg"
            newImage = new Uri(patch, UriKind.Relative);

            return new BitmapImage(newImage);
        }
        private void Exit_Button_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
           
            string path = @"C:\Users\mikol\source\repos\DriksApp\DriksApp\Resorces\Nazwa.txt";
            string readText = File.ReadAllText(path);
            Counter++;
            
            readText += "\n" + Counter 
              +"|" + Name.Text +"|" + NameOfDrink + "|" + Igrediens.Text + "|" + Recipe.Text ;
            
            File.WriteAllText(path, readText);
            MessageBox.Show("Dodano nowy drink");
        }

        private void Return_Click(object sender, RoutedEventArgs e)
        {
            MainWindow win2 = new MainWindow();
            win2.Show();
            Close();
        }
    }
}
