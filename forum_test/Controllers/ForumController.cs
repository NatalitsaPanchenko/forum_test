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
            return View();
        }

        [HttpGet]
        public ActionResult AddTopic()
        {
            return View();
        }
        
        [HttpPost]
        /*public ActionResult AddTopic(string UserName, string Title)
        {
            ApplicationUser user = db.Users.Find(UserName);
            string message;

            if (user == null)
            {
                message = "Error - user==null";
                return RedirectToAction("Login", new { Message = message });
            }
            if (db.Topics.Find(Title) == null)
            {
                message = "The Topic with such title has been existed!";
                return View(new { Message = message });
            }
            Topic topic = new Topic
            {
                CreatedAt = DateTime.Now,
                Title = Title,
                UserId = user.Id,
            };

            db.Topics.Add(topic);
            db.SaveChanges();
            message = UserName + "- The topic \"" + Title + "\" has been created!" + user.Id;

            return RedirectToAction("Home", new { Message = message });
        }*/

        public string AddTopic(string UserName, string Title)
        {
            string message;
            ApplicationUser user = db.Users.First(x => x.UserName == UserName);

            if (user == null)
            {
                message = "Error - user==null";
                return message;
            }

            Topic newTopic = db.Topics.FirstOrDefault(x => x.Title == Title);
            if ( newTopic != null)
            {
                message = "The Topic with such title has been existed!";
                return message;
            }

            Topic topic = new Topic
            {
                CreatedAt = DateTime.Now,
                Title = Title,
                UserId = user.Id,
            };

            db.Topics.Add(topic);
            db.SaveChanges();
            message = UserName + " - The topic \"" + Title + "\" has been created!!!!  ----- " + user.UserName + "; --email-- " + user.Email + "; --Id-- " + user.Id + "; --newTopic-- " + topic.Title;

            return message;
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