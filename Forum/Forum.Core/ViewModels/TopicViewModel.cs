using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forum.Core.Models
{
    public class TopicViewModel
    {
        public TopicViewModel()
        {
        }

        public Topic Topic { get; set; }

        [Display(Name = "Last posted thread name")]
        public string LastPostThreadName { get; set; }

        [Display(Name = "Last posted post date")]
        public string PostedDate { get; set; }

        [Display(Name = "Total replies")]
        public int TotalPostCount { get; set; }
    }
}
