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
    /// Interaction logic for ViewPersonalDetailsUC.xaml
    /// </summary>
    public partial class ViewPersonalDetailsUC : UserControl
    {
        List<EmployeeDetails> data = null;
        EmployeeDetails ed = new EmployeeDetails();
        public ViewPersonalDetailsUC()
        {
            InitializeComponent();

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
    }
}
