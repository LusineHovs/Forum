using Forum.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forum.DAL.ConcreteRepositories
{
    public class TopicRepository : Repository<Topic>
    {
        public TopicRepository()
            : base()
        {
        }

        public void AddTopic(Topic topic)
        {
            var cmdText = $"INSERT INTO Topic(TopicName) VALUES('{topic.TopicName}'";
            AddEntity(cmdText);
        }

        public void DeleteTopic(int id)
        {
            var cmdText = $"DELETE FROM Topic WHERE Id = {id}";
            DeleteEntity(cmdText);
        }

        public Topic GetTopic(int id)
        {
            var cmdText = $"SELECT * FROM Topic WHERE Id = {id}";
            var topic = GetEntity(cmdText);
            return topic;
        }

        public List<Topic> GetAllTopics()
        {
            var cmdText = $"SELECT * FROM Topic";
            var topics = GetAll(cmdText);
            return topics.ToList();
        }
    }
}
