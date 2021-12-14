using CoreWebApiJWT.DataContexts;
using CoreWebApiJWT.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreWebApiJWT
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

            //services.AddControllers();
            services.AddMvc();
            services.AddDbContext<DemoTokenContexts>(opts => opts.UseSqlServer(Configuration["ConnectionString:DefaultConnection"]));
            // configure strongly typed settings objects  
            var appSettingsSection = Configuration.GetSection("ServiceConfiguration");
            services.Configure<ServiceConfiguration>(appSettingsSection);
            services.AddTransient<Services.IIdentityService, Services.IdentityService>();
            services.AddTransient<Services.IUserService, Services.UserService>();
            // configure jwt authentication  
            var serviceConfiguration = appSettingsSection.Get<ServiceConfiguration>();
            var JwtSecretkey = Encoding.ASCII.GetBytes(serviceConfiguration.JwtSettings.Secret);
            var tokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(JwtSecretkey),
                ValidateIssuer = false,
                ValidateAudience = false,
                RequireExpirationTime = false,
                ValidateLifetime = true
            };
            services.AddSingleton(tokenValidationParameters);
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;

            })
            .AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = tokenValidationParameters;
                //x.TokenValidationParameters = new TokenValidationParameters()
                //{
                //    ValidateIssuer = true,
                //    ValidateAudience = true,
                //    ValidAudience = Configuration["JWT:ValidAudience"],
                //    ValidIssuer = Configuration["JWT:ValidIssuer"],
                //    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["JWT:Secret"]))
                //};
            });
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy", builder =>
                builder.AllowAnyOrigin()
             .AllowAnyMethod()
             .AllowAnyHeader()
             );
            });
            //services.AddCors();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo 
                { 
                    Title = "CoreWebApiJWT", 
                    Version = "v1",
                    Description = "Authentication and Authorization in ASP.NET 5 with JWT and Swagger"
                });
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Description = "Enter 'Bearer' [space] and then your valid token in the text input below.\r\n\r\nExample: \"Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9\"",
                });
                c.AddSecurityRequirement(new OpenApiSecurityRequirement
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
                         new string[] {}
                    }
                });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "CoreWebApiJWT v1"));
            }

            //app.UseRouting();
            //app.UseAuthorization();

            app.UseHttpsRedirection();
            app.UseRouting();
            //app.UseCors();
            app.UseCors("CorsPolicy");
            //app.UseCors(options =>
            //options.AllowAnyOrigin()
            //.AllowAnyMethod()
            //.AllowAnyHeader());
            
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseStaticFiles();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
