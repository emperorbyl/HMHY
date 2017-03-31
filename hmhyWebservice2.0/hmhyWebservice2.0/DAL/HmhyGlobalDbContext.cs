using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using hmhyWebservice2._0.Models;

namespace hmhyWebservice2._0.DAL
{
    public class HmhyGlobalDbContext : DbContext
    {
        public HmhyGlobalDbContext() : base("hmhyGlobalDbEntities")
        {
                Database.Connection.ConnectionString = Database.Connection.ConnectionString.Replace("secret", @"!Xc-4JKK");
        }

        public DbSet<MainUser> MainUser { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}