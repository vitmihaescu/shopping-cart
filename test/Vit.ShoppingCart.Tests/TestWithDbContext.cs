using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using System;
using Vit.ShoppingCart.Application;
using Vit.ShoppingCart.Persistence;

namespace Vit.ShoppingCart.Tests
{
    public abstract class TestWithDbContext : IDisposable
    {
        private readonly SqliteConnection _connection;

        protected ApplicationDbContext DbContext { get; }

        protected TestWithDbContext()
        {
            _connection = new SqliteConnection("Data Source=:memory:");
            _connection.Open();

            var options = new DbContextOptionsBuilder().UseSqlite(_connection).Options;
            DbContext = new SqliteDbContext(options);

            DbContext.Database.Migrate();
        }

        public void Dispose()
        {
            _connection?.Dispose();
        }
    }
}