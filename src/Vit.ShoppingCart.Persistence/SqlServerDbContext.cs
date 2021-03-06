﻿using System;
using System.IO;
using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Vit.ShoppingCart.Application;
using Vit.ShoppingCart.Persistence.Extensions;

namespace Vit.ShoppingCart.Persistence
{
    public class SqlServerDbContext : ApplicationDbContext, IDesignTimeDbContextFactory<SqlServerDbContext>
    {
        public SqlServerDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            if (builder.IsConfigured)
            {
                return;
            }

            var extension = builder.Options.FindExtension<ConnectionStringOptionsExtension>();
            var connectionString = (extension ?? throw new InvalidOperationException(Messages.ConnectionStringMissing))
                .ConnectionString;
            builder.UseSqlServer(connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(
                Assembly.GetExecutingAssembly(), t => !t.Name.StartsWith("Sqlite"));
        }

        #region IDesignTimeDbContextFactory

        // This constructor gets called by design time tools like Add-Migration, Remove-Migration and so on.
        public SqlServerDbContext() : base(new DbContextOptionsBuilder().Options)
        {
        }

        // This method gets called by design time tools like Add-Migration, Remove-Migration and so on.
        public SqlServerDbContext CreateDbContext(string[] args)
        {
            var config = new ConfigurationBuilder()
                .SetBasePath($@"{Directory.GetCurrentDirectory()}\..\{GetType().Assembly.GetName().Name}")
                .AddJsonFile("settings.json")
                .Build();

            var options = new DbContextOptionsBuilder()
                .UseConnectionString(config.GetConnectionString("SqlServerDb"))
                .Options;

            return new SqlServerDbContext(options);
        }

        #endregion
    }
}