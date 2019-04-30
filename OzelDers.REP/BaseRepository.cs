using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OzelDers.DAL;

namespace OzelDers.REP
{
    public class BaseRepository<T> : IRepository<T> where T : class
    {
        private readonly OzelDersContext _db;
        public BaseRepository(OzelDersContext db)
        {
            _db = db;
        }

        public void Add(T entity)
        {
            _db.Entry(entity).State = EntityState.Added;
        }

        public async Task<bool> Commit()
        {
            return await _db.SaveChangesAsync() > 0;
        }

        public void Delete(T entity)
        {
            _db.Entry(entity).State = EntityState.Deleted;
        }

        public async Task<T> Find(int Id)
        {
            return await Set().FindAsync(Id);
        }

        public async Task<List<T>> ListAll()
        {
            return await Set().ToListAsync();
        }

        public DbSet<T> Set()
        {
            return _db.Set<T>();
        }

        public void Update(T entity)
        {
            _db.Entry(entity).State = EntityState.Modified;
        }
    }
}
