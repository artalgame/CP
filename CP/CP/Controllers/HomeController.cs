using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CP.Models;

namespace CP.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Message = "Welcome to ASP.NET MVC!";

            return View();
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult Users()
        {
            var allUsers = new AllUsers();
            allUsers.users = new SimPresEntities().Users.ToList<User>();
            return View(allUsers);
        }
    }
}
