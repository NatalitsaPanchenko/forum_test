using forum_test.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace forum_test.Controllers
{
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
        public string AddTopic(forum_test.Models.Topic topic)
        {
            var user = topic.UserId;
            topic.CreatedAt = DateTime.Now;
            db.Topics.Add(topic);
            db.SaveChanges();
            return user + "- The topic \"" + topic.Title + "\" has been created!";
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