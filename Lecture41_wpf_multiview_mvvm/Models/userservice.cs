using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace wpfproject.Models
{
    class userservice
    {
        string conString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=productsDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        public bool addintoDB(user u)
        {
            SqlConnection connection = new SqlConnection(conString);
            connection.Open();
            string query = $"insert into users (username,password) values ('{u.Uname}','{u.Password}')";
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
        public bool adduser(user u)
        {
            if (addintoDB(u))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public ObservableCollection<user> getuserdata()
        {
            ObservableCollection<user> list = new ObservableCollection<user>();
            SqlConnection connection = new SqlConnection(conString);
            connection.Open();
            string query = "select * from users";
            SqlCommand cmd = new SqlCommand(query, connection);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                user u = new user();
                u.Uname = dr[0].ToString();
                u.Password = dr[1].ToString();
                list.Add(u);
            }
            connection.Close();

            return list;
        }
    }
}
