using BookMyShow.Data.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace BookMyShow.Data.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly MovieDbContext _context;
        private readonly ILogger<MovieDbContext> _logger;
        internal DbSet<T> _dbSet;

        public Repository(MovieDbContext context, ILogger<MovieDbContext> logger)
        {
            _context = context;
            _logger = logger;
            _dbSet = _context.Set<T>();
        }

        public T Create(T entity)
        {
            _dbSet.Add(entity);
            return entity;
        }

        public T Delete(T entity)
        {
            _dbSet.Remove(entity);
            return entity;        
        }

        public T Get(Expression<Func<T, bool>> filter, string? includeProperties = null)
        {
            IQueryable<T> query = _dbSet;
            query = query.Where(filter);
            if (!string.IsNullOrEmpty(includeProperties))
            {
                foreach (string includeProp in includeProperties
                    .Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProp);
                }
            }
            return query.FirstOrDefault();
        }

        public IEnumerable<T> GetAll(string? includeProperties = null)
        {
            IQueryable<T> query = _dbSet;
            if (!string.IsNullOrEmpty(includeProperties))
            {
                foreach (string includeProp in includeProperties
                    .Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProp);
                }
            }
            return query.ToList();
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public virtual T Update(T entity)
        {
            _dbSet.Update(entity);
            return entity;
        }
    }
}
