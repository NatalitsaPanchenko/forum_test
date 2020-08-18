using forum_test.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using static forum_test.Controllers.ManageController;

namespace forum_test.Controllers
{
    [Authorize]
    public class ForumController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();

        // GET: Forum
        public ForumController()
        {
        }

        public ActionResult Index()
        {
            return Redirect("/"); ;
        }

        [HttpGet]
        public ActionResult AddTopic()
        {
            return View();
        }
        
        [HttpPost]
        public ActionResult AddTopic(string UserName, string Title)
        {
            ApplicationUser user = db.Users.First(x => x.UserName == UserName);
            
            if (user == null)
            {
                return Redirect("/Login/");
            }

            Topic newTopic = db.Topics.FirstOrDefault(x => x.Title == Title);
            if ( newTopic != null || Title == "")
            {
                return RedirectToAction("AddTopic");
            }

            Topic topic = new Topic
            {
                CreatedAt = DateTime.Now,
                Title = Title,
                UserId = user.Id,
            };

            db.Topics.Add(topic);
            db.SaveChanges();

            return RedirectToAction("Index");
        }
        public ActionResult AddArticle()
        {
            return View();
        }

        public ActionResult EditArticle()
        {
            return View();
        }
    }
}