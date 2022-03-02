using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using UserRegistrationmodel.Models;

namespace UserRegistrationmodel.ADO.DAO
{
    public class Crud
    {
        private SqlCommand cmd;
        SqlConnection connection;
        private userdata data;
        List<userdata> listData;
        private string connectionString()
        {
            string con = ConfigurationManager.ConnectionStrings["linqsample1Entities"].ConnectionString;
            return con;
        }
        private void openConnection(string query)
        {
             connection = new SqlConnection(connectionString());
            cmd = new SqlCommand(query, connection);
            connection.Open();
        }
        public List<userdata> Read(string tableName)
        {
            listData = new List<userdata>();
            data = new userdata();
            string query = "select * from " + tableName;
            openConnection(query);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                data.userFirstName = dr["userFirstName"].ToString();
                data.userFirstName = dr["userLastName"].ToString();
                data.username = dr["username"].ToString();
                data.userPassword = dr["userPassword"].ToString();
                listData.Add(data);
            }
            connection.Close();
            return listData;

        }
        public void Create(userdata data,string tablename)
        {
            string query = "insert into " + tablename+ "(username,userPassword,userFirstName,userLastName)" + " values ('" + data.username + "','" + data.userPassword + "','" + data.userFirstName + "','" + data.userLastName + "')";
            openConnection(query);
            cmd.ExecuteNonQuery();
            connection.Close();
        }
    }
}