using System;
using System.Collections.Generic;
using DependencyInjector.API.Infraestructure.Service.Interfaces;
using DependencyInjector.API.Infraestructure.Service.ServiceClient;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DependencyInjector.API
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            RegisterServices(services);
        }

        private void RegisterServices(IServiceCollection services)
        {
            var dependencyInjector = this.Configuration.GetSection("DependencyInjector");

            switch (dependencyInjector.Value)
            {
                case "Scoped":
                    RegisterScoped(services);
                    break;
                case "Singleton":
                    RegisterSingleton(services);
                    break;
                case "Transient":
                    RegisterTransient(services);
                    break;
            }
        }

        private void RegisterScoped(IServiceCollection services)
        {
            services.AddScoped<IService, Service>();
            services.AddScoped<SecondService>();
        }

        private void RegisterSingleton(IServiceCollection services)
        {
            services.AddSingleton<IService, Service>();
            services.AddSingleton<SecondService>();
        }

        private void RegisterTransient(IServiceCollection services)
        {
            services.AddTransient<IService, Service>();
            services.AddTransient<SecondService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
