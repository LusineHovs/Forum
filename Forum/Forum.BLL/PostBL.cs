using Forum.Core;
using Forum.Core.Models;
using Forum.DAL.ConcreteRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forum.BLL
{
    public class PostBL : IPostBL
    {
        PostRepository postRepo;
        public PostBL()
        {
            postRepo = new PostRepository();
        }

        public void Add(Post post)
        {
            postRepo.AddPost(post);

        }
        public void Delete(int id)
        {
            postRepo.DeletePost(id);
        }
        public Post Get(int id)
        {
            var entity = postRepo.GetPost(id);
            return entity;
        }
        public List<Post> GetAll(int threadId)
        {
            var entities = postRepo.GetAllPosts(threadId);
            return entities;
        }

        // Gets the post count for Thread 
        public int PostCountForThread(int threadId)
        {
            var postCount = postRepo.GetAllPosts(threadId);
            return postCount.Count;
        }

        public int GetPostsByUserCount(string userId)
        {
            var posts = postRepo.GetPostbyUserId(userId);
            return posts.Count;
        }

        //Ordering
        public List<Post> PostOrdering(bool a)
        {
            var orderedPostList = postRepo.OrderPosts(a);
            return orderedPostList;
        }

        // Topic, right to the each Thread
        public string LastPostedDate(int threadId)
        {
            var post = postRepo.LastPostDate(threadId);
            var date = post?.Date != null ? post.Date.ToString() : "";
            return date;
        }

        //Main, right to the each Topic
        public string GetPostedDate(int topicId)
        {
            var post = postRepo.GetLastPostedDate(topicId);
            var date = post.Date.ToString();
            return date;
        }

    }
}
