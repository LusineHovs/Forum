using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forum.Core
{
    public interface IRepository<TEntity> where TEntity : class
    {
        TEntity GetEntity(string cmdText);
        IEnumerable<TEntity> GetAll(string cmdText);
        void AddEntity(string cmdText);
        void DeleteEntity(string cmdText);
    }
}
