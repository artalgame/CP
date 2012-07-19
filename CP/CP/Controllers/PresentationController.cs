using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CP.Models;
using System.Web.Security;
using System.Web.Routing;

namespace CP.Controllers
{
    public class PresentationController : Controller
    {
        //
        // GET: /Presentation/

        public ActionResult NewPresentation()
        {
            return View();
        }

        [HttpPost]
        public ActionResult NewPresentation(PresentationModel newPresentation)
        {
            if (Request.IsAuthenticated)
            {
                var db = new SimPresEntities();
                var currentUser = db.Users.SingleOrDefault<User>(x => x.Login == User.Identity.Name);

                if (currentUser != null)
                {
                    newPresentation.UserId = currentUser.UserId;
                    newPresentation.PresentationId = Guid.NewGuid();
                    var currentPresentation = new Presentation()
                    {
                        DateOfCreate = DateTime.Now,
                        About = newPresentation.About,
                        Name = newPresentation.PresentationName,
                        PresentationId = newPresentation.PresentationId,
                        UserId = newPresentation.UserId
                    };
                    db.Presentations.AddObject(currentPresentation);
                    db.SaveChanges();

                    TempData.Add("currentPresentation", currentPresentation);
                    return RedirectToAction("CreateSlide", "Presentation");
                }
                else
                {
                    return RedirectToAction("Index", "Home");
                }
            }
            return View();
        }

        public ActionResult AllUserPresentation()
        {
            if (Request.IsAuthenticated)
            {
                var db = new SimPresEntities();
                var currentUser = db.Users.SingleOrDefault<User>(x => x.Login == User.Identity.Name);
                ViewBag.Presentations = currentUser.Presentations;
            }
            return View();
        }
        [HttpPost]
        public ActionResult CreateSlide(SlideModel newSlide)
        {
            var db = new SimPresEntities();
            db.Slides.AddObject(new Slide()
            {
                Content = newSlide.ContentOfSlide,
                Title = newSlide.TitleOfSlide,
                SlideNumber = newSlide.SlideNumber,
                SlideId = Guid.NewGuid(),
                FonColor = newSlide.FonColor,
                Presentation = newSlide.CurrentPresentation
            });
            db.SaveChanges();
            return View(newSlide);
        }

        public ActionResult CreateSlide()
        {
            var currentPresentation = TempData["currentPresentation"];
            var newSlide = new SlideModel();
            newSlide.CurrentPresentation = (Presentation)currentPresentation;
            newSlide.SlideNumber = 1;
            return View(newSlide);
        }
    }
}
