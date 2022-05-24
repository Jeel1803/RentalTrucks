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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DAD.Views
{
    /// <summary>
    /// Interaction logic for AddEmployeeUC.xaml
    /// </summary>
    public partial class AddEmployeeUC : UserControl
    {
        public AddEmployeeUC()
        {
            InitializeComponent();
        }


        private void addEmployeeButton_Click(object sender, RoutedEventArgs e)
        {
            int output = DAO.validEmptyInput(formGrid);
            if (output != 0)
            {
                MessageBox.Show("Enter Missing val");
            }
            else { 
            string name = nameTextBox.Text;
            string address = addressTextBox.Text;
            string telephone = telephoneTextBox.Text;
            string officeAddress = officeAddressTextBox.Text;
            string phoneExt = phoneExtTextBox.Text;
            string username = usernameTextBox.Text;
            string password = passwordTextBox.Text;
            string role = roleComboBox.Text;
                //Parent Class
                TruckPerson truckPerson = new TruckPerson();
                truckPerson.Name = name;
                truckPerson.Address = address;
                truckPerson.Telephone = telephone;

                //Child Class
                TruckEmployee truckEmployee = new TruckEmployee();
                truckEmployee.OfficeAddress = officeAddress;
                truckEmployee.Username = username;
                truckEmployee.Password = password;
                truckEmployee.Role = role;
                truckEmployee.PhoneExtensionNumber = phoneExt;
                truckEmployee.Employee = truckPerson;


                try
                {
                    DAO.addEmployee(truckEmployee);
                    MessageBox.Show("Employee Added Successfully!");
                    nameTextBox.Clear();
                    addressTextBox.Clear();
                    telephoneTextBox.Clear();
                    officeAddressTextBox.Clear();
                    usernameTextBox.Clear();
                    passwordTextBox.Clear();
                    phoneExtTextBox.Clear();
                }

                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void resetButton_Click(object sender, RoutedEventArgs e)
        {
            nameTextBox.Clear();
            addressTextBox.Clear();
            telephoneTextBox.Clear();
            officeAddressTextBox.Clear();
            usernameTextBox.Clear();
            passwordTextBox.Clear();
            phoneExtTextBox.Clear();
        }
    }
}
