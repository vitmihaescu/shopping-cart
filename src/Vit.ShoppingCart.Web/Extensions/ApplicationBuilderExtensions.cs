using JetBrains.Annotations;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Vit.ShoppingCart.Web.Extensions
{
    public static class ApplicationBuilderExtensions
    {
        public static IApplicationBuilder UpdateDatabase<TDbContext>([NotNull] this IApplicationBuilder builder)
            where TDbContext : DbContext
        {
            using (var scope = builder.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                var context = scope.ServiceProvider.GetService<TDbContext>();
                context.Database.Migrate();
            }

            return builder;
        }
    }
}