using Forum.BLL;
using Forum.Core.Models;
using Forum.DAL.ConcreteRepositories;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Forum.Web.Controllers
{
    [Authorize]
    public class PostsController : Controller
    {
        PostRepository postRepo = new PostRepository();
        PostBL postBL = new PostBL();
        UserBL userBL = new UserBL();

        // GET: Posts
        [AllowAnonymous]
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Reply(int threadId)
        {
            return View(new Post());

        }
        [HttpPost]
        public RedirectToRouteResult Save(Post post)
        {
            var email=  HttpContext.User.Identity.Name;
            post.UserId = userBL.GetIdbyUsername(email); 
            postBL.Add(post);
            return RedirectToAction("Index", "Thread", new { id = post.ThreadId });
        }
        
        public ActionResult AddPost()
        {
            //var post = postRepo.AddPost(new Post() { Description = "bbb", ThreadId = 2, UserId = new Guid("fca01054-5a6a-45c0-99de-2005e3d65281"), Date = new DateTime(2018, 06, 02) });
            //var post = postRepo.GetPost(48);
            //var post = postRepo.GetAllPosts(1);
            //postRepo.DeletePost(49);


            return View();
        }
    }
}