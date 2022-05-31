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
    /// Interaction logic for ViewAndUpdateCustomerInformation.xaml
    /// </summary>
    public partial class ViewAndUpdateCustomerInformation : UserControl
    {
        TruckPerson ed = new TruckPerson();
        CustomerDetails emd = new();

        public ViewAndUpdateCustomerInformation()
        {
            InitializeComponent();
            isFieldVisible(false);
            errorLabel.Visibility = Visibility.Hidden;
            isVisibleIDInputs(false);
            detailsDataGrid.Visibility = Visibility.Hidden;
        }
        private void isFieldVisible(bool v)
        {
            if (v)
            {

                nameTextBox.Visibility = Visibility.Visible;
                addressTextBox.Visibility = Visibility.Visible;
                telephoneTextBox.Visibility = Visibility.Visible;
                ageTextBox.Visibility = Visibility.Visible;
                lcTextBox.Visibility = Visibility.Visible;
                expiryTextBox.Visibility = Visibility.Visible;
                updateButoon.Visibility = Visibility.Visible;



            }
            else
            {

                nameTextBox.Visibility = Visibility.Hidden;
                addressTextBox.Visibility = Visibility.Hidden;
                telephoneTextBox.Visibility = Visibility.Hidden;
                ageTextBox.Visibility = Visibility.Hidden;
                lcTextBox.Visibility = Visibility.Hidden;
                expiryTextBox.Visibility = Visibility.Hidden;
                updateButoon.Visibility = Visibility.Hidden;


            }
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
        private void SearchID_Click(object sender, RoutedEventArgs e)
        {
            emd = DAO.fetchCustomerInfo().FirstOrDefault();
            if (idComboBox.SelectedIndex == -1)
            {
                idComboBox.BorderBrush = Brushes.Red;
                errorLabel.Visibility = Visibility.Visible;
            }
            else
            {
                int id = int.Parse(idComboBox.Text);
                errorLabel.Visibility= Visibility.Hidden;
                idComboBox.BorderBrush = Brushes.Black;
                TruckPerson p = DAO.searchCustomerByID(id);
                isFieldVisible(true);
                if (p != null)
                {
                    addressTextBox.Text = p.Address;
                    telephoneTextBox.Text = p.Telephone;
                    nameTextBox.Text = p.Name;
                    ageTextBox.Text = p.TruckCustomer.Age.ToString();
                    lcTextBox.Text = p.TruckCustomer.LicenseNumber;
                    expiryTextBox.Text = p.TruckCustomer.LicenseExpiryDate.ToString();

                }

            }

        }

        private void searchCustomerButton_Click(object sender, RoutedEventArgs e)
        {
            isVisibleIDInputs(true);
            isFieldVisible(false);
            idComboBox.ItemsSource = DAO.GetCustomerID();
            idComboBox.DisplayMemberPath = "CustomerId";
            idComboBox.SelectedValuePath = "CustomerId";
        }

        private void searchAllCustomerButton_Click(object sender, RoutedEventArgs e)
        {
            detailsDataGrid.Visibility= Visibility.Visible;
            detailsDataGrid.ItemsSource = DAO.GetCustomer();

        }

        private void updateButoon_Click(object sender, RoutedEventArgs e)
        {
            int output = DAO.validEmptyInput(formGrid);
            if (output != 0)
            {
                MessageBox.Show("Enter Missing val");
            }
            else
            {
                int id = int.Parse(idComboBox.Text);
                ed = DAO.searchCustomerByID(id);

                string name = nameTextBox.Text;
                string address = addressTextBox.Text;
                string telephone = telephoneTextBox.Text;
                int age = int.Parse(ageTextBox.Text);
                string lc = lcTextBox.Text;
                //string date = DatePicker.selecteddate.value.date(expiryTextBox.Text);
                if (ed != null)
                {
                    ed.Name = name;
                    ed.Address = address;
                    ed.Telephone = telephone;
                    ed.TruckCustomer.Age = age;
                    ed.TruckCustomer.LicenseNumber = lc;
                    DAO.updateCustomerRecord(ed);
                    MessageBox.Show("Customer Updated");
                }
            }
        }
    }
}
