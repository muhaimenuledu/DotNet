using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Prototype1.Models;
using System.Data.SqlClient;
using System;
using Npgsql;
using System.Data;
using System.Text;
using MySql.Data;
using MySql.Data.MySqlClient;

using MySqlX.XDevAPI;
using MySqlX.XDevAPI.Common;
using MySqlX.XDevAPI.CRUD;
using UserProfile.Models;


namespace Prototype1.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        string connStr = "server=localhost;user=magento;database=dotnet;port=3306;password=magento";
        MySql.Data.MySqlClient.MySqlCommand cmd;
        MySqlConnection conn = new MySqlConnection(connStr);
        cmd = new MySql.Data.MySqlClient.MySqlCommand();

        try
        {
            Console.WriteLine("Connecting to MySQL...");
            conn.Open();
            cmd.Connection = conn;

            //***
            cmd.CommandText = "INSERT INTO demo VALUES(@Name, @ID, @Address, @Email)";
            cmd.Prepare();

            cmd.Parameters.AddWithValue("@Name", "One");
            cmd.Parameters.AddWithValue("@ID", "Two");
            cmd.Parameters.AddWithValue("@Address", "One");
            cmd.Parameters.AddWithValue("@Email", "Two");

            for (int i = 1; i <= 0; i++)
            {
                cmd.Parameters["@Name"].Value = "Muhaimenul" + i;
                cmd.Parameters["@ID"].Value = "mh" + i;
                cmd.Parameters["@Address"].Value = "House NO:" + i;
                cmd.Parameters["@Email"].Value = "muhaimenul" + i + "@gmail.com";

                cmd.ExecuteNonQuery();
            }

            conn.Close();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.ToString());
        }
        Console.WriteLine("Done.");

        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    //This function is responsible to get the view page to the UI 
    public IActionResult Employee()
    {


        string connStr = "server=localhost;user=magento;database=dotnet;port=3306;password=magento";
        MySql.Data.MySqlClient.MySqlCommand cmd;
        MySqlConnection conn = new MySqlConnection(connStr);
        cmd = new MySql.Data.MySqlClient.MySqlCommand();

        try
        {
            Console.WriteLine("Connecting to MySQL...");
            conn.Open();
            cmd.Connection = conn;

            //***
            // cmd.CommandText = "INSERT INTO demo VALUES(@Name, @ID, @Address, @Email)";
            cmd.CommandText = "SELECT * FROM  demo";
            cmd.Prepare();
            using (var reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    // Console.WriteLine(reader["Name"]);
                    // Console.WriteLine(reader["Address"]);
                }

            }
            // cmd.Parameters.AddWithValue("@Name", 1);
            // cmd.Parameters.AddWithValue("@ID", 1);
            // cmd.Parameters.AddWithValue("@Address", "One");
            // cmd.Parameters.AddWithValue("@Email", "Two");

            // for (int i = 10; i <= 12; i++)
            // {
            //     cmd.Parameters["@Name"].Value = i;
            //     cmd.Parameters["@ID"].Value = i;
            //     cmd.Parameters["@Address"].Value = "House NO:" + i;
            //     cmd.Parameters["@Email"].Value = "newuser" + i + "@gmail.com";

            //     cmd.ExecuteNonQuery();
            // }

            // conn.Close();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.ToString());
        }
        Console.WriteLine("Done.");

        return View();
    }
    public IActionResult EmployeeList()
    {
        return View();
    }
    public IActionResult Create()
    {
        return View();
    }



    public IActionResult Profile()
    {
        return View();
    }
    [HttpPost]
    public IActionResult GetDetails()
    {
        UserDataModel umodel = new UserDataModel();
        umodel.Name = HttpContext.Request.Form["txtName"].ToString();
        // umodel.ID = Convert.ToInt32(HttpContext.Request.Form["txtID"]);
        umodel.Address = HttpContext.Request.Form["txtAddress"].ToString();
        umodel.Email = HttpContext.Request.Form["txtEmail"].ToString();
        int result = umodel.SaveDetails();
        if (result > 0)
        {
            ViewBag.Result = "Data Saved Successfully";
        }
        else
        {
            ViewBag.Result = "Something Went Wrong";
        }
        return View("Profile");
    }


    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
