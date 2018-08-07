using System;
using System.Collections.Generic;
using System.IO;
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
using Swashbuckle.AspNetCore.Swagger;

using Microsoft.Extensions.PlatformAbstractions;
using Logs.Interface;
using Logs.Bussiness;
using Logs.Repository;
using ReciveData.Domain.Service;
using ReciveData.Domain.Intefaces.Service;
using ReciveData.Repository.MySQLConnection;
using ReciveData.Domain.Intefaces.Repositories;
using ReciveData.Repository.MongoDB;

namespace ReciveData
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();

            configuration = builder.Build();
        }

        public IConfiguration configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //log
            services.AddScoped<IReceiveDataBussinessLogs, ReceiveDataBussinessLogs>();
            services.AddScoped<IReceiveDataRepositoryLogs, ReceiveDataRepositoryLogs>();

            //MVC
            services.AddScoped<IReceiveDataService, ReceiveDataService>();
            services.AddScoped<IReceiveDataRepository, ReceiveDataRepository>();
            services.AddScoped<IReceiveDataMongoRepository, ReceiveDataMongoRepository>();

            //services.AddDbContext<>();

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            // Swagger Config
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1",
                    new Info
                    {
                        Title = "Reciver of Data",
                        Version = "v1",
                        Description = "Exemplo de API REST criada com o ASP.NET Core",
                        Contact = new Contact
                        {
                            Name = "Paulo Victor Souza Mendes",
                            Url = "https://github.com/Pvmendes"
                        }
                    });

                string aplicationPath = PlatformServices.Default.Application.ApplicationBasePath;
                string aplicationName = PlatformServices.Default.Application.ApplicationName;
                string pathXmlDoc = Path.Combine(aplicationPath, $"{aplicationName}.xml");

                c.IncludeXmlComments(pathXmlDoc);
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            app.UseMvc();

            // Active middlewares for Swagger use
            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Reciver of Data");
                c.RoutePrefix = "swagger";
            });

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            //app.UseHttpsRedirection();
            //app.UseMvc();
        }
    }
}
