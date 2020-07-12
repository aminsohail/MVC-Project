using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HospitalManagement.DAL;
using HospitalManagement.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

namespace HospitalManagement
{
    public class Startup
    {
      //  private readonly IConfiguration configuration;
           /*   protected Newtonsoft.Json.JsonSerializerSettings
             SerializerSetting
           { get; }  */

      //  private readonly string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.Configure<SecuritySetting>(Configuration.GetSection("ApplicationSettings"));

            var optionsBuilder = new DbContextOptionsBuilder<PatientDAL>();
            optionsBuilder.UseSqlServer(Configuration["conStr"].ToString());
            PatientDAL dal = new PatientDAL(Configuration["conStr"].ToString());


            services.AddDbContext<PatientDAL>(
                options => options.UseSqlServer(Configuration["conStr"].ToString()) );

//            services.AddDbContext<PatientDAL>(options =>
 //           options.UseSqlServer(Configuration.GetConnectionString("conStr")));

    //        services.AddDbContext<RegistrationDAl>(options =>
      //     options.UseSqlServer(@"Data Source=LAPTOP-H6C5O2EO;Initial Catalog=HospitalManagement;Integrated Security=True"));

            services.AddDefaultIdentity<RegisterUser>()
                .AddEntityFrameworkStores<PatientDAL>();

            services.Configure<IdentityOptions>(options =>
            {
                options.Password.RequireDigit = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireUppercase = false;
                options.Password.RequiredLength = 4;
            }
            );

            var key = Encoding.UTF8.GetBytes(Configuration["ApplicationSettings:JWT_Secret"].ToString());

            // services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)

                 services.AddAuthentication(x =>
                    {
                     x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                     x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                     x.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                   })
                       .AddJwtBearer(options =>
                       {
                           options.RequireHttpsMetadata = false;
                           options.SaveToken = false;
                           options.TokenValidationParameters = new TokenValidationParameters
                           {
                               ValidateIssuer = true,
                               ValidateAudience = true,
                               ValidateLifetime = true,
                               ValidateIssuerSigningKey = true,
                               ValidIssuer = "amin",
                               ValidAudience = "amin",
                               ClockSkew = TimeSpan.Zero,
                               IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("2525255666665566"))
                       };
                   });


            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

           


            /*   services.AddCors(options =>
               {
                   options.AddPolicy(MyAllowSpecificOrigins,
                   builder =>
                   {
                       builder.WithOrigins("http://localhost:4200")
                                           .AllowAnyHeader()
                                           .AllowAnyMethod();
                   });
               });  */

            //         services.AddController().AddNewtonSoftJson(options =>{
            //           options.SerializerSettings.ContractResolver = new DefaultContractResolver();
            //    });



            services.AddCors(options =>
                          options.AddPolicy("MyAllowSpecificOrigins",
                            builder =>
                            {
                                builder.AllowAnyOrigin()
                                      .AllowAnyMethod()
                                      .AllowAnyHeader();
                           
                           
           
                        }));

            
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.Use(async (ctx, next) =>
            {
                await next();
                if (ctx.Response.StatusCode == 204)
                {
                    ctx.Response.ContentLength = 0;
                }
            });

            app.UseAuthentication();
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            

        app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();
            app.UseCors("MyAllowSpecificOrigins");

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Patient}/{action=Add}");
            });

            
        }
    }
}
