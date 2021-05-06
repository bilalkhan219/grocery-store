using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using wpfproject.Commands;
using wpfproject.Models;

namespace wpfproject.ViewModels
{
    class deleteproductviewmodel:BaseViewModel
    {
        public productservice delservice;
        public string IDdel { get; set; }
        public DelegateCommand delcmd { get; set; }
        public deleteproductviewmodel()
        {
            delservice = new productservice();
            delcmd = new DelegateCommand(delbutton, canexecute);
        }
        public bool canexecute(object o)
        {
            if (string.IsNullOrEmpty(IDdel))
            {
                return false;
            }
            else
            {
                return true;
            }
            
        }
        public void delbutton(object o)
        {
            int id;
            try
            {
                id = System.Convert.ToInt32(IDdel);
            if (delservice.removeproduct(id))
                {
                    MessageBox.Show("Product deleted Successfuly");
                }
                else
                {
                    MessageBox.Show("No product available having the entered ID number");
                }
            }
            catch
            {
                MessageBox.Show("Invalid ID entered. Please enter an integer number and try again");
            }

        }
    }
}
