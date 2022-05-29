﻿using DAD.Models;
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
    /// Interaction logic for ViewPersonalDetailsUC.xaml
    /// </summary>
    public partial class ViewPersonalDetailsUC : UserControl
    {
        List<EmployeeDetails> data = null;
        EmployeeDetails ed = new EmployeeDetails();
        public ViewPersonalDetailsUC()
        {
            InitializeComponent();

            isEditable(false);
            ed = DAO.fetchPersonalInfo().FirstOrDefault();

            nameTextBox.Text = ed.Name;
            addressTextBox.Text = ed.Address;
            telephoneTextBox.Text = ed.Telephone;
            officeAddressTextBox.Text = ed.OfficeAddress;
            phoneExtTextBox.Text = ed.PhoneExtensionNumber;
            usernameTextBox.Text = ed.Username;
            passwordTextBox.Text = ed.Password;
            roleComboBox.SelectedIndex = ed.Role.IndexOf(ed.Role);



        }

        private void isEditable(bool v)
        {
            if (v)
            {
                nameTextBox.IsEnabled = true;
                addressTextBox.IsEnabled = true;
                telephoneTextBox.IsEnabled = true;
                officeAddressTextBox.IsEnabled = true;
                phoneExtTextBox.IsEnabled = true;
                usernameTextBox.IsEnabled = true;
                passwordTextBox.IsEnabled = true;
                roleComboBox.IsEnabled = false;

            }
            else
            {
                nameTextBox.IsEnabled = false;
                addressTextBox.IsEnabled = false;
                telephoneTextBox.IsEnabled = false;
                officeAddressTextBox.IsEnabled = false;
                phoneExtTextBox.IsEnabled = false;
                usernameTextBox.IsEnabled = false;
                passwordTextBox.IsEnabled = false;
                roleComboBox.IsEnabled = false;
            }
        }

        private void FilledComboBoxEnabledCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            isEditable(true);
        }

        private void updateButton_Click(object sender, RoutedEventArgs e)
        {
            string name = nameTextBox.Text;
            string address = addressTextBox.Text;
            string telephone = telephoneTextBox.Text;
            string officeAddress = officeAddressTextBox.Text;
            string phoneExt = phoneExtTextBox.Text;
            string username = usernameTextBox.Text;
            string password = passwordTextBox.Text;
            string role = roleComboBox.Text;


            ed.Name = name;
            ed.Address = address;
            ed.Telephone = telephone;
            ed.OfficeAddress = officeAddress;
            ed.PhoneExtensionNumber = phoneExt;
            ed.Password = password;
            List<EmployeeDetails> emp = new();
            emp.Add(ed);
            DAO.updatePesonal(emp);
            MessageBox.Show("Updated Successfully");
        }
    }
}
