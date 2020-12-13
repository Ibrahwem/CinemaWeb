using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.SqlClient;
using MyCinema.Models;

namespace MyCinema.Controllers
{
    public class accountController : Controller
    {
        SqlConnection con = new SqlConnection("Data Source=IBRAHEMA98W\\MSSQLSERVER01;Initial Catalog=tempdb;Integrated Security=True;");

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Verify(Account acc)
        {
            string check = " select count(*) from [User] where username ='" + acc.username + "'and password= '" + acc.password + "' ";
            SqlCommand com = new SqlCommand(check, con);
            con.Open();
            int temp = Convert.ToInt32(com.ExecuteScalar().ToString());
            con.Close();

            if (temp == 1)
            {
                return View("Successful");
            }
            else
            {
                ViewBag.DuplicateMessage = "Wrong Username or password.";
                return View("Login");
            }
        }
    }
}