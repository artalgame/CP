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
            List<Presentation> allPresentationList = new SimPresEntities().Presentations.OrderBy(x => x.DateOfCreate).ToList();
            allPresentationList.Reverse();
            ViewBag.NewPresentations = allPresentationList.Take(12).ToList();
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
