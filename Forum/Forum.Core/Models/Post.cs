using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forum.Core.Models
{
    public class Post
    {
        public int Id { get; set; }

        [Display(Name = "Post description")]
        public string Description { get; set; }
        public string UserId { get; set; }
        public int ThreadId { get; set; }
        public DateTime Date { get; set; }

    }
}
