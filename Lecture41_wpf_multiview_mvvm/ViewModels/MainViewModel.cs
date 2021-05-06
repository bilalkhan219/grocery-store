using System;
using System.Collections.Generic;
using System.Text;
using wpfproject.Commands;

namespace wpfproject.ViewModels
{
    class MainViewModel:BaseViewModel
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
        public MainViewModel()
        {

            UpdateViewCommand = new DelegateCommand(ViewSelector, canExecute);
        }

        public bool canExecute(object o)
        {
            return true;
        }

        public void ViewSelector(object o)
        {

            if ((o as string).Equals("Admin"))
            {
                SelectedViewModel = new adminviewmodel();
            }
            else if ((o as string).Equals("Customer"))
            {
                SelectedViewModel = new customerviewmodel();
            }

        }
    }
}
