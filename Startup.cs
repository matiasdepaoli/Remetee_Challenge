using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Remetee_Challenge.Commands;
using Remetee_Challenge.Commands.Interfaces;
using Remetee_Challenge.Core;
using Remetee_Challenge.Core.Validators;
using Remetee_Challenge.Domain;
using Remetee_Challenge.Services;

namespace Remetee_Challenge
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        
        public void ConfigureServices(IServiceCollection services )
        {

            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
            builder.DataSource = Configuration.GetConnectionString("DB_DataSource"); 
            builder.UserID = Configuration.GetConnectionString("DB_UserID"); 
            builder.Password = Configuration.GetConnectionString("DB_Password");
            builder.InitialCatalog = Configuration.GetConnectionString("DB_dbInitialCatalog"); 
           


           services.AddDbContext<CurrencyLayerWebClientService>(options => options.UseSqlServer(builder.ConnectionString));
            
            services.AddScoped< ICurrencyClientService, CurrencyLayerWebClientService>();
            services.AddScoped<ICalculator, Calculator>();
            services.AddScoped<ICurrencyWebClienteService, CurrencyWebClienteService>();
            services.AddScoped<IConfigurationsService, ConfigurationsService>();
            services.AddScoped<IRequesProcessor, RequesProcessor>();
            services.AddScoped<ApiRequestValidator>();
            services.AddScoped<MapperCurrentLayer>();
           
            services.AddHostedService<BackgroundExchangeRateClient>();

            services.AddAutoMapper(typeof(Startup));
           
            services.AddControllers();
                    
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
