using DAD.Models;
using DAD.Models.DB;
using DAD.Views;
using System;
using System.Collections.Generic;
using System.Globalization;
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

namespace DAD
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        EmployeeDetails ed = new EmployeeDetails();

        public MainWindow()
        {
            InitializeComponent();
            
            ed = DAO.fetchPersonalInfo().FirstOrDefault();
            if(ed.Role == "Admin")
            {
                addEmployee.IsEnabled = true;
               

            }
            else
            {
                addEmployee.IsEnabled = false;
            }

        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            mainPanel.Children.Clear();
            mainPanel.Children.Add(new AddEmployeeUC());
        }

        private void peopleInformation_Click(object sender, RoutedEventArgs e)
        {
            mainPanel.Children.Clear();
            mainPanel.Children.Add(new DisplayAndUpdateCustomerInformationUC());
        }

        private void viewAndUpdateCustomerEmployee_Click(object sender, RoutedEventArgs e)
        {
            mainPanel.Children.Clear();
            mainPanel.Children.Add(new ViewAndUpdateCustomerEmployeeDetails());
        }

        private void perosnalDetails_Click(object sender, RoutedEventArgs e)
        {
            mainPanel.Children.Clear();
            mainPanel.Children.Add(new ViewPersonalDetailsUC());
        
    }

        private void login_Click(object sender, RoutedEventArgs e)
        {
            Login login = new Login();
            login.Show();
            this.Hide();

        }

        private void ShowButton_Click(object sender, RoutedEventArgs e)
        {
          
        }

        
    }

   
}
