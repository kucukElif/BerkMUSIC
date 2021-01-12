using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL.Abstract;
using BLL.Repository;
using DAL.Context;
using DAL.Entity;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace BerkMusicUI
{
    public class Startup
    {
        private readonly IConfiguration configuration;

        public Startup(IConfiguration configuration)
        {

            this.configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc(x => x.EnableEndpointRouting = false);
            services.AddDbContext<AppDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"), b => b.MigrationsAssembly("BerkMusicUI")));
            services.AddIdentity<AppUser, AppUserRole>().AddEntityFrameworkStores<AppDbContext>();
            
            services.AddTransient<IPostService, PostRepository>();
            services.AddTransient<ILayoutService, LayoutService>();
            services.AddTransient<IFullLayoutService, FullLayoutService>();

            services.AddTransient<IIdentityService, IdentityRepository>();
            services.AddTransient<INavbarService,NavbarRepository>();
            services.AddTransient<IPhotoService, PhotoRepository>();

            services.AddTransient<IPriceService, PriceRepository>();
            services.AddTransient<IReferanceService,ReferanceRepository>();
            services.AddTransient<IInformationService, InformationRepository>();
            services.AddTransient<ICategoryService, CategoryRepository>();
            services.AddTransient<ICommentService, CommentRepository>();
            services.AddTransient<IVideoService, VideoRepository>();
          

            //Identity



            ////Cookie
            //services.ConfigureApplicationCookie(x => {
            //    x.LoginPath = new PathString("/Account/Login");
            //    x.Cookie = new CookieBuilder
            //    {
            //        Name = "LoginCookie",
            //        Expiration = null
            //    };
            //    x.ExpireTimeSpan = TimeSpan.FromMinutes(5);
            //});

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseAuthentication();
            app.UseAuthorization();
            app.UseRouting();

            app.UseStaticFiles();
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                  name: "areas",
                  template: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
                );

                routes.MapRoute(
               name: "default",
               template: "{controller=Home}/{action=PreLoad}/{id?}"
             );


            });
        }
    }
}
