﻿using DAD.Models.DB;
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
