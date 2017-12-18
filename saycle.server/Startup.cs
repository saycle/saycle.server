using System.IO;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.PlatformAbstractions;

using Swashbuckle.AspNetCore.Swagger;

namespace saycle.server
{
    /// <summary>
    /// Startup class which is instantiate by the runtime.
    /// </summary>
    public class Startup
    {
        /// <summary>
        /// Called by runtime.
        /// </summary>
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        
        /// <summary>
        /// Application configuration values.
        /// </summary>
        public IConfiguration Configuration { get; }
        
        /// <summary>
        /// Called by runtime and used to add services to the container.
        /// </summary>
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info
                {
                    Version = "v1",
                    Title = "saycle.API",
                    Description = "Public API for saycle.xyz",
                    TermsOfService = "None",
                    Contact = new Contact() { Email = "info@saycle.xyz", Url = "https://saycle.xyz" }
                });
                // Set the comments path for the Swagger JSON and UI.
                var basePath = PlatformServices.Default.Application.ApplicationBasePath;
                var xmlPath = Path.Combine(basePath, $"{System.Reflection.Assembly.GetExecutingAssembly().GetName().Name}.xml");
                c.IncludeXmlComments(xmlPath);
            });
        }
        
        /// <summary>
        /// Called by runtime and used to configure the HTTP request pipeline.
        /// </summary>
        /// <param name="app">Application request pipeline</param>
        /// <param name="environment">Information about environment</param>
        public void Configure(IApplicationBuilder app, IHostingEnvironment environment)
        {
            if (environment.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseSwagger();
            app.UseSwaggerUI(o =>
            {
                o.SwaggerEndpoint("/swagger/v1/swagger.json", "saycle.API v1");
            });

            app.UseMvc();
        }
    }
}
