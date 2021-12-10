using Core.WebApi.Dapper.Business.Api.v1.CustomersFacade;
using Core.WebApi.Dapper.Repository.CustomersRepository;
using Core.WebApi.Dapper.Repository.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Data;
using System.Data.SqlClient;

namespace Core.WebApi.Dapper
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
            services.AddCors(b =>
                    b.AddPolicy("AllowAllOrigins",
                        cors => cors.AllowAnyOrigin()
                            .AllowAnyHeader()
                            .AllowAnyMethod()));

            services.AddControllers();
            //services.AddDbContext<Business.DataContext.AppContext>(options =>
            //          options.UseSqlServer(
            //              Configuration.GetConnectionString("DefaultConnection")));
            

            RegisterV1(services, Configuration);
            
        }

        private void RegisterV1(IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient<IDbConnection>(db =>
            {
                var connectionString = Configuration.GetConnectionString("DefaultConnection");
                return new SqlConnection(connectionString ??
                                         throw new InvalidOperationException(
                                             "Configuration setting 'MSSQLLocalDB' is invalid."));
            });

            //Register Services 
            services.AddScoped<IDapper, Dapperr>();
            services.AddScoped<ICustomersFacade, CustomersFacade>();
            services.AddScoped<ICustomersRepository, CustomersRepository>();
        }

        #region Configure
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

            app.UseCors("AllowAllOrigins");

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        } 
        #endregion
    }
}
