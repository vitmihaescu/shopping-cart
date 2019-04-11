using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;
using Vit.ShoppingCart.Application;
using Vit.ShoppingCart.Persistence;
using Vit.ShoppingCart.Persistence.Extensions;
using Vit.ShoppingCart.Web.Extensions;
using VueCliMiddleware;

namespace Vit.ShoppingCart.Web
{
    public class Startup
    {
        private readonly IConfiguration _configuration;

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info
                {
                    Version = "v1",
                    Title = "ShoppingCart API",
                });

                // comments path
                //var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                //var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                //c.IncludeXmlComments(xmlPath);
            });
            services.AddApiVersioning();
            services.AddMediatR();
        }

        public void ConfigureDevelopmentServices(IServiceCollection services)
        {
            ConfigureServices(services);

            services.AddDbContext<ApplicationDbContext, SqliteDbContext>(options => options
               .UseConnectionString(_configuration.GetConnectionString("ApplicationDb"))
               .EnableDetailedErrors()
               .EnableSensitiveDataLogging()
               .ConfigureWarnings(warnings => warnings.Throw(RelationalEventId.QueryClientEvaluationWarning))
            );
        }

        public void ConfigureProductionServices(IServiceCollection services)
        {
            ConfigureServices(services);

            services.AddDbContext<ApplicationDbContext, SqlServerDbContext>(_configuration.GetConnectionString("ApplicationDb"));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UpdateDatabase<ApplicationDbContext>();

            // We don't need as the app is always running behind a reverse proxy
            //if (env.IsProduction())
            //{
            //    app.UseHsts();
            //    app.UseHttpsRedirection();
            //}

            app.UseForwardedHeaders(new ForwardedHeadersOptions { ForwardedHeaders = ForwardedHeaders.All });
            app.UsePathBase(_configuration["PathBase"]);
            app.UseStaticFiles();
            app.UseMvc();
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint($"{_configuration["PathBase"] ?? ""}/swagger/v1/swagger.json", "ShoppingCart API V1");
            });
        }

        public void ConfigureDevelopment(IApplicationBuilder app, IHostingEnvironment env)
        {
            Configure(app, env);

            app.UseDeveloperExceptionPage();
            app.UseSpa(spa =>
            {
                spa.Options.SourcePath = "ClientApp";
                spa.UseVueCli(npmScript: "serve");
            });
        }

        public void ConfigureProduction(IApplicationBuilder app, IHostingEnvironment env)
        {
            Configure(app, env);
            app.UseSpa(spa => { });
        }
    }
}