using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forum.Core.Models
{
    public class Thread
    {
        //public Thread()
        //{
        //    Posts = new List<Post>();
        //}
        public int Id { get; set; }
        public string ThreadName { get; set; }
        public string Description { get; set; }
        public int TopicId { get; set; }
        //public List<Post> Posts { get; set; }
    }
}
