using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forum.Core.Models
{
    public class TopicThreadViewModel
    {
        public TopicThreadViewModel()
        {
            Posts = new List<Post>();
        }

    
        public Thread Thread { get; set; }
        public Topic Topic { get; set; }

        public List<Post> Posts { get; set; }
        [Display(Name = "Last posted by")]
        public string UserName { get; set; }
        [Display(Name = "Last posted on")]
        public string Postsdate { get; set; }
        [Display(Name = "Replies")]
        public int Count { get; set; }
    }
}
