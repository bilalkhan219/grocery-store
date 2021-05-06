using System;
using System.Collections.Generic;
using System.Text;
using wpfproject.Commands;

namespace wpfproject.ViewModels
{
    class adminviewmodel:BaseViewModel
    {
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
        public adminviewmodel()
        {

            UpdateViewCommand = new DelegateCommand(ViewSelector, canExecute);
        }

        public bool canExecute(object o)
        {
            return true;
        }

        public void ViewSelector(object o)
        {

            if ((o as string).Equals("Add"))
            {
                SelectedViewModel = new addproductviewmodel();
            }
            else if ((o as string).Equals("Delete"))
            {
                SelectedViewModel = new deleteproductviewmodel();
            }
            else if ((o as string).Equals("Show"))
            {
                SelectedViewModel = new showproductviewmodel();
            }
            else if ((o as string).Equals("Logout"))
            {
                System.Environment.Exit(0);
            }

        }
    }
}
