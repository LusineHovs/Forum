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
    public class TopicBL: ITopicBL
    {
        TopicRepository topicRepo;
        public TopicBL()
        {
            topicRepo = new TopicRepository();
        }

        public void Delete(int id)
        {
            topicRepo.DeleteTopic(id);
        }
        public Topic Get(int id)
        {
            var entity = topicRepo.GetTopic(id);
            return entity;
        }
        public List<Topic> GetAll()
        {
            var entities = topicRepo.GetAllTopics();
            return entities;
        }
    }
}
