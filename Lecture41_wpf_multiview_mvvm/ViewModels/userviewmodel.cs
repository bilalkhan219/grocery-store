using System;
using System.Collections.Generic;
using System.Text;
using wpfproject.Models;
using System.Windows;
using System.Windows.Controls;
using wpfproject.Commands;
using System.Collections.ObjectModel;
namespace wpfproject.ViewModels
{
    class userviewmodel : BaseViewModel
    {
        public string prodid { get; set; }
        public string prodquantity { get; set; }
        public ObservableCollection<product> selectedlist { get; set; }
        public ObservableCollection<product> productlist { get; set; }
        public productservice showservice;
        public DelegateCommand addtocartcmd { get; set; }
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
        public userviewmodel()
        {
            selectedlist = new ObservableCollection<product>();
            productlist = new ObservableCollection<product>();
            showservice = new productservice();
            productlist = showservice.getproducts();
            addtocartcmd = new DelegateCommand(addbtn, canexecute);
            UpdateViewCommand = new DelegateCommand(ViewSelector, canexecute);
        }
        public void addbtn(object o)
        {
            product p = new product();
            p = showservice.getproduct(prodid);
            if(p.ID == null)
            {
                MessageBox.Show("No product exists with the entered id");
            }
            else
            {
                if (p.Quantity >= System.Convert.ToInt32(prodquantity))
                {
                    string wquantity = (p.Quantity - (System.Convert.ToInt32(prodquantity))).ToString();
                    p.Quantity = System.Convert.ToInt32(prodquantity);
                    selectedlist.Add(p);
                    showservice.writeback(wquantity, prodid);
                    foreach(product pp in productlist)
                    {
                        if(pp.ID == System.Convert.ToInt32(prodid))
                        {
                            pp.Quantity -= System.Convert.ToInt32(prodquantity);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Entered quantity of product is not available");
                }
            }

        }
        public void ViewSelector(object o)
        {
            if (o.ToString() == "recipt")
            {
                SelectedViewModel = new reciptviewmodel(selectedlist);
            }
            if (o.ToString() == "logout")
            {
                System.Environment.Exit(0);
            }
        }
        public bool canexecute(object o)
        {
            return true;
        }
    }
}
