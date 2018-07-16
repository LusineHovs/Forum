using Forum.Core.Models;
using Forum.DAL.ConcreteRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forum.BLL
{
    public class UserBL
    {
        UserRepository userRepo;
        public UserBL()
        {
            userRepo = new UserRepository();
        }

        // Last posted username of the given Thread
        public string GetUserName(int threadId)
        {
            var user = userRepo.GetLastPostedUserName(threadId);
            
            return user==null?"":user.UserName;
        }

        public Users GetUserInfo(string userId)
        {
            var userInfo = userRepo.GetUserBy(userId);
            return userInfo;
        }

        public string GetIdbyUsername(string email)
        {
           var userId = userRepo.GetIdByUser(email).Id;
            return userId;
        }
      
    }
}
