using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using JogaFacil.Api.Data;
using JogaFacil.Api.Services;
using JogaFacil.Api.Auth;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace JogaFacil.Api
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
            services.AddControllers();

            services.AddDbContext<Context>(options =>
                    options.UseSqlServer(Configuration.GetConnectionString("Context")));

            services.AddDbContext<AuthContext>(options =>
                    options.UseSqlServer(Configuration.GetConnectionString("Context")));

            services.AddIdentity<IdentityUser, IdentityRole>()
                .AddEntityFrameworkStores<AuthContext>()
                .AddDefaultTokenProviders();

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
              .AddJwtBearer(options =>
           options.TokenValidationParameters = new TokenValidationParameters
           {
                ValidateIssuer = false,
                ValidateAudience = false,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(Configuration["Jwt:Key"])),
                ClockSkew = TimeSpan.Zero
           });

            services.AddCors(c =>
            {
                c.AddPolicy("AllowAll", options => options.AllowAnyOrigin()
                                                            .AllowAnyMethod()
                                                            .AllowAnyHeader());
            });

            services.Configure<AppSettings>(Configuration.GetSection("AppSettings"));

            services.AddHttpClient<IGeocodingService, GeocodingService>();
            services.AddHttpClient<IFoursquareService, FoursquareService>();

            //services.AddSingleton<IGeocodingService, GeocodingService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseCors("AllowAll");

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
