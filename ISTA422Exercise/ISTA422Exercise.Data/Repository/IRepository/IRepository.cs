using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace ISTA422Exercise.Data.Repository.IRepository
{
    public interface IRepository<T> where T : class
    { 
        //based on Id retrieve a category from the db
        T Get(int id);

        //Getting all categories
        IEnumerable<T> GetAll(Expression<Func<T, bool>> filter = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderby = null, string includeProperties = null);

        T GetFirstOrDefault(Expression<Func<T, bool>> filter = null, string includeProperties = null);

        void Add(T entity);
        void Remove(int id);
        void Remove(T entity);
        void RemoveRange(IEnumerable<T> entity);
    }
}
