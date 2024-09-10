using Microsoft.EntityFrameworkCore;
using BYTEBaba.SqlServer;

namespace BYTEBaba.Repository.SqlServer
{
    public class SQLServer<T> : ISQLServer<T> where T: class
    {
        private readonly SqlServerDbContext  _context;
        private readonly DbSet<T> _dbSet;

        public SQLServer(SqlServerDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<T> GetById(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task Add(T entity)
        {
            await _dbSet.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public void Update(T entity)
        {
            _dbSet.Update(entity);
            _context.SaveChanges();
        }

        public void Delete(T entity)
        {
            _dbSet.Remove(entity);
            _context.SaveChanges();
        }
    }
}
