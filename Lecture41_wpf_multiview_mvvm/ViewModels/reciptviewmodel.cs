using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.ObjectModel;
using wpfproject.Models;

namespace wpfproject.ViewModels
{
    class reciptviewmodel : BaseViewModel
    {
        public string totalcash { get; set; }
        public ObservableCollection<product> productlist { get; set; }
        public reciptviewmodel(ObservableCollection<product> list)
        {
            productlist = new ObservableCollection<product>();
            productlist = list;
            foreach(product p in list)
            {
                totalcash = (System.Convert.ToInt32(totalcash) + System.Convert.ToInt32(p.Price)*System.Convert.ToInt32(p.Quantity)).ToString();
            }
        }
        
    }
}
