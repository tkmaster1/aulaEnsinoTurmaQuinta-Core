using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using TKMaster.AulaEnsino.Core.WebApi.Configurations;

namespace TKMaster.AulaEnsino.Core.WebApi
{
    public class Startup
    {
        #region properties

        public IConfiguration Configuration { get; }

        #endregion

        #region Constructor

        public Startup(IWebHostEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();

            Configuration = builder.Build();
        }

        #endregion

        #region Configuration  

        public void ConfigureServices(IServiceCollection services)
        {
            #region Configura��es Swagger

            services.AddSwaggerConfiguration(Configuration);

            #endregion

            #region Configura��es de DI e IoC

            services.AddDependencyInjectionConfiguration();

            #endregion

            #region Configura��es de Banco de dados

            services.AddDatabaseConfiguration(Configuration);

            #endregion

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Latest);
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "TKMaster AulaEnsino Core WebApi v1"));
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();

            app.UseCookiePolicy();
            // app.UseAuthorization();

            app.UseCors
             (
                 c =>
                 {
                     c.AllowAnyOrigin();
                     c.AllowAnyHeader();
                     c.AllowAnyMethod();
                 }
             );

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseSwagger();
            app.UseSwaggerUI(s =>
            {
                s.SwaggerEndpoint("../swagger/v1/swagger.json", "TKMaster AulaEnsino Core WebApi v1");
            });
        }

        #endregion
    }
}
