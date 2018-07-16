using Forum.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forum.Core
{
    public interface ITopicBL
    {
        void Delete(int id);
        Topic Get(int id);
        List<Topic> GetAll();
    }
}
