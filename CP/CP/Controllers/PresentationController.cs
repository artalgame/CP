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
        public ActionResult NewPresentation(BeginPresentationModel newPresentation)
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

                    TempData.Add("currentPresentationId", currentPresentation.PresentationId);
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
                Content = CP.Models.Content.GetFromContentModel(newSlide.ContentOfSlide),
                Title = Title.CreateFromTitleModel(newSlide.TitleOfSlide),
                SlideNumber = newSlide.SlideNumber,
                SlideId = Guid.NewGuid(),
                FonColor = newSlide.FonColor,
                PresentationId = newSlide.PresentationId
            });
            db.SaveChanges();
            newSlide.SlideNumber++;
            return View(newSlide);
        }

        public ActionResult CreateSlide()
        {
            var currentPresentationId = TempData["currentPresentationId"];
            var newSlide = new SlideModel();
            if (currentPresentationId != null)
            {
                newSlide.PresentationId = (Guid)currentPresentationId;
            }
            newSlide.SlideNumber = 1;
            return View(newSlide);
        }

        public ActionResult FinishPresentation()
        {
            return RedirectToAction("AllUserPresentation");
        }

        [HttpGet]
        public ActionResult SelectPresentation(string id)
        {
            var db = new SimPresEntities();
            Guid presentationGuid = Guid.Parse(id);
            var presentation = db.Presentations.SingleOrDefault(x => x.PresentationId == presentationGuid);

            if (presentation != null)
            {
                var createdPresentation = new CreatedPresentationModel();
                var presentationProperties = BeginPresentationModel.CreateFromPresentation(presentation);
                List<SlideModel> slides = new List<SlideModel>();
                foreach (var slide in presentation.Slides)
                {
                    slides.Add(SlideModel.GetSlideModelFromDBSlide(slide));
                }
                createdPresentation.PresentationProperties = presentationProperties;
                createdPresentation.Slides = slides.OrderBy(x=>x.SlideNumber).ToList();

                return View(createdPresentation);
            }
            else
            {
                return View();
            }
        }
    }
}
