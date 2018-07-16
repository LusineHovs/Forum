using Forum.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forum.DAL.ConcreteRepositories
{
    public class PostRepository : Repository<Post>
    {

        public PostRepository() : base()

        {

        }

        public void AddPost(Post post)
        {
            var cmdText = $"INSERT INTO Post (Description,UserId,ThreadId, Date) Values('{post.Description}','{post.UserId}','{post.ThreadId}', '{post.Date}')";
            AddEntity(cmdText);
        }

        public void DeletePost(int id)
        {
            var cmdText = $"DELETE FROM Post WHERE Id = {id}";
            DeleteEntity(cmdText);
        }

        public Post GetPost(int id)
        {
            var cmdText = $"SELECT * FROM Post WHERE Id = {id}";
            var post = GetEntity(cmdText);
            return post;
        }

        public List<Post> GetPostbyUserId(string userId)
        {
            var cmdText = $"SELECT dbo.Post.* FROM dbo.AspNetUsers INNER JOIN  dbo.Post ON dbo.AspNetUsers.Id = dbo.Post.UserId And dbo.Post.UserId='{userId}'";
            var post = GetAll(cmdText);
            return post as List<Post>;
        }

        public List<Post> GetAllPosts(int threadId)
        {
            var cmdText = $"SELECT * FROM Post WHERE ThreadId={threadId}";
            var posts = GetAll(cmdText);
            return posts as List<Post>;
        }
        
        //Check 
        public List<Post> OrderPosts(bool a)
        {
            string cmdText=null;
            if (a)
            {
                cmdText = $"SELECT * FROM Post ORDERBY Id DESC";
            }
            else
            {
                cmdText = $"SELECT * FROM Post ORDERBY Id ASC";
            }
            var posts = GetAll(cmdText);
            return posts.ToList();
           
        }


        // Topic, right to the each Thread
        // The last post's date of the given Thread
        public Post LastPostDate(int threadId)
        {
            var cmdText = $"select * from Post where Post.ThreadId = {threadId} order by Post.Date desc";
            var post = GetEntity(cmdText);
            return post;
        }

        //Main, right to the each Topic
        //The last posted date among all threads in the given Topic 
        public Post GetLastPostedDate(int topicId)
        {
            var cmdText = $"select * from Thread inner join Post on Thread.Id= Post.ThreadId where Thread.TopicId = {topicId} order by Post.Date desc";
            var post = GetEntity(cmdText) ?? new Post() { Date = DateTime.Now }; // TO DO Exception 
           
            return post;
        }

     

    }
}
