using Forum.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forum.Core
{
    public interface IThreadBL
    {
        void Add(Thread thread);
        void Delete(int id);
        Thread Get(int id);
        List<Thread> GetAll(int topicId);
    }
}
