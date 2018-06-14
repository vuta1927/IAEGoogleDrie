using System;
using ApiServer.Auth;
using ApiServer.Model;
using ApiServer.Ulti.Email;
using IAEGoogleDrie.AspNetCore;
using IAEGoogleDrie.Storage.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace ApiServer
{
    public class Startup
    {
        private static readonly string _defaultCorsPolicyName = "http://localhost:52000";

        public static IServiceProvider Provider { get; private set; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMemoryCache();
            services.Configure<FormOptions>(x =>
            {
                x.ValueLengthLimit = int.MaxValue;
                x.MultipartBodyLengthLimit = int.MaxValue; // In case of multipart
            });
            services.AddMvc()
                .AddJsonOptions(
                options => options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
            );

            //services.AddHangfire(x => x.UseSqlServerStorage(Configuration.GetConnectionString("HangFireDB")));

            services.AddDomain(options =>
            {
                options.DefaultNameOrConnectionString = Configuration.GetConnectionString("Default");
                // Configure storage
                options.Storage.UseEntityFrameworkCore(c =>
                {
                    c.AddDbContext<IaeContext>(config =>
                            config.DbContextOptions.UseSqlServer(Configuration.GetConnectionString("Default")));
                });
            });
            
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IEmailHelper, EmailHelper>();

            services.AddAuthentication(options =>
            {
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(opts =>
            {
                opts.Authority = Configuration["IdentityServer:Authority"];
                opts.RequireHttpsMetadata = false;
                opts.Audience = "api1";
            });

            // Configure CORS for angular5 UI
            services.AddCors(
                options => options.AddPolicy(
                    _defaultCorsPolicyName,
                    builder => builder
                        .AllowAnyOrigin()
                        .AllowCredentials()
                        .AllowAnyHeader()
                        .AllowAnyMethod()
                )
            );

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            app.UseCors(_defaultCorsPolicyName);

            app.UseAuthentication();

            Provider = app.ApplicationServices;

            app.UseStaticFiles();

            app.UseMvc();
        }
    }
}
