using FluentMigrator.Runner;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MobileSystemsBackend.Domain;
using MobileSystemsBackend.Infrastructure.Migrations;
using MobileSystemsBackend.Infrastructure.Repositories;

namespace MobileSystemsBackend
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            var connectionString = Configuration.GetValue<string>("PostgresConnectionString");

            services.AddCors(o => o.AddPolicy("MyPolicy", builder =>
            {
                builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader();
            }));
            services.AddControllers();
            services.AddFluentMigratorCore()
                .AddLogging(c => c.AddFluentMigratorConsole())
                .ConfigureRunner(rb => rb
                    .AddPostgres()
                    .WithGlobalConnectionString(connectionString)
                    .ScanIn(typeof(AddCoordinateTable).Assembly).For.Migrations()
                );
            services.AddScoped<ICoordinateRepository>(x =>
                ActivatorUtilities.CreateInstance<CoordinateRepository>(x, connectionString));
            services.AddScoped<ITripRepository>(x =>
                ActivatorUtilities.CreateInstance<TripRepository>(x, connectionString));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment()) app.UseDeveloperExceptionPage();

            app.UseCors("MyPolicy");
            
            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });

            Database.EnsureDatabase(Configuration.GetValue<string>("PostgresConnectionStringNoDb"), "mobilesystems");

            app.Migrate();
        }
    }
}