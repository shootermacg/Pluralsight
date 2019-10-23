using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WiredBrainCoffee.Services;

namespace WiredBrainCoffee
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
            services.AddMvc().AddRazorPagesOptions(options =>
            {
                options.Conventions.AddPageRoute("/Index", "Wired");
                options.Conventions.AddPageRoute("/Index", "Home");
                //options.RootDirectory = "/Features";
            });

            services.Configure<RouteOptions>(options =>
            {
                options.ConstraintMap.Add("promo", typeof(PromoConstraint));
            });

            services.AddScoped<IMenuService, MenuService>();

            services.AddLogging();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.Use(async (context, next) =>
            {
                //check that the request url contains the work alive
                if(context.Request.Path.Value.Contains("alive"))
                {
                    await context.Response.WriteAsync("The app is alive");
                }
                else
                {
                    //if not pass the request onto the next middleware in the pipeline.
                    Debug.WriteLine("Before Razor Page");
                    await next.Invoke();
                    Debug.WriteLine("After Razor Page");
                }
            });

            if (env.IsDevelopment())
            {
                app.UseBrowserLink();
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
            }

            app.UseStaticFiles();

            app.UseMvc();
        }
    }
}
