﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using SistemaVotacao.Dominio._Base;
using SistemaVotacao.Ioc;
using Swashbuckle.AspNetCore.Swagger;


namespace SistemaVotacao.Api
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
            StartupIoc.ConfigureServices(services, Configuration);
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            services.AddSwaggerGen(c =>
            {

                c.SwaggerDoc("v1",
                    new Info
                    {
                        Title = "Eleição de recursos",
                        Version = "v1",
                        Description = "Exemplo de API REST criada com o ASP.NET Core 2.2 para sistema de eleição de recurso internos de uma empresa pelos funcionários",
                        Contact = new Contact
                        {
                            Name = "Vitor Abreu",
                            Url = "https://github.com/vitorvaf"
                        }
                    });
            });
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

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Eleição de recursos V1");
            });
            app.Use(async (context, next) =>
            {
                await next.Invoke();

                var unitOfWork = (IUnitOfWork)context.RequestServices.GetService(typeof(IUnitOfWork));
                await unitOfWork.Commit();
            });

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
