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
        }

       

        private void showAllCustomerButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void searchCustomerButton_Click(object sender, RoutedEventArgs e)
        {

            int id = int.Parse(idTextBox.Text);
            if (string.IsNullOrEmpty(idTextBox.Text))
            {
                MessageBox.Show("Please Enter the Person ID");
            }
            else
            {
                customerDataGrid.ItemsSource = DAO.getPeople(id);
            }
        }
    }
}
