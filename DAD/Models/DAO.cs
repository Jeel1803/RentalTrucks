using DAD.Models.DB;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;

namespace DAD.Models
{
    internal class DAO
    {
        public static void updateEmployeeRecord( TruckPerson p)
        {
            using (DAD_JeelContext ctx = new DAD_JeelContext())
            {
                ctx.Entry(p).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                ctx.Entry(p.TruckEmployee).State = Microsoft.EntityFrameworkCore.EntityState.Modified;

                ctx.SaveChanges();
            }
        }
        public static void updatePesonal(List<EmployeeDetails> data)
        {
            using (DAD_JeelContext ctx = new DAD_JeelContext())
            {
                foreach (EmployeeDetails bc in data)
                {
                    TruckPerson p = ctx.TruckPeople.Include(bt => bt.TruckEmployee).Where(b => b.TruckEmployee.Username == username).FirstOrDefault();
                    p.Address = bc.Address;
                    p.Telephone = bc.Telephone;
                    p.Name = bc.Name;
                    p.TruckEmployee.OfficeAddress = bc.OfficeAddress;
                    p.TruckEmployee.PhoneExtensionNumber = bc.PhoneExtensionNumber;
                    p.TruckEmployee.Password = bc.Password;
                    ctx.Entry(p).State = EntityState.Modified;
                    ctx.Entry(p.TruckEmployee).State = EntityState.Modified;
                    ctx.SaveChanges();
                }
            }
        }

        public static List<EmployeeDetails> fetchPersonalInfo()
        {
            using (DAD_JeelContext ctx = new DAD_JeelContext())
            {

                return ctx.TruckPeople.Include(bt => bt.TruckEmployee).Where(em => em.TruckEmployee.Username == username).Select(
                    bc => new EmployeeDetails()
                    {
                        PersonId = bc.PersonId,
                        EmployeeId = bc.TruckEmployee.EmployeeId,
                        Name = bc.Name,
                        Address = bc.Address,
                        Telephone = bc.Telephone,
                        OfficeAddress = bc.TruckEmployee.OfficeAddress,
                        PhoneExtensionNumber = bc.TruckEmployee.PhoneExtensionNumber,
                        Username = bc.TruckEmployee.Username,
                        Password = bc.TruckEmployee.Password,
                        Role = bc.TruckEmployee.Role,
                    }).ToList();


            }
        }

        public static void login(TruckEmployee truckEmployee)
        {
            using (DAD_JeelContext ctx = new DAD_JeelContext())
            {
                if (validUser(truckEmployee.Username, truckEmployee.Password))
                {
                    username = truckEmployee.Username;
                }
                else
                {
                    throw new Exception("Please enter correct username and password");
                }
            }
        }

        public static bool validUser(string username, string password)
        {
            using (DAD_JeelContext ctx = new DAD_JeelContext())
            {
                TruckEmployee employee = ctx.TruckEmployees.Where(em => em.Username == username).Where(ps => ps.Password == password).FirstOrDefault();
                if (employee == null)
                {
                    return false;
                }
                else
                {
                    return true;
                }

            }
        }
        public static TruckPerson searchCustomerByID(int id)
        {
            using (DAD_JeelContext ctx = new DAD_JeelContext())
            {
                return ctx.TruckPeople.Include(p => p.TruckCustomer).Where(em => em.PersonId == id).FirstOrDefault();
            }
        }
        public static TruckPerson searchEmployeeByID(int id)
        {
            using (DAD_JeelContext ctx = new DAD_JeelContext())
            {
                return ctx.TruckPeople.Include(p => p.TruckEmployee).Where(em => em.PersonId == id).FirstOrDefault();
            }
        }


        public static TruckEmployee searchPEmployeeByID(int id)
        {
            using (DAD_JeelContext ctx = new DAD_JeelContext())
            {
                return ctx.TruckEmployees.Include(p => p.Employee).Where(em => em.Employee.PersonId == id).FirstOrDefault();
            }
        }

