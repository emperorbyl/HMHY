using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using hmhyWebservice2._0.Models;
using System.Data.Entity.Core.EntityClient;

namespace hmhyWebservice2._0.DAL
{
    public class HmhyGlobalDbContext : DbContext
    {
        public HmhyGlobalDbContext() : base("hmhyGlobalDbEntities")
        {
            Database.Connection.ConnectionString = Database.Connection.ConnectionString.Replace("secret", @"!Xc-4JKK");
            // Adding this just in case an update overwrites entity, we have a backup. 
            EntityConnectionStringBuilder builder = new EntityConnectionStringBuilder("metadata=res://*/Models.HmhyGlobalDb.csdl|res://*/Models.HmhyGlobalDb.ssdl|res://*/Models.HmhyGlobalDb.msl;provider=System.Data.SqlClient;provider connection string=';data source=hmhyglobaldb.csxgrhmw0ty8.us-west-1.rds.amazonaws.com;initial catalog=hmhyGlobalDb;persist security info=True;user id=hmhy_admin;password=!Xc-4JKK;multipleactiveresultsets=True;application name=EntityFramework';");
            Database.Connection.ConnectionString = builder.ProviderConnectionString;
        }

        public DbSet<MainUser> MainUser { get; set; }
        public DbSet<Goal> Goal { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}