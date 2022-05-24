﻿using DAD.Models.DB;
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
            string message = null;
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
    }
}