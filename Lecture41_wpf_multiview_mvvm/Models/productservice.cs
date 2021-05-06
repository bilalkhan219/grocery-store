using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Microsoft.Data.SqlClient;
using System.Collections.ObjectModel;

namespace wpfproject.Models
{
    class productservice
    {
        string conString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=productsDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        public bool addintoDB(product p)
        {
            SqlConnection connection = new SqlConnection(conString);
            connection.Open();
            string query = $"insert into products (Id, Name, Price, Quantity) values ('{p.ID}','{p.Name}','{p.Price}','{p.Quantity}')";
            SqlCommand cmd = new SqlCommand(query, connection);
            int i = cmd.ExecuteNonQuery();
            if (i >= 1)
            {
                connection.Close();
                return true;
            }
            else
            {
                connection.Close();
                return false;
            }
        }
        public bool deletefromDB(int ID)
        {
            SqlConnection connection = new SqlConnection(conString);
            connection.Open();
            string query = $"delete from products where Id  = '{ID}'";
            SqlCommand cmd = new SqlCommand(query, connection);
            int i = cmd.ExecuteNonQuery();
            if (i >= 1)
            {
                connection.Close();
                return true;
            }
            else
            {
                connection.Close();
                return false;
            }
        }
        public bool addproduct(product p)
        {
            if (addintoDB(p))
            {
                return true;
            }
            else
            {
                return false;
            }

        }
        public bool removeproduct(int id)
        {
            if (deletefromDB(id))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public void showproducts()
        {

        }
        public List<int> getproductids()
        {
            List<int> list = new List<int>();
            SqlConnection connection = new SqlConnection(conString);
            connection.Open();
            string query = "select Id from products";
            SqlCommand cmd = new SqlCommand(query, connection);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                list.Add(System.Convert.ToInt32(dr[0]));
            }
            connection.Close();
            return list;
        }
        public ObservableCollection<product> getproducts()
        {
            ObservableCollection<product> list = new ObservableCollection<product>();
            SqlConnection connection = new SqlConnection(conString);
            connection.Open();
            string query = "select * from products";
            SqlCommand cmd = new SqlCommand(query, connection);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                product p = new product();
                p.ID = System.Convert.ToInt32(dr[0]);
                p.Name = dr[1].ToString();
                p.Price = System.Convert.ToInt32(dr[2]);
                p.Quantity = System.Convert.ToInt32(dr[3]);
                list.Add(p);
            }
            connection.Close();

            return list;
        }
        public product getproduct(string id)
        {
            product p = new product();
            SqlConnection connection = new SqlConnection(conString);
            connection.Open();
            string query = $"select * from products where Id={System.Convert.ToInt32(id)}";
            SqlCommand cmd = new SqlCommand(query, connection);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                p.ID = System.Convert.ToInt32(dr[0]);
                p.Name = dr[1].ToString();
                p.Price = System.Convert.ToInt32(dr[2]);
                p.Quantity = System.Convert.ToInt32(dr[3]);
            }
            connection.Close();

            return p;
        }
        public void writeback(string quantity,string id)
        {
            SqlConnection connection = new SqlConnection(conString);
            connection.Open();
            string query = $"update products set Quantity ='{System.Convert.ToInt32(quantity)}' where Id={System.Convert.ToInt32(id)}";
            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.ExecuteNonQuery();
        }
     }
}
