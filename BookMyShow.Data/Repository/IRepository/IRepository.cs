using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BookMyShow.Data.Repository.IRepository
{
    public interface IRepository<T>
    {
        public IEnumerable<T> GetAll(string? includeProperties = null);
        public T Get(Expression<Func<T, bool>> expression, string? includeProperties = null);
        public T Update(T entity);
        public T Delete(T entity);
        public T Create(T entity);
        public void Save();
    }
}
