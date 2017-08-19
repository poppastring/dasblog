using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Rewrite;
using DasBlog.Web.UI.Models;
using Microsoft.AspNetCore.Mvc.Razor;
using DasBlog.Web.UI.ViewsEngine;
using DasBlog.Web.UI.Core;
using System.Security.Principal;
using Microsoft.AspNetCore.Http;
using DasBlog.Web.UI.Repositories.Interfaces;
using DasBlog.Web.UI.Repositories;
using Microsoft.Extensions.FileProviders;
using System.Reflection;

namespace DasBlog.Web.UI
{
    public class Startup
    {
        private IHostingEnvironment _hostingEnvironment;

        public Startup(IConfiguration configuration, IHostingEnvironment env)
        {
            Configuration = configuration;
            _hostingEnvironment = env;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddOptions();
            // services.Configure<DasBlogSettings>(Configuration.GetSection("DasBlogSettings"));

            services.Configure<RazorViewEngineOptions>(rveo => {
                rveo.ViewLocationExpanders.Add(new DasBlogLocationExpander(Configuration.GetSection("DasBlogSettings")["Theme"]));
            });

            services.AddTransient<IDasBlogSettings>(provider =>
                     new DasBlogSettings(Configuration.GetSection("DasBlogSettings")["LogsDirectory"],
                                        Configuration.GetSection("DasBlogSettings")["ContentDirectory"],
                                        Configuration.GetSection("DasBlogSettings")["Theme"], 
                                        _hostingEnvironment.WebRootPath
                                        ));

            services.AddSingleton<IBlogRepository, BlogRepository>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddTransient<IPrincipal>(provider =>
                        provider.GetService<IHttpContextAccessor>().HttpContext.User);

            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });

            RewriteOptions options = new RewriteOptions()
                 .AddIISUrlRewrite(env.ContentRootFileProvider, @"Config\IISUrlRewrite.xml");

            app.UseRewriter(options);
        }
    }
}
