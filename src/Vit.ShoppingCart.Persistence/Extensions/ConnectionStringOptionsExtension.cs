using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.DependencyInjection;

namespace Vit.ShoppingCart.Persistence.Extensions
{
    public sealed class ConnectionStringOptionsExtension : IDbContextOptionsExtension
    {
        public string ConnectionString { get; }
        public string LogFragment => $"ConnectionString={ConnectionString}";

        public ConnectionStringOptionsExtension([NotNull] string connectionString)
        {
            ConnectionString = connectionString;
        }

        public bool ApplyServices(IServiceCollection services)
        {
            return false;
        }

        public long GetServiceProviderHashCode()
        {
            return 0;
        }

        public void Validate(IDbContextOptions options)
        {
        }
    }
}