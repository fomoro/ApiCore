using Microsoft.EntityFrameworkCore;
using School.DataAccess;
using School.Interfaces.DataAccess;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace School.DataAccess.Repositories
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        protected MyDBContext RepositoryContext;

        public RepositoryBase(MyDBContext repositoryContext)
        {
            RepositoryContext = repositoryContext;
        }

        public IQueryable<T> FindAll(bool trackChanges) =>
            !trackChanges ?
              RepositoryContext.Set<T>()
                .AsNoTracking() :
              RepositoryContext.Set<T>();

        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression,
        bool trackChanges) =>
            !trackChanges ?
              RepositoryContext.Set<T>()
                .Where(expression)
                .AsNoTracking() :
              RepositoryContext.Set<T>()
                .Where(expression);

        public bool Exists(Expression<Func<T, bool>> expression)
        {
           //TODO: Este metodo es nuevo, es para demostrar el uso de Any(). No necesariamente debo leer el objeto.
           //Simplemente "pregunto" si existe alguno que cumpla condicion "expression"
           return RepositoryContext.Set<T>().Any(expression);
        }

        public void Create(T entity) => RepositoryContext.Set<T>().Add(entity);

        public void Update(T entity) => RepositoryContext.Set<T>().Update(entity);

        public void Delete(T entity) => RepositoryContext.Set<T>().Remove(entity);
    }
}
