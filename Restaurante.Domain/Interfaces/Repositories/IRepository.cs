using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Restaurante.Domain.Entities;

namespace Restaurante.Domain.Interfaces.Repositories
{
    public interface IRepository<T> where T : BaseEntity
    {
        void Insert(T entity);

        void InsertList(IEnumerable<T> entities);

        void Update(T entity);

        void Remove(long id);

        T GetById(long id);

        IEnumerable<T> GetAll();

        IEnumerable<T> GetAllOrdered(params Expression<Func<T, object>>[] orderBy);

        IEnumerable<T> GetFiltered(Expression<Func<T, bool>> filter, params Expression<Func<T, object>>[] includeProperties);

        T GetByIdIncluding(long id, params Expression<Func<T, object>>[] includeProperties);

        T GetByPropertyIncluding(Expression<Func<T, bool>> filter, params Expression<Func<T, object>>[] includeProperties);

        IEnumerable<T> GetAllIncluding(params Expression<Func<T, object>>[] includeProperties);
    }
}
