﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace hmhyWebservice2._0.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Core.EntityClient;
    using System.Data.Entity.Infrastructure;

    public partial class hmhyGlobalDbEntities1 : DbContext
    {
        public hmhyGlobalDbEntities1()
            : base("name=hmhyGlobalDbEntities1")
        {
            EntityConnectionStringBuilder builder = new EntityConnectionStringBuilder("metadata=res://*/Models.HmhyGlobalDb.csdl|res://*/Models.HmhyGlobalDb.ssdl|res://*/Models.HmhyGlobalDb.msl;provider=System.Data.SqlClient;provider connection string=';data source=hmhyglobaldb.csxgrhmw0ty8.us-west-1.rds.amazonaws.com;initial catalog=hmhyGlobalDb;persist security info=True;user id=hmhy_admin;password=!Xc-4JKK;multipleactiveresultsets=True;application name=EntityFramework';");
            Database.Connection.ConnectionString = builder.ProviderConnectionString;
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Goal> Goals { get; set; }
        public virtual DbSet<MainUser> MainUsers { get; set; }
    }
}
