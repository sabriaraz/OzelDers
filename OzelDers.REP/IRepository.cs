using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace OzelDers.REP
{
    public interface IRepository<T> where T : class
    {
        DbSet<T> Set();
        void Add(T Entity);
        void Delete(T Entity);
        void Update(T Entitiy);
        Task<bool> Commit();
        Task<T> Find(int Id);
        Task<List<T>> ListAll();

    }
}
