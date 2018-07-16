using Forum.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forum.DAL.ConcreteRepositories
{
    public class UserRepository : Repository<Users>
    {
         public UserRepository()
            : base()
        {

        }

        // Last posted username of the given Thread
        public Users GetLastPostedUserName(int threadId)
        {
            var cmdText = $"SELECT AspNetUsers.* FROM Post INNER JOIN AspNetUsers ON Post.UserId = AspNetUsers.Id WHERE Post.ThreadId = {threadId} ORDER BY Post.Date DESC";
            var user = GetEntity(cmdText);
            if (user == null)
                return null;
            return user;
        }


        //Gets the user Username, #ofPosts(AccessFailedCount),City
        public Users GetUserName(string userId)
        {
            var cmdText = "select u.* from Post as p inner join AspNetUsers as u on p.UserId=u.Id group by p.UserId,u.UserName,u.City";
            var users = GetAll(cmdText);
            Users user = new Users();
            foreach (var item in users)
            {
                if (item.Id.Equals(userId))
                {
                    user = item;
                }
            }
            return user;
        }

        public Users GetIdByUser(string email)
        {
            var cmdText = $"select * from AspNetUsers where Email='{email}'";
            var user = GetEntity(cmdText);
            return user;
        }
        public Users GetUserBy(string id)
        {
            var cmdText = $"select * from AspNetUsers where Id='{id}'";
            var user = GetEntity(cmdText);
            return user;
        }
    }
}
