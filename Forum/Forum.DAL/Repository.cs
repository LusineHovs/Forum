using Forum.Core;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forum.DAL
{
    public class Repository<TEntity> : IRepository<TEntity>, IDisposable where TEntity : class
    {
        public static string connection = ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString();
        //"Data Source=(LocalDb)\\MSSQLLocalDB;Initial Catalog=aspnet-Forum.Web-20180711032047;" + "Integrated Security=true";
        public SqlConnection connect;
        private SqlTransaction transaction;
        public Repository(string connection)
        {
            connect = new SqlConnection(connection);
            connect.Open();         
            transaction = connect.BeginTransaction();

        }
        public Repository()
        {
            connect = new SqlConnection(connection);
            connect.Open();
            transaction = connect.BeginTransaction();

        }

        public SqlCommand CreateCommand()
        {
            var cmd = connect.CreateCommand();
            cmd.Transaction = transaction;
            return cmd;
        }
        public void Save()
        {
            if (transaction == null)
            {
                throw new NullReferenceException();
            }

            transaction.Commit();
            transaction = null;
        }

        public void Dispose()
        {
            if (connect != null)
            {
                connect.Dispose();
            }
            if (transaction != null)
            {
                transaction.Rollback();
                transaction = null;
            }
        }

        protected IEnumerable<TEntity> ToList(IDbCommand command)
        {
            using (var record = command.ExecuteReader())
            {
                List<TEntity> items = new List<TEntity>();

                List<Dictionary<string, object>> list = new List<Dictionary<string, object>>();
                Dictionary<string, object> result = null;
                while (record.Read())
                {
                    items.Add(Map<TEntity>(record));
                }
                return items;
            }

        } 

        

        protected TEntity Map<TEntity>(IDataRecord record)
        {
            try
            {
                var objT = Activator.CreateInstance<TEntity>();
                foreach (var property in typeof(TEntity).GetProperties())
                {
                        int index = record.GetOrdinal(property.Name);


                        if (index >= 0 && !record.IsDBNull(record.GetOrdinal(property.Name)))
                        {
                            property.SetValue(objT, record[property.Name]);
                        }
                }
                return objT;
            }
            catch (Exception ex)
            {
                return default(TEntity);
            }
        }


        public void AddEntity(string cmdText)
        {
            using (var cmd = CreateCommand())
            {
                cmd.CommandText = cmdText;
                Save();
                ToList(cmd).FirstOrDefault();
            }
        }

        public void DeleteEntity(string cmdText)
        {
            using (var cmd = CreateCommand())
            {
                cmd.CommandText = cmdText;
                Save();
                ToList(cmd).FirstOrDefault();
            }
        }

        public TEntity GetEntity(string cmdText)
        {
            using (var cmd = CreateCommand())
            {
                cmd.CommandText = cmdText;
                return this.ToList(cmd).FirstOrDefault();
            }
        }

        public IEnumerable<TEntity> GetAll(string cmdText)
        {
            using (var cmd = CreateCommand())
            {
                cmd.CommandText = cmdText;
                return ToList(cmd);
            }
        }
    }
}
