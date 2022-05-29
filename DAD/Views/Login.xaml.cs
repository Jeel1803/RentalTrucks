using DAD.Models;
using DAD.Models.DB;
using System;
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
using System.Windows.Shapes;

namespace DAD.Views
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        public Login()
        {
            InitializeComponent();
            errorLabel.Visibility = Visibility.Hidden;
        }

        private void loginButton_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(usernameTextBox.Text) || string.IsNullOrEmpty(passwordTextBox.Text))
            {
                usernameTextBox.BorderBrush = Brushes.Red;
                passwordTextBox.BorderBrush = Brushes.Red; 
                errorLabel.Visibility = Visibility.Visible;
            }
            else
            {
                errorLabel.Visibility = Visibility.Hidden;
                usernameTextBox.BorderBrush = Brushes.Black;
                passwordTextBox.BorderBrush = Brushes.Black;
                string usname = usernameTextBox.Text;
                string pass = passwordTextBox.Text;
                TruckEmployee truckEmployee = new TruckEmployee();
                truckEmployee.Username = usname;
                truckEmployee.Password = pass;
                try
                {
                    DAO.login(truckEmployee);
                    MainWindow mainWindow = new MainWindow();
                    mainWindow.Show();
                    this.Hide();
                    MessageBox.Show("Welcome");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
    }
}
