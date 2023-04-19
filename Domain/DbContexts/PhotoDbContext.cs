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
    public class PhotoDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "/tairaba.db";//これはこの書き方で良いっぽい
            optionsBuilder.UseSqlite($"Data Source ={path}");
        }

        public DbSet<Photos> Photos => Set<Photos>();

    }

    public class Photos
    {
        public byte[] 画像 { get; set; }
        [Key]//Kが小文字になっていた
        public int 写真ID { get; set; }
        public string 釣れた魚ID { get; set; }
        public string 釣り物ID { get; set; }
        public string タイラバデータID { get; set; }
        public string 天気 { get; set; }
        public string 日付 { get; set; }
        public double 水温 { get; set; }
        public string ユーザーID { get; set; }
        //}
    }

}