        public static List<PersonInformation> getPeople()
        {
            using (DAD_JeelContext ctx = new DAD_JeelContext())
            {
                return ctx.TruckPeople.Select(p => new PersonInformation()
                {
                    PersonId = p.PersonId,
                    Address = p.Address,
                    Name = p.Name,
                    Telephone = p.Telephone,
                }).ToList(); 
            }
        }
        public static List<EmployeeDetails> GetEmployee()
        {
            using (DAD_JeelContext ctx = new DAD_JeelContext())
            {
                return ctx.TruckEmployees.Include(em => em.Employee).Select(p => new EmployeeDetails()
                {
                    EmployeeId = p.EmployeeId,
                    Name = p.Employee.Name,
                    Telephone = p.Employee.Telephone,
                    Address = p.Employee.Address,
                    PersonId = p.Employee.PersonId,
                    Username = p.Username,
                    Password = p.Password,
                    OfficeAddress = p.OfficeAddress,
                    Role = p.Role,
                    PhoneExtensionNumber = p.PhoneExtensionNumber,

                }).ToList();
            }
        }
        public static List<CustomerDetails> GetCustomer()
        {
            using (DAD_JeelContext ctx = new DAD_JeelContext())
            {
                return ctx.TruckCustomers.Include(c => c.Customer).Select(p => new CustomerDetails()
                {
                    Name = p.Customer.Name,
                    Telephone = p.Customer.Telephone,
                    Address = p.Customer.Address,
                    PersonId = p.Customer.PersonId,
                    Age = p.Age,
                    CustomerId = p.CustomerId,
                    LicenseExpiryDate = p.LicenseExpiryDate,
                    LicenseNumber = p.LicenseNumber,
                }).ToList();
            }
        }

        public static List<TruckPerson> GetPersonID()
        {
            using (DAD_JeelContext ctx = new DAD_JeelContext())
            {
                return ctx.TruckPeople.ToList();
            }
        }
        private static bool containsUserName(string username)
        {
            using (DAD_JeelContext ctx = new DAD_JeelContext())
            {
                TruckEmployee truckEmployee = ctx.TruckEmployees.Where(em => em.Username == username).FirstOrDefault();
                if (truckEmployee == null)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
        }
        public static string username;
        public static void addEmployee(TruckEmployee truckEmployee)
        {
            using (DAD_JeelContext ctx = new DAD_JeelContext())
            {
                if (!containsUserName(truckEmployee.Username))
                {
                    ctx.TruckEmployees.Add(truckEmployee);
                    ctx.SaveChanges();
                }

                else
                {
                    throw new Exception("Please choose another username");
                }
            }
        }

        public static int validEmptyInput(Grid data)
        {
            int count = 0;
            foreach (Control ctl in data.Children)
            {
                if (ctl.GetType() == typeof(TextBox))
                {
                    TextBox tb = (TextBox)ctl;
                    if (tb.Text.Length == 0)
                    {
                       
                       tb.BorderBrush = Brushes.Red;
                        count = 1;
                    }
                    else
                    {
                        tb.BorderBrush = Brushes.Black;
                    }
                }
            }
            return count;

        }

        public static int comboBox(Grid data)
        {
            int a = 0;
            foreach (Control ctl in data.Children)
            {
                if (ctl.GetType() == typeof(ComboBox))
                {
                    ComboBox cb = (ComboBox)ctl;
                    if(cb.SelectedIndex == -1)
                    {
                        cb.BorderBrush = Brushes.Red;
                        a = 1;
                    }
                }
            }
            return a;
        }

        public static List<PersonInformation> getPeople(int id)
        {
            using (DAD_JeelContext ctx = new DAD_JeelContext())
            {
                return ctx.TruckPeople.Where(bt => bt.PersonId == id).Select(p => new PersonInformation()
                {
                    PersonId = p.PersonId,
                    Address = p.Address,
                    Name = p.Name,
                    Telephone = p.Telephone,
                }).ToList();
            }
        }
    }
}
