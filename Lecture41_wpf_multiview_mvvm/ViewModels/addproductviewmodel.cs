using Lecture41_wpf_multiview_mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using wpfproject.Commands;
using wpfproject.Models;
namespace wpfproject.ViewModels
{
    class addproductviewmodel : BaseViewModel
    {

        public productservice service;
        public string ID { get; set; }
        public string NAME { get; set; }
        public string PRICE { get; set; }
        public string QUANTITY { get; set; }

        public DelegateCommand addcmd { get; set; }
        public addproductviewmodel()
        {
            service = new productservice();
            addcmd = new DelegateCommand(addbutton, canexecute);

        }
        public bool canexecute(object o)
        {

            if (string.IsNullOrEmpty(ID) || string.IsNullOrEmpty(NAME) || string.IsNullOrEmpty(PRICE) || string.IsNullOrEmpty(QUANTITY))
            {
                return false;
            }
            
            else
            {
                return true;

            }
        }
        public void addbutton(object o)
        {
            List<int> list = new List<int>();
            list = service.getproductids();
            product p = new product();
            try
            {
                p.ID = System.Convert.ToInt32(ID);
                p.Name = NAME.ToString();
                p.Price = System.Convert.ToInt32(PRICE);
                p.Quantity = System.Convert.ToInt32(QUANTITY);
                foreach(int i in list)
                {
                    if (i == p.ID)
                    {
                        MessageBox.Show("product already exist. Change product id");
                    }
                }
                if (service.addproduct(p))
                {
                    MessageBox.Show("Product Added Successfully");
                }
                else
                {
                    MessageBox.Show("Product not added! Try again");
                }
            }
            catch
            {
                MessageBox.Show("Product not added! Please check your formate and try again");
            }
            
            

        }
    }
}
