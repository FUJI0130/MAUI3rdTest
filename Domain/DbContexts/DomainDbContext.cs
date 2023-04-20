using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Tables;
using Microsoft.EntityFrameworkCore;
using SQLite;
using System.ComponentModel.DataAnnotations;


namespace Domain.DbContexts
{
    public class DomainDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "/tairaba.db";//これはこの書き方で良いっぽい
            optionsBuilder.UseSqlite($"Data Source ={path}");
        }
        public DbSet<Photos> Photos => Set<Photos>();

    }  
}
