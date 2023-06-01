using System.Data.SqlClient;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Prototype1.Models;
using MySql.Data.MySqlClient;
using UserProfile.Models;

namespace UserProfile.Models
{
    public class UserDataModel
    {
        public string Name { get; set; }
        public int ID { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }

        public int SaveDetails()
        {
            string connStr = "server=localhost;user=magento;database=dotnet;port=3306;password=magento";
            MySql.Data.MySqlClient.MySqlCommand cmd;
            MySqlConnection conn = new MySqlConnection(connStr);
            cmd = new MySql.Data.MySqlClient.MySqlCommand();
            conn.Open();
            cmd.Connection = conn;
            cmd.CommandText = "INSERT INTO demo VALUES('" + Name + "','" + ID + "','" + Address + "','" + Email + "')";
            cmd.Prepare();


            // SqlConnection con = new SqlConnection(GetConString.ConString());
            // string query = "INSERT INTO Profile(Name, Age, City) values ('" + Name + "','" + Age + "','" + City + "')";
            // SqlCommand cmd = new SqlCommand(query, con);
            // con.Open();
            int i = cmd.ExecuteNonQuery();
            conn.Close();
            return i;
        }
    }
}