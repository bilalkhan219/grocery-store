using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;

namespace wpfproject.Models
{
    class user : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propName)
        {

            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
            }
        }
        private string uname;

        public string Uname
        {
            get { return uname; }
            set { uname = value; OnPropertyChanged("Uname"); }
        }
        private string password;
       
        public string Password
        {
            get { return password; }
            set { password = value; OnPropertyChanged("Password"); }
        }


    }
}
