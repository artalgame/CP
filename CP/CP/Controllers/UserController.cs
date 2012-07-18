using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CP.Controllers
{
    public class UserController : Controller
    {
        //
        // GET: /User/

        public ActionResult Index(long? id)
        {
            if (id == null)
            {
                throw new HttpException(404, "user not found!");
            }
            ViewData["userid"] = id;
            return View();
        }

    }
}
