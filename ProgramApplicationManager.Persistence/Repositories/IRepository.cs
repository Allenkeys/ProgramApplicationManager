using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ProgramApplicationManager.Persistence.Repositories
{
    public interface IRepository<T>
    {
        IQueryable<T> GetAll(bool trackChanges);
        T Create(T entity);
        IQueryable<T> FindBy(Expression<Func<T, bool>> predicate, bool trackChanges);
    }
}
