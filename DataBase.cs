using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Curs_BD_v0._1
{
    internal class ApplicationContext : DbContext
    {
        public DbSet<ATS> ats => Set<ATS>();
        public DbSet<rate> rate => Set<rate>();
        public DbSet<call> call => Set<call>();
        public DbSet<benefit> benefit1 => Set<benefit>();
        public DbSet<subscriber> subscriber => Set<subscriber>();

        public ApplicationContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=postgres;Include Error Detail=true;Username=postgres;Password=5228");
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
            optionsBuilder.EnableSensitiveDataLogging();
        }
    }
}
