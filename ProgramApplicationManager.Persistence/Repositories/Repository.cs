using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ProgramApplicationManager.Persistence.Repositories
{
    internal class Repository<T> : IRepository<T> where T : class
    {
        private readonly DbContext _dbContext;
        public Repository(DbContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        public T Create(T entity)
        {
            _dbContext.Set<T>().Add(entity);
            _dbContext.SaveChanges();
            return entity;
        }

        public IQueryable<T> FindBy(Expression<Func<T, bool>> predicate, bool trackChanges = true)
        {
            var result = trackChanges
                ? _dbContext.Set<T>().Where(predicate)
                : _dbContext.Set<T>().Where(predicate).AsNoTracking();
            return result;
        }

        public IQueryable<T> GetAll(bool trackChanges)
        {
            return trackChanges ? _dbContext.Set<T>() : _dbContext.Set<T>().AsNoTracking();
        }
    }
}
