using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
using BlogPessoal.src.data;
using BlogPessoal.src.repositories;
using BlogPessoal.src.repositories.implementations;
using BlogPessoal.src.services;
using BlogPessoal.src.servicos.implementations;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;

namespace BlogPessoal
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

            // Database Configuration
            if (Configuration["Enviroment:Start"] == "PROD")
            {
                services.AddEntityFrameworkNpgsql()
                    .AddDbContext<BlogPessoalContext>(
                    opt =>
                opt.UseNpgsql(Configuration["ConnectionStringsProd:DefaultConnection"]));
            }

            else
            {
                services.AddDbContext<BlogPessoalContext>(
                opt =>
                opt.UseSqlServer(Configuration["ConnectionStringsDev:DefaultConnection"]));
            }

            //Context
            IConfigurationRoot config = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile("appsettings.json")
                .Build();

            services.AddDbContext<BlogPessoalContext>(opt=>opt.UseSqlServer(config.GetConnectionString("DefaultConnection")));

            //Repositories
            services.AddScoped<IUser, UserRepository>();
            services.AddScoped<ITheme, ThemeRepository>();
            services.AddScoped<IPost, PostRepository>();

            //Controllers
            services.AddCors();
            services.AddControllers();

            // Services Configuration
            services.AddScoped<IAuthentication, AuthenticationServices>();

            // Configuração do Token Autenticação JWTBearer
            var key = Encoding.ASCII.GetBytes(Configuration["Settings:Secret"]);
            services.AddAuthentication(a =>
            {
                a.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                a.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(b =>
            {
                b.RequireHttpsMetadata = false;
                b.SaveToken = true;
                b.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });

            //Swagger Configuration
            services.AddSwaggerGen(s =>
            {
                s.SwaggerDoc("v1", new OpenApiInfo { Title = "Blog Pessoal", Version = "v1" });

                s.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Description = "JWT authorization header utiliza: Bearer + JWT Token",
                });

                s.AddSecurityRequirement( new OpenApiSecurityRequirement
                {
                    { 
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            }
                        },
                        new List<string>()
                    }
                });

                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                s.IncludeXmlComments(xmlPath);


            });

          
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, BlogPessoalContext context)
        {
            //Development
            if (env.IsDevelopment())
            {
                context.Database.EnsureCreated(); // Create database if not existent
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "BlogPessoal v1"));

            }

            //Production Environment
            context.Database.EnsureCreated();
            app.UseDeveloperExceptionPage();
            app.UseSwagger();
            app.UseSwaggerUI(c => {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "BlogPessoal v1");
                c.RoutePrefix = string.Empty;
            });

            //Routes
            app.UseRouting();

            app.UseCors(c => c
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());     

            // Autenticação e Autorização
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
