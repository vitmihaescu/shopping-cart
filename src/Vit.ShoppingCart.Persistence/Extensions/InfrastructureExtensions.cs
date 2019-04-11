using System;
using System.IO;
using System.Reflection;
using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;

namespace Vit.ShoppingCart.Persistence.Extensions
{
    public static class InfrastructureExtensions
    {
        public static IServiceCollection AddDbContext<TService, TImplementation>(
            [NotNull] this IServiceCollection services, 
            [NotNull] string connectionString) 
                where TImplementation : DbContext, TService
        {
            services.AddDbContext<TService, TImplementation>(options => UseConnectionString(options, connectionString));

            return services;
        }

        public static DbContextOptionsBuilder UseConnectionString(
            [NotNull] this DbContextOptionsBuilder builder, 
            [NotNull] string connectionString, 
            [CanBeNull] Action<DbContextOptionsBuilder> action = null)
        {
            var extension = new ConnectionStringOptionsExtension(connectionString);
            ((IDbContextOptionsBuilderInfrastructure)builder).AddOrUpdateExtension(extension);
            action?.Invoke(builder);

            return builder;
        }

        public static EntityTypeBuilder<TEntity> HasDataFromResource<TEntity>(
            [NotNull] this EntityTypeBuilder<TEntity> builder,
            [NotNull] string resourceName)
                where TEntity : class
        {
            builder.HasData(ReadFromResource<TEntity>(resourceName));

            return builder;
        }

        private static T[] ReadFromResource<T>([NotNull] string resourceName)
        {
            var assembly = Assembly.GetExecutingAssembly();

            using (var stream = assembly.GetManifestResourceStream($"{assembly.GetName().Name}.{resourceName}"))
            {
                if (stream == null)
                {
                    throw new InvalidOperationException(string.Format(Messages.ResourceNotFound, resourceName));
                }

                using (var reader = new StreamReader(stream))
                {
                    return JsonConvert.DeserializeObject<T[]>(reader.ReadToEnd());
                }
            }
        }
    }
}
