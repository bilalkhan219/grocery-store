using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using wpfproject.Commands;
using wpfproject.Models;
using System.Collections.ObjectModel;



namespace wpfproject.ViewModels
{
    class customerviewmodel : BaseViewModel
    {
        public string luname { get; set; }
        public string lpassword { get; set; }
        public string suname { get; set; }
        public string spassword { get; set; }
        public string sphone { get; set; }
        public userservice uservice;

        private BaseViewModel selectedViewModel;

        public BaseViewModel SelectedViewModel
        {
            get { return selectedViewModel; }
            set
            {
                selectedViewModel = value;
                OnPropertyChanged("SelectedViewModel");
            }
        }

        public DelegateCommand UpdateViewCommand { get; set; }
        public DelegateCommand signupcommand { get; set; }
        public customerviewmodel()
        {
            uservice = new userservice();
            UpdateViewCommand = new DelegateCommand(ViewSelector, canExecute);
            signupcommand = new DelegateCommand(signupbutton, canexecutes);
        }

        public bool validate(string password)
        {
            
            ObservableCollection<user> list = new ObservableCollection<user>();
            list = uservice.getuserdata();
            foreach (user u in list)
            {
                if (u.Uname == luname && u.Password == password)
                {
                    return true;
                }
            }
            return false;
        }
        public bool canExecute(object o)
        {
            var data = o as object[];
            var pass = data[0] as PasswordBox;
            var win = data[1] as Window;
                if (string.IsNullOrEmpty(luname) || string.IsNullOrEmpty(pass.Password))
                {
                    return false;
                }
                else
                {
                    return true;
                }
           
        }

        public void ViewSelector(object o)
        {
            var data = o as object[];
            var pass = data[0] as PasswordBox;
            if (validate(pass.Password))
            {
                SelectedViewModel = new userviewmodel();
            }
            else
            {
                MessageBox.Show("Invalid username or password");
            }
        }

        public void signupbutton(object o)
        {
            var data = o as object[];
            var pass = data[0] as PasswordBox;
            ObservableCollection<user> list = new ObservableCollection<user>();
            list = uservice.getuserdata();
            user us = new user();
            try
            {
                us.Uname = suname;
                us.Password = pass.Password;
                foreach (user u in list)
                {
                    if (u.Uname == us.Uname)
                    {
                        MessageBox.Show("Username Already Exists. Enter some other Username");
                    }
                }
                if (uservice.adduser(us))
                {
                    MessageBox.Show("user successfully added");
                }
                else
                {
                    MessageBox.Show("User not Added! Try Again");
                }
            }
            catch
            {
            }
        }
        public bool canexecutes(object o)
        {
            var data = o as object[];
            var pass = data[0] as PasswordBox;
            if (string.IsNullOrEmpty(suname) || string.IsNullOrEmpty(pass.Password) || string.IsNullOrEmpty(sphone))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

    }
}
