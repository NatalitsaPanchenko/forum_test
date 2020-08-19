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

        public ActionResult Topic(int? id)
        {
            ViewBag.Topic = db.Topics.FirstOrDefault(x => x.Id == id);
            if (ViewBag.Topic == null)
            {
                return Redirect("/Forum/");
            }
            ViewBag.Articles = null;
            ViewBag.Articles = db.Articles.Where(x => x.TopicId == id);

            return View();
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

        [HttpGet]
        public ActionResult AddArticle(int topicID)
        {
            ViewBag.Topic = db.Topics.FirstOrDefault(x => x.Id == topicID);
            return View();
        }

        [HttpPost]
        public ActionResult AddArticle(string UserName, string Content, int topicId)
        {
            ApplicationUser user = db.Users.First(x => x.UserName == UserName);

            if (user == null)
            {
                return Redirect("/Login/");
            }

            Topic topic = db.Topics.FirstOrDefault(x => x.Id == topicId);

            if (topic == null)
            {
                return Redirect("/Forum/");
            }

            Article article = new Article 
            {
                Content = Content,
                TopicId = topicId,
                UserId = user.Id,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
            };

            db.Articles.Add(article);
            db.SaveChanges();

            return RedirectToAction("Article", new { articleID = article.Id, topicID = topicId });
        }

        public ActionResult Article(int? articleID, int? topicID)
        {
            ViewBag.article = db.Articles.FirstOrDefault(x => x.Id == articleID);
            ViewBag.topic = db.Topics.FirstOrDefault(x => x.Id == topicID);
            return View();
        }
        public ActionResult EditArticle(int? topicID, int? articleID)
        {
            ViewBag.article = db.Articles.FirstOrDefault(el => el.Id == articleID);
            return View();
        }
    }
}