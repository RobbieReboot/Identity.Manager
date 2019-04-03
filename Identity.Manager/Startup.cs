using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Identity.DbContexts;
using Identity.TokenService.Types;
using IdentityManager2.Configuration;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Identity.Manager
{
    public class Startup
    {
        public string CoreIDConnectionString { get; set; }

        public Startup(IConfiguration config)
        {
            CoreIDConnectionString = config["ConnectionStrings:SQLCONNSTR_CoreIdentity"];

        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddIdentityManager()
                .AddIdentityMangerService<AspNetCoreIdentityManagerService<ApplicationUser, int,
                    ApplicationRole, int>>();
            //services.AddDbContext<IdentityDbContext>(opt => opt.UseInMemoryDatabase("test"));
            services.AddDbContext<ApplicationDbContext>(builder =>
                builder.UseSqlServer(CoreIDConnectionString));
            services.AddIdentity<ApplicationUser, ApplicationRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();
            //services.AddIdentity<ApplicationUser, ApplicationRole>()
            //    .AddEntityFrameworkStores<ApplicationDbContext>()
            //    .AddDefaultTokenProviders();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseAuthentication();

            app.UseIdentityManager();

            app.Run(async (context) =>
            {
                await context.Response.WriteAsync("Hello World!");
            });
        }
    }
}
