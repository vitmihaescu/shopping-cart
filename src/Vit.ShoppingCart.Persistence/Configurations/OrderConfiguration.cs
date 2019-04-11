using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Vit.ShoppingCart.Domain.Orders;
using Vit.ShoppingCart.Domain.Payments;

namespace Vit.ShoppingCart.Persistence.Configurations
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public virtual void Configure(EntityTypeBuilder<Order> builder)
        {
            builder
                .HasOne(e => e.Payment)
                .WithOne(e => e.Order)
                .HasForeignKey<Payment>(e => e.Id);
        }

        public class SqliteOrderConfiguration : IEntityTypeConfiguration<Order>
        {
            public virtual void Configure(EntityTypeBuilder<Order> builder)
            {
                builder.Property(e => e.TotalAmount).HasColumnType("NUMERIC");
            }
        }

        public class SqlServerOrderConfiguration : IEntityTypeConfiguration<Order>
        {
            public virtual void Configure(EntityTypeBuilder<Order> builder)
            {
                builder.Property(e => e.TotalAmount).HasColumnType("money");
            }
        }
    }
}