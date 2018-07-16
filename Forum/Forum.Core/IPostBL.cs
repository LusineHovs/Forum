using Forum.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forum.Core
{
    public interface IPostBL
    {
        void Add(Post post);
        void Delete(int id);
        Post Get(int id);
        List<Post> GetAll(int threadId);
    }
}
