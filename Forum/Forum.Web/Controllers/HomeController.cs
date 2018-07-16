using Forum.BLL;
using Forum.Core.Models;
using Forum.DAL.ConcreteRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Forum.Web.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private PostRepository postRepository = new PostRepository();
        private TopicRepository topicRepository = new TopicRepository();
        private ThreadRepository threadRepository = new ThreadRepository();
        TopicBL topicBL = new TopicBL();
        ThreadBL threadBL = new ThreadBL();
        UserBL userBL = new UserBL();
        PostBL postBL = new PostBL();

        [AllowAnonymous]
        public ActionResult Index()
        {
            var topics = topicBL.GetAll();
            var topicall = new List<TopicViewModel>();

            foreach (var topic in topics)
            {
                //start
                var lastThreadName = threadBL.LastPostedThreadName(topic.Id);
                var postedDate = postBL.GetPostedDate(topic.Id);
                var totalPostCount = threadBL.PostCountForTopic(topic.Id);

                topicall.Add(new TopicViewModel() { Topic = topic, LastPostThreadName = lastThreadName, PostedDate = postedDate, TotalPostCount=totalPostCount });
                //end


                //var userName ="";
                //var threads = threadBL.GetAll(topic.Id).ToList().Select(x => new ThreadViewModel
                //{
                //    Thread = new Thread() { Id = x.Id, Description = x.Description, ThreadName = x.ThreadName, TopicId = x.TopicId },
                //    UserName = userName = userBL.GetUserName(x.Id),
                //    Postsdate = userName != "" ? postBL.LastPostedDate(x.Id) : "",
                //    Count = userName != "" ? postBL.PostCountForThread(x.Id) : 0

                //});

                //topicall.Add(new TopicViewModel()
                //{
                //    Topic = topic,
                //    Threads = threads.ToList()
                //});
            }

            return View(topicall);



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