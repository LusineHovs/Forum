using Forum.Core;
using Forum.Core.Models;
using Forum.DAL.ConcreteRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forum.BLL
{
    public class ThreadBL : IThreadBL
    {
        ThreadRepository threadRepo;
        public ThreadBL()
        {
            threadRepo = new ThreadRepository();
        }
        public void Add(Thread thread)
        {
            threadRepo.AddThread(thread);
        }
        public void Delete(int id)
        {
            threadRepo.DeleteThread(id);
        }
        public Thread Get(int id)
        {
            var entity = threadRepo.GetThread(id);
            return entity;
        }
        public List<Thread> GetAll(int topicId)
        {
            var entities = threadRepo.GetAllThreads(topicId);
            return entities;
        }




        //Gets the last posted in Thread name in the given Topic
        public string LastPostedThreadName(int topicId)
        {
            var thread = threadRepo.GetLastPostedThreadName(topicId);

            var threadName = "";
            if (thread != null)
            {
                threadName = thread.ThreadName;
            }
            else
            {
                threadName = "Threads have no posts";
            }
            return threadName;
        }

        //Gets the posts' count in the given Topic
        public int PostCountForTopic(int topicId)
        {
            var threads = threadRepo.GetPostCountForTopic(topicId);
            var postCount = threads.Count;
            return postCount;
        }
    }
}
