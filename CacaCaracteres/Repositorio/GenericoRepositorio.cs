using CacaCaracteres.Modelo;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace CacaCaracteres.Repositorio
{
    public class GenericoRepositorio<T> : IGenericoRepositorio<T> where T : Base
    {
        private readonly DbContext _dbContext;
        private readonly DbSet<T> _dbSet;

        public GenericoRepositorio (DbContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = dbContext.Set<T>();
        }

        public void Create(T entity)
        {
            _dbSet.Add(entity);
            _dbContext.SaveChanges();
        }

        public async Task<T> WhereFirstAsync(Expression<Func<T, bool>> expression)
        {
            return await _dbSet.FirstOrDefaultAsync(expression);
        }

        public void Delete(T entity)
        {
            _dbSet.Remove(entity);
            _dbContext.SaveChanges();
        }

        public void Update(T entity)
        {
            _dbSet.Update(entity);
            _dbContext.SaveChanges();
        }
    }
}
