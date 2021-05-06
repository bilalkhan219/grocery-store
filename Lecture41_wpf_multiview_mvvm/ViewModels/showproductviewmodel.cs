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
    class showproductviewmodel:BaseViewModel
    {
        public ObservableCollection<product> productlist { get; set; }
        public productservice showservice;
        public showproductviewmodel()
        {
            productlist = new ObservableCollection<product>();
            showservice = new productservice();
            productlist = showservice.getproducts();
        }
        
    }

}
