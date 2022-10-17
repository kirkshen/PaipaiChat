// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace paipaichat
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            //register the service required by signalR hubs
            services.AddControllersWithViews();
            services.AddSignalR().AddAzureSignalR("Endpoint=https://paipaisignalr.service.signalr.net;AccessKey=xvCB88J0XjYLkhO1oQ6yO9j5nGnSXWb/kysDihoDB4I=;Version=1.0;");// Endpoint=https://paipaisignalr.service.signalr.net;AccessKey=xvCB88J0XjYLkhO1oQ6yO9j5nGnSXWb/kysDihoDB4I=;Version=1.0;
            services.AddSingleton(async x => await RedisConnection.InitializeAsync(connectionString: Configuration["CacheConnection"].ToString()));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseDefaultFiles();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseAuthorization();
            //configure endpoint
            app.UseEndpoints(endpoints =>
            {
                //map chat hub to "/chat" dir
                endpoints.MapHub<Chat>("/chat");
                endpoints.MapHub<Entry>("/entry");
                // endpoints.MapControllerRoute(
                //     name: "default",
                //     pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}