using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using NHibernate;

namespace Core.Persistence
{
    /// <summary>
    /// Repository inteface. See http://martinfowler.com/eaaCatalog/repository.html
    /// </summary>
    public interface IRepository
    {
        /// <summary>
        /// Mark the object to be deleted from the repository.
        /// </summary>
        /// <typeparam name="T">the type of the object to be deleted</typeparam>
        /// <param name="target">the object to be deleted</param>
        void Delete<T>(T target);

        /// <summary>
        /// Find all the objects in the repository that matches the specified 'where' criteria, and returns an array 
        /// </summary>
        /// <typeparam name="T">the type of the object to be found</typeparam>
        /// <example>FindBy&lt;Group&gt;(group => group.Code == "GRP1");</example>
        T[] Query<T>(Expression<Func<T, bool>> where);

        /// <summary>
        /// Find all the objects in the repository that matches the specified 'where' criteria, and returns an IList
        /// </summary>
        /// <typeparam name="T">the type of the object to be found</typeparam>
        /// <example>FindBy&lt;Group&gt;(group => group.Code == "GRP1");</example>
        IQueryable<T> QueryBy<T>(Expression<Func<T, bool>> where);

        /// <summary>
        /// Find all the objects in the repository that match type 'T'
        /// </summary>
        /// <typeparam name="T">the type of the object to be found</typeparam>
        IQueryable<T> QueryAll<T>();

        //// T FindBy<T, TCriteria>(Expression<Func<T, TCriteria>> expression, TCriteria search) where T : class;

        /// <summary>
        /// Find an object in the repository that matches the specified 'where' criteria
        /// </summary>
        /// <typeparam name="T">the type of the object to be found</typeparam>
        /// <exception cref="InvalidOperationException">if the object could not be found</exception>
        /// <example>GetBy&lt;Group&gt;(group => group.Code == "GRP1");</example>
        T FindBy<T>(Expression<Func<T, bool>> where);

        /// <summary>
        /// Create a new object in the repository, or save the object if it already exists.
        /// </summary>
        /// <typeparam name="T">the type of the object to be saved</typeparam>
        void Save<T>(T target);

        /// <summary>
        /// Create a new object in the repository.
        /// </summary>
        /// <typeparam name="T">the type of the object to be saved</typeparam>
        void Create<T>(T target);

        /// <summary>
        /// Returns the NHibernate session associated with this Repository's current UnitOfWork
        /// </summary>
        ISession Session { get; }
    }
}