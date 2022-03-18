using System;
using System.Collections.Generic;
using System.ComponentModel;
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

namespace WPFhello
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnHello_Click(object sender, RoutedEventArgs e)
        {
            if (txtName.Text.Length >= 2 && txtName1.Text.Length >= 2 && txtName2.Text.Length >= 2)
            {
                string name = new("");
                foreach (var item in MainGrid.Children)
                {
                    if (item is TextBox)
                    {
                        name = name + ((TextBox)item).Text + ' ';
                    }
                }
                name = name.TrimEnd();
                MessageBox.Show("Здравейте " + name + "!!! Това е вашата първа програма на VisualStudio 2022!");
            }
            else
            {
                MessageBox.Show("Дължината и на трите имена тябва да е поне два символа.\nОпитайте отново!");
            }
        }

        private void Window_Closing(object sender, CancelEventArgs e)
        {
            string msg = "Сигурни ли сте, че искате да затворите приложението?";
            MessageBoxResult result =
              MessageBox.Show(
                msg,
                "Приложение",
                MessageBoxButton.YesNo,
                MessageBoxImage.Warning);
            if (result == MessageBoxResult.No)
            {
                e.Cancel = true;
            }

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("This is Windows Presentation Foundation!");
            textBlock1.Text = DateTime.Now.ToString();
        }
    }
}
