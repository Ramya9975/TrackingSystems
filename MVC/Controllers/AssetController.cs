using MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Data.SqlClient;

using System.Web.UI.WebControls;

namespace MVC.Controllers
{
    public class AssetController : Controller
    {
        SqlConnection connection = new SqlConnection();
        SqlCommand command = new SqlCommand();
        SqlDataReader dataReader;


        // GET: Asset
        [HttpGet]
        public ActionResult MVC()
        {
         return View();
        }
        void connectionString()
        {
            connection.ConnectionString = "data source = NLTI159\\SQLEXPRESS; database = AssetTracking; Integrated security = true;";
        }
        [HttpPost]
        public ActionResult verify(Models.Login login) 
        {
            connectionString();
            connection.Open();
            command.Connection = connection;
            command.CommandText = "select * from Login where UserName = '" + login.UserName +"'and Password= '" +login.Password + "'";
            dataReader = command.ExecuteReader();
            if(dataReader.Read())
            {
                
                connection.Close();
                return View("Create");
            }
            else
            {
                connection.Close();
                return View("Error");
            }
            

           

        }
      
    }
}

        