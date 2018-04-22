using AutoMapper;
using Infra;
using Infra.Ioc;
using Poc.DemoNetCore.Domain.Core.Shared.Entities;
using Poc.DemoNetCore.Domain.Shared.Entities;

using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Cors.Internal;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using Swashbuckle.AspNetCore.Swagger;
using System;
using System.Text;

namespace Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            string name = this.GetType().Assembly.GetName().Name;
        }


        public IConfiguration Configuration { get; private set; }

        public void ConfigureServices(IServiceCollection services)
        {
            var nomeBanco = Configuration["AppSettings:DatabasePath"];

            services.Configure<AppSettings>(Configuration.GetSection("AppSettings"));
            services.Configure<PathSettings>(Configuration.GetSection("PathSettings"));

            services.AddDbContext<DemoContext>(options => options.UseSqlite($"DATA SOURCE = { AppSettings.PathDatabase(nomeBanco) }"));

            ContainerIoC.Register(services);
            services.AddAutoMapper(Infra.Mapper.Config.Register);

            services.AddCors(options => options.AddPolicy("Cors", builder => { builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader(); }));
            services.AddMvc().AddJsonOptions(options => { options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore; });
            services.AddSwaggerGen(c => { c.SwaggerDoc("v1", new Info { Title = "Demo Net Core com DDD + EF + IOC + DI + SQLite + Swagger + Token JWT - API", Version = "v1" }); });

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
               .AddJwtBearer(jwtBearerOptions =>
               {
                   jwtBearerOptions.TokenValidationParameters = new TokenValidationParameters()
                   {
                       ValidateActor = false,
                       ValidateAudience = false,
                       ValidateLifetime = false,
                       ValidateIssuerSigningKey = false,
                       ValidIssuer = Configuration["TokenConfigurations:Issuer"],
                       ValidAudience = Configuration["TokenConfigurations:Audience"],
                       IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["TokenConfigurations:IssuerSigningKey"]))
                   };
               });

           
        }


        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            app.UseMvc(routes => { routes.MapRoute(name: "default", template: "{controller=Config}/{action=Index}/{id?}"); });
            app.UseDeveloperExceptionPage();

            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            app.UseCors("Cors");

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Demo Net Core com DDD");
            });

            Console.WriteLine("Enviorioment Str: " + env.EnvironmentName);

            var builder = new ConfigurationBuilder().SetBasePath(env.ContentRootPath).
                AddJsonFile("appsettings.json", optional: false, reloadOnChange: true).
                AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true).
                AddEnvironmentVariables();

            Configuration = builder.Build();

            app.UseMvc();



         
      
        }
    }
}
