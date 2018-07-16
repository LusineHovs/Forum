using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forum.Core.Models
{
    public class Users
    {
        //public Users()
        //{
        //    Posts = new List<Post>();
        //}
        public string Id { get; set; }
        public string PasswordHash { get; set; }  //?
        public string Email { get; set; }
        public bool EmailConfirmed { get; set; }

        [Display(Name = "User’s location")]
        public string City { get; set; }
        public string Country { get; set; }
        public string SecurityStamp { get; set; }
        public string PhoneNumber { get; set; }
        public bool PhoneNumberConfirmed { get; set; } 
        public bool TwoFactorEnabled { get; set; } 
        public DateTime LockoutEndDateUtc { get; set; }
        public bool LockoutEnabled { get; set; }

        [Display(Name = "Number of posts the user has ever left on the forum")]
        public int AccessFailedCount { get; set; }

        [Display(Name = "Nickname")]
        public string UserName { get; set; }
       
       // public List<Post> Posts { get; set; }
    }
}
