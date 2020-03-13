using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Importador.Infra.Data;
using Importador.Infra.Data.Repository;
using Importador.Services;
using Importador.Shared;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Importador
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
            services.AddControllers();
            services.AddHealthChecks()
              .AddCheck("self", () => HealthCheckResult.Healthy());

            services.AddMvc()
            .AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.IgnoreNullValues = true;
            });

            services.AddDbContext<ImportadorDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("ImportadorConnection")));

            services.AddTransient<IImportacaoAmbienteService, ImportacaoAmbienteService>();
            services.AddTransient<ITipoAmbienteService, TipoAmbienteService>();
            services.AddTransient<IAmbienteService, AmbienteService>();

            services.AddTransient<IImportacaoAmbienteRepository, ImportacaoAmbienteRepository>();
            services.AddTransient<ITipoAmbienteRepository, TipoAmbienteRepository>();
            services.AddTransient<IAmbienteRepository, AmbienteRepository>();


            services.AddScoped<IContext, ImportadorDbContext>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseHealthChecks("/health", new HealthCheckOptions { Predicate = check => check.Tags.Contains("ready") });
            app.UseHealthChecks("/ready", new HealthCheckOptions
            {
                Predicate = r => r.Tags.Contains("ready")
            });

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
