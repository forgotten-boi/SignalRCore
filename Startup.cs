﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace AspNetCore.SignalR
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAuthentication().AddJwtBearer(options=>
                options.Events = new JwtBearerEvents {
                    OnMessageReceived = context =>{
                        var accessToken = context.Request.Query["access_token"];
                        if(string.IsNullOrEmpty(accessToken)==false)
                        {   
                            context.Token = accessToken;
                        }
                        return Task.CompletedTask;
                    }
                });
            services.AddMvc();
            services.AddSignalR();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseStaticFiles();
            app.UseSignalR(config =>
            {
                config.MapHub<StreamHub>("/streamHub");
                config.MapHub<MessageHub>("/messages");
            });
            app.UseMvc();
            app.UseRouting(routes =>
            {
               
                routes.MapGet("/", async context =>
                {
                    //context.Response.Redirect("/pages");
                    await context.Response.WriteAsync("Hello World!");
                });
            });
        }
    }
}
