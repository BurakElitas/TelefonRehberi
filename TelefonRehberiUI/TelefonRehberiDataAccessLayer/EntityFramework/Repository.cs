using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TelefonRehberi.Core;
using TelefonRehberi.DataAccessLayer.EntityFramework;

namespace TelefonRehberiDataAccessLayer.EntityFramework
{
    public class Repository<T> : IDataAccess<T> where T : class
    {
        TelefonRehberiContext context;
        DbSet<T> _obj;
        public Repository()
        {
            context = RepositoryBase.CreateContext;
            _obj = context.Set<T>();
        }

        public int Delete(T obj)
        {
            _obj.Remove(obj);
            return Save();
        }

        public T Find(Expression<Func<T, bool>> where)
        {
            return _obj.FirstOrDefault(where);
        }

        public int Insert(T obj)
        {
            _obj.Add(obj);
            return Save();
        }

        public List<T> List()
        {
            return _obj.ToList();
        }

        public List<T> List(Expression<Func<T, bool>> where)
        {
            return _obj.Where(where).ToList();
        }

        public IQueryable<T> ListQueryable()
        {
            return _obj;
        }

        public int Save()
        {
            return context.SaveChanges();
        }

        public int Update(T obj)
        {
            return Save();
        }
    }
}
