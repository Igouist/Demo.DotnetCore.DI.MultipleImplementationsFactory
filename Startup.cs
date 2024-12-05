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

namespace Demo.DotnetCore.DI.MultipleImplementationsFactory
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
            
            services.AddTransient<IColor, Red>();
            services.AddTransient<IColor, Yellow>();
            services.AddTransient<IColor, Blue>();
            
            // 先各自註冊每個實作對應的介面，確保各自可以獨立使用
            services.AddTransient<IFruit<Red>, Apple>();
            services.AddTransient<IFruit<Yellow>, Banana>();
            services.AddTransient<IFruit<Blue>, Huckleberry>();
            
            // 再透過泛型把所有實作註冊到同一組最上層的介面，方便後續一起使用
            services.AddTransient<IFruit>(sp => sp.GetRequiredService<IFruit<Red>>());
            services.AddTransient<IFruit>(sp => sp.GetRequiredService<IFruit<Yellow>>());
            services.AddTransient<IFruit>(sp => sp.GetRequiredService<IFruit<Blue>>());
            
            services.AddSingleton<IFruitFactory, FruitFactory>();
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

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
