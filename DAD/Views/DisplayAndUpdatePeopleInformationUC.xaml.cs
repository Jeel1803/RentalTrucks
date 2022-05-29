using DAD.Models;
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
    /// Interaction logic for DisplayAndUpdateCustomerInformationUC.xaml
    /// </summary>
    public partial class DisplayAndUpdateCustomerInformationUC : UserControl
    {
        public DisplayAndUpdateCustomerInformationUC()
        {
            InitializeComponent();
            searchCustomerButton.Visibility = Visibility.Hidden;
            idComboBox.ItemsSource = DAO.GetPersonID();
            idComboBox.DisplayMemberPath = "PersonId";
            idComboBox.SelectedValuePath = "PersonId";

            customerDataGrid.BorderBrush = new SolidColorBrush(Colors.White);
            customerDataGrid.BorderThickness = new Thickness(1,1, 1, 1);
        }

       

        private void showAllCustomerButton_Click(object sender, RoutedEventArgs e)
        {
            customerDataGrid.ItemsSource =  DAO.getPeople();
        }

        private void searchCustomerButton_Click(object sender, RoutedEventArgs e)
        {
            int id = int.Parse(idComboBox.Text);
            if (idComboBox.SelectedIndex == -1)
            {
                idComboBox.BorderBrush = Brushes.Red;
            }
            else
            {
                idComboBox.BorderBrush = Brushes.Black;
                 customerDataGrid.ItemsSource = DAO.getPeople(id);
            }

        }

        

        private void ClearFilledComboBox_Click(object sender, RoutedEventArgs e)
        {
            idComboBox.SelectedIndex = -1;
        }

        private void FilledComboBoxEnabledCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            searchCustomerButton.Visibility = Visibility.Visible;
        }
    }
}
