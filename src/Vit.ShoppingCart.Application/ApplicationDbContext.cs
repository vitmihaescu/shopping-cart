using Microsoft.EntityFrameworkCore;
using System.Linq;
using Vit.ShoppingCart.Application.Extensions;
using Vit.ShoppingCart.Domain.Books;
using Vit.ShoppingCart.Domain.Orders;
using Vit.ShoppingCart.Domain.Payments;

namespace Vit.ShoppingCart.Application
{
    public abstract class ApplicationDbContext : DbContext
    {
        public DbSet<Book> Books { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Payment> Payments { get; set; }

        protected ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        public void DetachAllEntities()
        {
            ChangeTracker.Entries()
                .Where(e => e.State == EntityState.Added
                            || e.State == EntityState.Modified
                            || e.State == EntityState.Deleted)
                .ForEach(e => e.State = EntityState.Detached);
        }
    }
}