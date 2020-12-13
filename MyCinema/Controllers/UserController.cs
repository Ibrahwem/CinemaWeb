using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyCinema.Models;
using System.Data.SqlClient;
namespace MyCinema.Controllers
{
    public class UserController : Controller
    {

        [HttpGet]
        public ActionResult AddOrEdit(int id=0)
        {
            User user = new User();
            return View(user);
        }
        [HttpPost]

        public ActionResult AddOrEdit(User userModel)
        {

            using (DbModel dbModel = new DbModel())
            {
                if (dbModel.Users.Any(x => x.username == userModel.username))
                {
                    ViewBag.DuplicateMessage = "Username already exist.";
                    return View("AddOrEdit", userModel);
                }
                dbModel.Users.Add(userModel);
                dbModel.SaveChanges();
            }
            ModelState.Clear();
            ViewBag.SuccessMessage = "Registeration Successful.";
            return View("AddOrEdit", new User());
        }

        

    }
}