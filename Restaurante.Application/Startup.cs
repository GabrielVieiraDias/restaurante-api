using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Swashbuckle.AspNetCore.Swagger;
using Restaurante.Domain.Const;
using Restaurante.Infra.CrossCutting.IoC;
using Restaurante.Service.AutoMapper;
using Restaurante.Service.Exceptions;

namespace Restaurante.Application
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
            new DependencyInjection(services).RegisterServices();

            services.AddAutoMapper(typeof(AutoMapperConfig));

            services.AddMvc(config =>
            {
                config.Filters.Add(typeof(CustomExceptionFilter));
            }).SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            services.AddMvc().AddFluentValidation(x => x.RegisterValidatorsFromAssemblyContaining<Startup>());

            SwaggerConfig(services);
            JWTConfig(services);
            CorsConfig(services);

            services.AddHttpContextAccessor();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseAuthentication();
            app.UseHttpsRedirection();
            app.UseMvc();

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("../swagger/v1/swagger.json", "Swagger XML Api Restaurante v1");
            });

            app.UseCors(Policy.AllowAll);
        }

        #region Métodos privados

        private void SwaggerConfig(IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info
                {
                    Title = "Swagger XML Api Restaurante",
                    Version = "v1",
                });

                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.XML";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);

                c.IncludeXmlComments(xmlPath);
            });
        }

        private void JWTConfig(IServiceCollection services)
        {
            services.AddAuthentication(authOptions =>
            {
                authOptions.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                authOptions.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = Configuration["Jwt:Issuer"],
                        ValidAudience = Configuration["Jwt:Issuer"],
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Jwt:SecretKey"]))
                    };
                });

            services.AddAuthorization(options =>
            {
                //options.AddPolicy(Policy.ADMIN, policy => policy.RequireClaim(Role.ADMIN));
                //options.AddPolicy(Policy.AVALIADOR, policy => policy.RequireClaim(Role.AVALIADOR));
                //options.AddPolicy(Policy.PROFESSOR, policy => policy.RequireClaim(Role.PROFESSOR));
            });
        }

        private void CorsConfig(IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy(Policy.AllowAll, p =>
                {
                    p.AllowAnyOrigin()
                        .AllowAnyHeader()
                        .AllowAnyMethod();
                });

                //options.AddPolicy(Policy.SCAD, p =>
                //{
                //    p.WithOrigins(Configuration["AllowApplicationUrl"].Split(","))
                //        .AllowAnyHeader()
                //        .AllowAnyMethod();
                //});
            });

        }
        #endregion
    }
}
