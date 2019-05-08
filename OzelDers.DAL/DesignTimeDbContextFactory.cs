using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Text;

namespace OzelDers.DAL
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<OzelDersContext>
    {
        public OzelDersContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<OzelDersContext>();
            var connectionString = "Server=HAKAN\\SQLEXPRESS;Database=OzelDersDB;Trusted_Connection=True;";
            builder.UseSqlServer(connectionString);
            return new OzelDersContext(builder.Options);
        }
    }
}
