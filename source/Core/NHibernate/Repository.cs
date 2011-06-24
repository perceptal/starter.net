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
    public class Repository : IRepository
    {
        public Repository(ISessionFactory factory)
        {
            this.Session = factory.OpenSession();
        }

        public ISession Session { get;  private set; }

        public void Delete<T>(T target)
        {
            this.Session.Delete(target);
        }

        public void Save<T>(T target)
        {
            this.Session.SaveOrUpdate(target);
        }

        public void Create<T>(T target)
        {
            this.Session.Save(target);
        }

        public T[] Query<T>(Expression<Func<T, bool>> where)
        {
            return this.Session.Query<T>().Where(where).ToArray();
        }

        public IQueryable<T> QueryBy<T>(Expression<Func<T, bool>> where)
        {
            return this.Session.Query<T>().Where(where);
        }

        public IQueryable<T> QueryAll<T>()
        {
            return this.Session.Query<T>();
        }

        public T FindBy<T>(Expression<Func<T, bool>> where)
        {
            return Session.Query<T>().FirstOrDefault(where);
        }
    }
}