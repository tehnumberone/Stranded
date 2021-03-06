using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Stranded.Context.Interfaces;
using Stranded.Context.SQLContext;
using Stranded.Repositories;

namespace Stranded
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
            services.AddDistributedMemoryCache();

            services.AddSession(options =>
            {
                // Set a short timeout for easy testing.
                options.IdleTimeout = TimeSpan.FromMinutes(20);
                options.Cookie.HttpOnly = true;
                // Make the session cookie essential
                options.Cookie.IsEssential = true;
            });
            services.AddTransient<ICharacterContext, CharacterContext>();
            services.AddScoped<CharacterRepo>();
            services.AddTransient<IAccountContext, AccountContext>();
            services.AddScoped<AccountRepo>();
            services.AddTransient<IItemContext, ItemContext>();
            services.AddScoped<ItemRepo>();
            services.AddTransient<ICollectableContext, CollectableContext>();
            services.AddScoped<CollectableRepo>();
            services.AddTransient<IBedContext, BedContext>();
            services.AddScoped<BedRepo>();
            services.AddTransient<IMapContext, MapContext>();
            services.AddScoped<MapRepo>();
            services.AddTransient<IAnimalContext, AnimalContext>();
            services.AddScoped<AnimalRepo>();
            services.AddControllersWithViews().AddRazorRuntimeCompilation();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
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
            app.UseSession();
            app.UseRouting();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
