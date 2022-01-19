using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using NorthwindProject.BusinessLogicLayer.Concrete;
using NorthwindProject.DataAccessLayer.Abstract;
using NorthwindProject.DataAccessLayer.Concrete.EntityFramework.Context;
using NorthwindProject.DataAccessLayer.Concrete.EntityFramework.Repository;
using NorthwindProject.DataAccessLayer.Concrete.EntityFramework.UnitOfWork;
using NorthwindProject.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NorthwindProject.WebAPI
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
            #region JwtTokenService
            //JwtSecurityTokenHandler
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(cfg =>
            {
                cfg.SaveToken = true;
                cfg.RequireHttpsMetadata = false;

                cfg.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
                {
                    ValidateIssuer = true,
                    RoleClaimType = "Roles",
                    ClockSkew = TimeSpan.FromMinutes(5),
                    ValidateLifetime = true,
                    ValidIssuer = Configuration["Tokens:Issuer"],
                    ValidateAudience = true,
                    ValidAudience = Configuration["Tokens:Issuer"],//Configuration["Tokens:Audience"] bende token service ile token clientler ayn� oldu�undan Issuer key'ini kulland�m
                    RequireSignedTokens = true,
                    RequireExpirationTime = true,
                    IssuerSigningKey = new Microsoft.IdentityModel.Tokens.SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(Configuration["Tokens:Key"]))
                };
            });
            #endregion





            #region ApplicationContext
            //Db Bağlantı
            services.AddScoped<DbContext, NorthwindContext>();
            services.AddDbContext<NorthwindContext>(opt =>
            {
                opt.UseSqlServer(Configuration.GetConnectionString("SqlServer"), sqlOpt =>
                {
                    sqlOpt.MigrationsAssembly("Northwind.Dal");
                });
            });
            #endregion

            #region ServiceSection
            services.AddScoped<IProductService, ProductManager>();
            services.AddScoped<ICustomerService, CustomerManager>();
            services.AddScoped<IUserService, UserManager>();
            #endregion

            #region RepositorySection
            
            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            #endregion

            #region UnitOfWork
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            #endregion

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "NorthwindProject.WebAPI", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "NorthwindProject.WebAPI v1"));
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
