using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HospitalManagement.DAL;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
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

            var optionsBuilder = new DbContextOptionsBuilder<PatientDAL>();
            optionsBuilder.UseSqlServer(Configuration["conStr"].ToString());
            PatientDAL dal = new PatientDAL(Configuration["conStr"].ToString());


            services.AddDbContext<PatientDAL>(
                options => options.UseSqlServer(Configuration["conStr"].ToString()) );


            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                   .AddJwtBearer(options =>
                   {
                       options.TokenValidationParameters = new TokenValidationParameters
                       {
                           ValidateIssuer = true,
                           ValidateAudience = true,
                           ValidateLifetime = true,
                           ValidateIssuerSigningKey = true,
                           ValidIssuer = "amin",
                           ValidAudience = "amin",
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
