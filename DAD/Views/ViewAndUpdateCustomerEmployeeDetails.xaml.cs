﻿using DAD.Models;
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
using DAD.Models.DB;

namespace DAD.Views
{
    /// <summary>
    /// Interaction logic for ViewAndUpdateCustomerEmployeeDetails.xaml
    /// </summary>
    public partial class ViewAndUpdateCustomerEmployeeDetails : UserControl
    {
        int count;
        public ViewAndUpdateCustomerEmployeeDetails()
        {
            InitializeComponent();
            
            idComboBox.ItemsSource = DAO.GetPersonID();
            idComboBox.DisplayMemberPath = "PersonId";
            idComboBox.SelectedValuePath = "PersonId";
            isVisibleCommonFields(false);
            isVisibleCustomerFields(false);
            isVisibleEmployeeFields(false);
            isVisibleIDInputs(false);
        }

        private void isVisibleIDInputs(bool v)
        {
            if (v)
            {
                idComboBox.Visibility = Visibility.Visible;
                searchIDButton.Visibility = Visibility.Visible;
            }
            else
            {
                idComboBox.Visibility = Visibility.Hidden;
                searchIDButton.Visibility = Visibility.Hidden;
            }
        }

        private void isVisibleEmployeeFields(bool v)
        {
            if (v)
            {
                phoneExtTextBox.Visibility = Visibility.Visible;
                officeAddressTextBox.Visibility = Visibility.Visible;
                usernameTextBox.Visibility = Visibility.Visible;
                passwordTextBox.Visibility = Visibility.Visible;
                roleComboBox.Visibility = Visibility.Visible;
                updateButoon.Visibility = Visibility.Visible;

            }
            else
            {
                phoneExtTextBox.Visibility = Visibility.Hidden;
                officeAddressTextBox.Visibility = Visibility.Hidden;
                usernameTextBox.Visibility = Visibility.Hidden;
                passwordTextBox.Visibility = Visibility.Hidden;
                roleComboBox.Visibility = Visibility.Hidden;
                updateButoon.Visibility = Visibility.Hidden;

            }
        }

        private void isVisibleCustomerFields(bool v)
        {
            if (v)
            {
                ageTextBox.Visibility = Visibility.Visible;
                lcTextBox.Visibility = Visibility.Visible;
                expiryTextBox.Visibility = Visibility.Visible;
                updateButoon.Visibility = Visibility.Visible;
            }
            else
            {
                ageTextBox.Visibility = Visibility.Hidden;
                lcTextBox.Visibility = Visibility.Hidden;
                expiryTextBox.Visibility = Visibility.Hidden;
                updateButoon.Visibility = Visibility.Hidden;
            }
        }

        private void isVisibleCommonFields(bool v)
        {
            if (v)
            {
                
                nameTextBox.Visibility = Visibility.Visible;
                addressTextBox.Visibility = Visibility.Visible;
                telephoneTextBox.Visibility = Visibility.Visible;
                officeAddressTextBox.Visibility = Visibility.Visible;
                 
               

            }
            else
            {
                
                nameTextBox.Visibility = Visibility.Hidden;
                addressTextBox.Visibility = Visibility.Hidden;
                telephoneTextBox.Visibility = Visibility.Hidden;
                officeAddressTextBox.Visibility = Visibility.Hidden;
                
               
            }
        }


                private void searchEmployeeButton_Click(object sender, RoutedEventArgs e)
        {
            isVisibleIDInputs(true);
            count = 1;
            isVisibleCustomerFields(false);
            isVisibleCommonFields(false);


        }

        private void searchCustomerButton_Click(object sender, RoutedEventArgs e)
        {
            isVisibleIDInputs(true);
            count = 2;
            isVisibleEmployeeFields(false);
            isVisibleCommonFields(false);



        }



        private void searchAllCustomerButton_Click(object sender, RoutedEventArgs e)
        {
            detailsDataGrid.ItemsSource = DAO.GetCustomer();

        }

        private void searchAllEmployeeButton_Click(object sender, RoutedEventArgs e)
        {
            detailsDataGrid.ItemsSource = DAO.GetEmployee();
        }

        private void updateButoon_Click(object sender, RoutedEventArgs e)
        {
            int id = int.Parse(idComboBox.ToString());
            TruckPerson p = DAO.searchEmployeeByID(id);
            if(p != null)
            {
                p.Address = addressTextBox.Text;
                p.Telephone = telephoneTextBox.Text;
                p.Name = nameTextBox.Text;
                p.TruckEmployee.PhoneExtensionNumber = phoneExtTextBox.Text;
                p.TruckEmployee.Username = usernameTextBox.Text;
                p.TruckEmployee.Password = passwordTextBox.Text;
                p.TruckEmployee.OfficeAddress = officeAddressTextBox.Text;
                p.TruckEmployee.Role = roleComboBox.Text;
            }
        }

        private void SearchID_Click(object sender, RoutedEventArgs e)
        {
            updateButoon.Visibility = Visibility.Visible;
            isVisibleCommonFields(true);
            if(count == 1)
            {
                isVisibleEmployeeFields(true);
                isVisibleCustomerFields(false);
            }
            else
            {
                isVisibleEmployeeFields(false);
                isVisibleCustomerFields(true);
            }
        }
    }
}