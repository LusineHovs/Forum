using Forum.BLL;
using Forum.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Forum.Web.Controllers
{
    [Authorize]
    public class ThreadController : Controller
    {
        ThreadBL threadBL = new ThreadBL();
        PostBL postBL = new PostBL();
        UserBL userBL = new UserBL();

        // GET: Thread
        [AllowAnonymous]
        public ActionResult Index(int id)
        {
           var thread = threadBL.Get(id);
            var posts = postBL.GetAll(thread.Id);
            /* var userName = userBL.GetUserName(thread.Id);
             var lastPosts = posts.Where(c => c.ThreadId == thread.Id).OrderByDescending(a => a.Id).FirstOrDefault();*/

            //start
            List<ThreadViewModel> threadAll = new List<ThreadViewModel>();

            foreach (var post in posts)
            {
                 var userData = userBL.GetUserInfo(post.UserId);
                var postCount = postBL.GetPostsByUserCount(post.UserId);

                var postDescrip = post.Description; new List<Users>() { new Users() { UserName = "",AccessFailedCount = 12,City = "Some city",Id = "MyId"} } ;

                threadAll.Add(new ThreadViewModel() { Thread = thread, UserInfo = userData, Post = post });
            }
            //end

            //var threadViewModel = new ThreadViewModel() {
            //    Posts = posts,
            //    Thread = thread,
            //   // UserName = userName,
            //    //Postsdate = lastPosts.Date,
            //    //Count = posts.Count()
            //};
            //return View(threadViewModel);

            return View(threadAll);
        }

        public ActionResult Add(int topicId)
        {
            return View(new Thread());

        }
        [HttpPost]
        public RedirectToRouteResult Save(Thread newTread)
        {
            threadBL.Add(newTread);
            return RedirectToAction("Index", "Home");
        }


    }
}