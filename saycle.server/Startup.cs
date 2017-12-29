using System;
using System.IO;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.PlatformAbstractions;

using AutoMapper;
using Swashbuckle.AspNetCore.Swagger;

using saycle.server.Data;
using saycle.server.Models;
using ConfigurationProvider = saycle.server.Handlers.ConfigurationProvider;

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
            ConfigurationProvider.Initialize(configuration);
        }
        
        /// <summary>
        /// Application configuration values.
        /// </summary>
        private IConfiguration Configuration { get; }
        
        /// <summary>
        /// Called by runtime and used to add services to the container.
        /// </summary>
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();

            ConfigureSwagger(services);
            ConfigureEF(services);
            ConfigureIdentity(services);
            // Configure AutoMapper
            services.AddAutoMapper();
        }

        /// <summary>
        /// Configure swagger as API framework.
        /// </summary>
        private void ConfigureSwagger(IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc(ConfigurationProvider.Version, new Info
                {
                    Version = ConfigurationProvider.Version,
                    Title = $"{ConfigurationProvider.ApplicationName} [{ConfigurationProvider.Environment}]",
                    Description = $"Public API for saycle.xyz using the {ConfigurationProvider.Environment}-environment.",
                    TermsOfService = ConfigurationProvider.Terms,
                    Contact = new Contact() { Email = ConfigurationProvider.Contact, Url = ConfigurationProvider.Url }
                });
                // Set the comments path for the Swagger JSON and UI.
                var basePath = PlatformServices.Default.Application.ApplicationBasePath;
                var xmlPath = Path.Combine(basePath, $"{System.Reflection.Assembly.GetExecutingAssembly().GetName().Name}.xml");
                c.IncludeXmlComments(xmlPath);
            });
        }

        /// <summary>
        /// Configure Entity Framework.
        /// </summary>
        private void ConfigureEF(IServiceCollection services)
        {
            services.AddDbContext<SaycleContext>(options =>
                options.UseSqlServer(ConfigurationProvider.ConnectionString));
            services.AddTransient<RolesInitializer>();
            services.AddTransient<LanguagesInitializer>();
            services.AddTransient<UsersInitializer>();
        }

        /// <summary>
        /// Configure Identity Service.
        /// </summary>
        private void ConfigureIdentity(IServiceCollection services)
        {
            services.AddIdentity<User, Role>()
                .AddEntityFrameworkStores<SaycleContext>()
                .AddDefaultTokenProviders();

            services.Configure<IdentityOptions>(options =>
            {
                // Password settings
                options.Password.RequireDigit = true;
                options.Password.RequiredLength = 8;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = true;
                options.Password.RequireLowercase = false;
                options.Password.RequiredUniqueChars = 6;

                // Lockout settings
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(30);
                options.Lockout.MaxFailedAccessAttempts = 10;
                options.Lockout.AllowedForNewUsers = true;

                // User settings
                options.User.RequireUniqueEmail = true;
            });

            services.ConfigureApplicationCookie(options =>
            {
                // Cookie settings
                options.Cookie.HttpOnly = true;
                options.Cookie.Expiration = TimeSpan.FromDays(150);
                options.LoginPath = "/User/Login";
                options.LogoutPath = "/User/Logout";
                options.AccessDeniedPath = "/User/AccessDenied";
                options.SlidingExpiration = true;
            });
        }

        /// <summary>
        /// Called by runtime and used to configure the HTTP request pipeline.
        /// </summary>
        public void Configure(IApplicationBuilder app, IHostingEnvironment environment, SaycleContext context, RolesInitializer rolesInitializer, LanguagesInitializer languagesInitializer, UsersInitializer userInitializer)
        {
            if (environment.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseSwagger();
            app.UseSwaggerUI(o =>
            {
                o.SwaggerEndpoint($"/swagger/{ConfigurationProvider.Version}/swagger.json", $"{ConfigurationProvider.ApplicationName} {ConfigurationProvider.Version}");
            });
            app.UseAuthentication();
            app.UseMvc();
            InitializeData(context, rolesInitializer, languagesInitializer, userInitializer);
        }

        private static void InitializeData(SaycleContext context, params BaseInitializer[] initializers)
        {
            context.Database.EnsureCreated();
            context.Database.Migrate();
            foreach (var initializer in initializers)
            {
                initializer.Seed();
            }
        }
    }
}
