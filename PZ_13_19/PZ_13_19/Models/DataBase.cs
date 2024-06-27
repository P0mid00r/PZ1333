using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PZ_13_19.Models
{
    public class DataBase : DbContext
    {
        private const string _fileName = "db.db3";
        public DbSet<User> Users { get; set; }
        public DbSet<Product> Products { get; set; }

        public DataBase()
        {
            if (!File.Exists(_fileName))
                Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite($"FileName={_fileName}");
        }
    }
}
