using Forum.Core.Models;
using Forum.DAL.ConcreteRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Forum.MVC.Controllers
{
    public class HomeController : Controller
    {
        private PostRepository postRepasitory = new PostRepository();
        public ActionResult Index()
        {
            var post = postRepasitory.AddPost(new Post() { Description = "aaa", ThreadId = 2, UserId = 1 });
            // var post = postRepasitory.GetPost(48);
            //var post = postRepasitory.GetAllPosts(1);
            //postRepasitory.DeletePost(49);

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}