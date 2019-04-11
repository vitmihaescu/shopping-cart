using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Vit.ShoppingCart.Domain.Books;
using Vit.ShoppingCart.Persistence.Extensions;

namespace Vit.ShoppingCart.Persistence.Configurations
{
    public class BookConfiguration : IEntityTypeConfiguration<Book>
    {
        public virtual void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.Property(e => e.ISBN).IsRequired().HasMaxLength(50);
            builder.Property(e => e.Author).IsRequired().HasMaxLength(50);
            builder.Property(e => e.Publisher).IsRequired().HasMaxLength(50);
            builder.HasDataFromResource("SeedData.books.json");
        }
    }

    public class SqliteBookConfiguration : IEntityTypeConfiguration<Book>
    {
        public virtual void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.Property(e => e.Price).HasColumnType("NUMERIC");
            builder.Property(e => e.Rating).HasColumnType("NUMERIC");
        }
    }

    public class SqlServerBookConfiguration : IEntityTypeConfiguration<Book>
    {
        public virtual void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.Property(e => e.Price).HasColumnType("money");
            builder.Property(e => e.Rating).HasColumnType("decimal(3,2)");
        }
    }
}