using Colony.models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Colony
{
    class Context : DbContext
    {
        private static Context instance = null;

        private Context(DbContextOptions<Context> options) :base(options) {}

        ~Context()
        {
            Dispose();
        }

        public static Context Get
        {
            get
            {
                if (instance == null)
                {
                    var optionsBuilder = new DbContextOptionsBuilder<Context>();
                    optionsBuilder
                        .UseLazyLoadingProxies()
                        .UseSqlite(@"Data Source=AntsDB.db;");
                    instance = new Context(optionsBuilder.Options);
                }
                return instance;
            }
        }

        public static void Save()
        {
            instance.SaveChanges();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AntHiveRelation>().HasKey(antHive => new { antHive.AntId, antHive.HiveId });
        }

        public DbSet<Ant> Ants { get; set; }
        public DbSet<Hive> Hives { get; set; }
        public DbSet<Queen> Queens { get; set; }
        public DbSet<AntHiveRelation> AntHives { get; set; }
    }
}
