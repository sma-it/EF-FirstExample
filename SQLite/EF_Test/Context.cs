using Colony.models;
using Colony.SysLog;
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
            Log.GetInstance().AddDebug("Disposing Context");
            Dispose();
        }

        public static Context Get
        {
            get
            {
                if (instance == null)
                {
                    Log.GetInstance().AddDebug("Creating Context");
                    var optionsBuilder = new DbContextOptionsBuilder<Context>();
                    optionsBuilder
                        .UseLazyLoadingProxies()
                        .UseSqlite(@"Data Source=AntsDB.db;");
                    instance = new Context(optionsBuilder.Options);
                    Log.GetInstance().AddDebug("Context Created");
                }
                return instance;
            }
        }

        public static void Save()
        {
            Log.GetInstance().AddDebug("Saving Context");
            instance.SaveChanges();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            Log.GetInstance().AddDebug("Enter OnModelCreating");
            modelBuilder.Entity<AntHiveRelation>().HasKey(antHive => new { antHive.AntId, antHive.HiveId });
            Log.GetInstance().AddDebug("Exit OnModelCreating");
        }

        public DbSet<Ant> Ants { get; set; }
        public DbSet<Hive> Hives { get; set; }
        public DbSet<Queen> Queens { get; set; }
        public DbSet<AntHiveRelation> AntHives { get; set; }
    }
}
