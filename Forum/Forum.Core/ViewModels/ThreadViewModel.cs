using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forum.Core.Models
{
    public class ThreadViewModel
    {
        public ThreadViewModel()
        {
           // Posts = new List<Post>();
        }

        //UsefullInfo
        public Thread Thread { get; set; }
        public Post Post { get; set; }
        public Users UserInfo { get; set; }



        public string UserName { get; set; }
        public string Postsdate { get; set; }
        public int Count { get; set; }
       
    }
}
