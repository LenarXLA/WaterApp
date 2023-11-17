using Microsoft.EntityFrameworkCore;
using System;

namespace WaterApp.Model
{
    public class DataContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite($"Data Source={AppDomain.CurrentDomain.BaseDirectory}Water.db");
            base.OnConfiguring(optionsBuilder);
        }

        public DbSet<History> Historys { get; set; }
    }
}
