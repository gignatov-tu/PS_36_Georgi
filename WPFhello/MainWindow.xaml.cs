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
            ListBoxItem james = new ListBoxItem();
            james.Content = "James";
            peopleListBox.Items.Add(james);
            ListBoxItem david = new ListBoxItem();
            david.Content = "David";
            peopleListBox.Items.Add(david);
            peopleListBox.SelectedItem = james;
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
            MyMessage anotherWindow = new MyMessage();
            anotherWindow.Show();
            textBlock1.Text = DateTime.Now.ToString();
        }

        private void peopleListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void btn_greeting_Click(object sender, RoutedEventArgs e)
        {
            string greetingMsg;
            greetingMsg = (peopleListBox.SelectedItem as ListBoxItem).Content.ToString();
            MessageBox.Show("Hi " + greetingMsg);
        }
    }
}
