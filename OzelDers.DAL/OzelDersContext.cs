using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore.Proxies;
using static OzelDers.ENT.Entities;

namespace OzelDers.DAL
{
    public class OzelDersContext:DbContext
    {
        public OzelDersContext(DbContextOptions<OzelDersContext> options):base(options)
        {
                
        }
        public DbSet<Il> Il { get; set; }
        public DbSet<Ilce> Ilce { get; set; }
        public DbSet<DersAlani> DersAlani { get; set; }
        public DbSet<DersKonusu> DersKonusu { get; set; }
        public DbSet<Egitmen> Egitmen { get; set; }
        public DbSet<AraTablo> AraTablo { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            
            optionsBuilder.UseSqlServer("Server=ARAZ\\SQLEXPRESS;Database=OzelDersDB;Trusted_Connection=True;");
            
        }
    }
}
