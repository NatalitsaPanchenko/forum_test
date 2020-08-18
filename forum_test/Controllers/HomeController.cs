using forum_test.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace forum_test.Controllers
{
    public class HomeController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();
        public ActionResult Index() 
        {
            var topics = db.Topics;
            ViewBag.Topics = topics;
            return View();
        }
    }
}