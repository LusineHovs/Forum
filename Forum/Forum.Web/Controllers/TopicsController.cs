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
    public class TopicsController : Controller
    {
        TopicBL topicBL = new TopicBL();
        ThreadBL threadBL = new ThreadBL();
        UserBL userBL = new UserBL();
        PostBL postBL = new PostBL();

        // GET: Topics
        [AllowAnonymous]
        public ActionResult Index(int id)
        {
            var topic = topicBL.Get(id);
            var threads = threadBL.GetAll(id);
            List<TopicThreadViewModel> threadAll = new List<TopicThreadViewModel>();

            foreach (var thread in threads)
            {
               var username = userBL.GetUserName(thread.Id);
               var lastPostDate = postBL.LastPostedDate(thread.Id);
               var postCount = postBL.PostCountForThread(thread.Id);
                var userName = ""; 

                //var userName ="";
                //var threads = threadBL.GetAll(topic.Id).ToList().Select(x => new ThreadViewModel
                //{
                //    Thread = new Thread() { Id = x.Id, Description = x.Description, ThreadName = x.ThreadName, TopicId = x.TopicId },
                //    UserName = userName = userBL.GetUserName(x.Id),
                //    Postsdate = userName != "" ? postBL.LastPostedDate(x.Id) : "",
                //    Count = userName != "" ? postBL.PostCountForThread(x.Id) : 0

                if (username=="" && lastPostDate==""&&postCount==0)
                {
                    username = "no post yet";
                    lastPostDate = "";
                    postCount = 0;
                }
                threadAll.Add(new TopicThreadViewModel() {
                    Topic = topic,
                    Thread = thread,
                    UserName = userName = username,
                    Postsdate = userName != "" ? lastPostDate: "",
                    Count = userName != "" ? postCount : 0
                });
            }
            return View(threadAll);
        }
    }
}