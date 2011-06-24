using System;
using System.Linq;
using System.Linq.Expressions;
using NHibernate;
using NHibernate.Linq;

namespace Core.Persistence.Implementation
{
    /// <summary>
    /// Generic repository for querying/registering changes using the session factory
    /// </summary>
    public class Repository<T> : IRepository<T>
    {
        public Repository(ISessionFactory factory)
        {
            this.Session = factory.OpenSession();
        }

        public ISession Session { get;  private set; }

        public void Delete(T target)
        {
            this.Session.Delete(target);
        }

        public void Save(T target)
        {
            this.Session.SaveOrUpdate(target);
        }

        public void Create(T target)
        {
            this.Session.Save(target);
        }

        public T[] Query(Expression<Func<T, bool>> where)
        {
            return this.Session.Query<T>().Where(where).ToArray();
        }

        public IQueryable<T> QueryBy(Expression<Func<T, bool>> where)
        {
            return this.Session.Query<T>().Where(where);
        }

        public IQueryable<T> QueryAll()
        {
            return this.Session.Query<T>();
        }

        public T FindBy(Expression<Func<T, bool>> where)
        {
            return Session.Query<T>().FirstOrDefault(where);
        }
    }
}