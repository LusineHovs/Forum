using Forum.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forum.DAL.ConcreteRepositories
{
    public class ThreadRepository : Repository<Thread>
    {

        public ThreadRepository()
            : base()
        {

        }

        public void AddThread(Thread thread)
        {
            var cmdText = $"INSERT INTO Thread(ThreadName, Description, TopicId ) VALUES('{thread.ThreadName}', '{thread.Description}', '{thread.TopicId}') ";
            AddEntity(cmdText);
        }
        public void DeleteThread(int id)
        {
            var cmdText = $"DELETE FROM Thread WHERE Id = {id}";
            DeleteEntity(cmdText);
        }

        public Thread GetThread(int id)
        {
            var cmdText = $"SELECT * FROM Thread WHERE Id = {id}";
            var thread = GetEntity(cmdText);
            return thread;
        }

        public List<Thread> GetAllThreads(int topicId)
        {
            var cmdText = $"SELECT * FROM Thread WHERE TopicId={topicId}";
            var threads = GetAll(cmdText);
            return threads.ToList();
        }




        //Gets the last posted in Thread name in the given Topic
        public Thread GetLastPostedThreadName(int topicId)
        {
            var cmdText = $"select * from Thread inner join Post on Thread.Id= Post.ThreadId where Thread.TopicId = {topicId} order by Post.Date desc";
            var thread = GetEntity(cmdText);

            return thread;
        }

        //Gets the posts' count in the given Topic
        public List<Thread> GetPostCountForTopic(int topicId)
        {
            var cmdText = $"select * from Thread inner join Post on Thread.Id= Post.ThreadId where Thread.TopicId = {topicId} ";
            var threads = GetAll(cmdText).ToList();
            return threads;
        }
    }
}
