using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Vit.ShoppingCart.Domain.Payments;

namespace Vit.ShoppingCart.Persistence.Configurations
{
    public class PaymentConfiguration : IEntityTypeConfiguration<Payment>
    {
        public void Configure(EntityTypeBuilder<Payment> builder)
        {
            builder.ToTable("Payments");
        }

        public class SqlitePaymentConfiguration : IEntityTypeConfiguration<Payment>
        {
            public virtual void Configure(EntityTypeBuilder<Payment> builder)
            {
                builder.Property(e => e.Amount).HasColumnType("NUMERIC");
            }
        }

        public class SqlServerPaymentConfiguration : IEntityTypeConfiguration<Payment>
        {
            public virtual void Configure(EntityTypeBuilder<Payment> builder)
            {
                builder.Property(e => e.Amount).HasColumnType("money");
            }
        }
    }
}