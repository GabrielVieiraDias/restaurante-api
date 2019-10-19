using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Restaurante.Domain.Entities;
using Restaurante.Domain.Interfaces.Repositories;
using Restaurante.Infra.Data.Context;

namespace Restaurante.Infra.Data.Repository
{
    public class BaseRepository<T> : IRepository<T> where T : BaseEntity
    {
        protected readonly ContextDb _context;

        public BaseRepository(ContextDb context)
            : base()
        {
            _context = context;
        }

        public void Insert(T entity)
        {
            _context.Set<T>().Add(entity);
            _context.SaveChanges();
        }

        public void InsertList(IEnumerable<T> entities)
        {
            _context.Set<T>().AddRange(entities);
            _context.SaveChanges();
        }

        public void Update(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void Remove(long id)
        {
            _context.Set<T>().Remove(GetById(id));
            _context.SaveChanges();
        }

        public T GetById(long id)
        {
            return _context.Set<T>().Find(id);
        }

        public IEnumerable<T> GetAll()
        {
            return _context.Set<T>();
        }

        public IEnumerable<T> GetAllOrdered(params Expression<Func<T, object>>[] orderBy)
        {
            var query = _context.Set<T>().OrderBy(orderBy.First());
            if (orderBy.Length > 1)
            {
                for (int i = 1; i < orderBy.Length; i++)
                {
                    query = query.ThenBy(orderBy[i]);
                }
            }
            return query;
        }

        public IEnumerable<T> GetFiltered(Expression<Func<T, bool>> filter, params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> query = _context.Set<T>();

            foreach (var includeProperty in includeProperties)
            {
                query = query.Include(includeProperty);
            }

            return query.Where(filter);
        }

        public T GetByIdIncluding(long id, params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> query = _context.Set<T>().AsNoTracking();
            foreach (var includeProperty in includeProperties)
            {
                query = query.Include(includeProperty);
            }
            return query.SingleOrDefault(t => t.Id == id);
        }

        public T GetByPropertyIncluding(Expression<Func<T, bool>> filter, params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> query = _context.Set<T>().AsNoTracking();
            foreach (var includeProperty in includeProperties)
            {
                query = query.Include(includeProperty);
            }
            return query.SingleOrDefault(filter);
        }

        public IEnumerable<T> GetAllIncluding(params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> query = _context.Set<T>();
            foreach (var includeProperty in includeProperties)
            {
                query = query.Include(includeProperty);
            }
            return query;
        }
    }
}
