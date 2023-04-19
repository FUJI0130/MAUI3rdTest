using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Tables;
using Microsoft.EntityFrameworkCore;

namespace Domain.DbContexts
{
    public class PhotoDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "/tairaba.db";
            optionsBuilder.UseSqlite($"Data Source ={path}");
        }

        public DbSet<PhotoTables> Photo => Set<PhotoTables>();

    }
}
