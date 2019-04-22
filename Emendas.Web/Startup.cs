
using AutoMapper;
using Emendas.Data;
using Emendas.Web.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Emendas.Web
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
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });
            //services.AddLogging(builder =>
            //{
            //    builder.AddConfiguration(Configuration.GetSection("Logging"))
            //        .AddConsole()
            //        .AddDebug()
            //        ;


            //});
            //TODO tirar em productio 
            services.AddCors(c =>
            {
                c.AddPolicy("AllowOrigin", options => options.AllowAnyOrigin());
            });



            services.AddAutoMapper();




            //services.AddDbContext<EmendasContext>(cfg => cfg.UseSqlServer(Configuration.GetConnectionString("EmendasConnectionString")));
            //Add PostgreSQL support
            services.AddDbContext<EmendasContext>(options => {
                options.UseNpgsql(Configuration.GetConnectionString("EmendasPostgresConnectionString"));
            });

            //Add SQL Server support
            //services.AddDbContext<CustomersDbContext>(options => {
            //    options.UseSqlServer(Configuration.GetConnectionString("CustomersSqlServerConnectionString"));
            //});

            //Add SqLite support
            //services.AddDbContext<EmendasContext>(options => {
            //    options.UseSqlite(Configuration.GetConnectionString("EmendasSqliteConnectionString"));
            //});






            services.AddTransient<IMailService, NullMailService>();
            services.AddScoped<IEmendasRepository, EmendasRepository>();
            
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2).AddJsonOptions(cfg=> cfg.SerializerSettings.ReferenceLoopHandling= Newtonsoft.Json.ReferenceLoopHandling.Ignore);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();

                app.UseCors(options => options.AllowAnyOrigin());
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
           

           
            //app.UseHttpsRedirection();
           // app.UseDefaultFiles();
            app.UseStaticFiles();
            //app.UseCookiePolicy();
            app.UseMvc(cfg =>
            {
                cfg.MapRoute("Default",
                    "/{controller}/{action}/{id?}",
                    new { Controller = "App", Action = "Index" });
            }
            );
            //app.UseMvc(routes =>
            //{
            //    routes.MapRoute(
            //        name: "default",
            //        template: "{controller=Home}/{action=Index}/{id?}");
            //});
            app.UseNodeModules(env);
        }
    }
}
