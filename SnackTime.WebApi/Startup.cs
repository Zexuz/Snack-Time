using Autofac;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json.Serialization;
using SnackTime.WebApi.Middlewares;

namespace SnackTime.WebApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.

        public void ConfigureContainer(ContainerBuilder builder)
        {
            builder.RegisterModule(new DependencyModule());
            builder.RegisterModule(new Mpv.JsonIpc.DependencyModule());
            builder.RegisterModule(new Core.DependencyModule(
                new Core.DependencyModule.SonarrConfig
                {
                    Host = "localhost",
                    Port = 8989,
                    ApiKey = "2e8fcac32bf147608239cab343617485"
                })
            );
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc()
                .SetCompatibilityVersion(CompatibilityVersion.Version_3_0)
                .AddNewtonsoftJson(options => options.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver());

            AddSwagger(services);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseLoggingMiddleware();
            
            if (env.IsDevelopment())
            {
                app.UseCors(builder => builder
                    .AllowAnyHeader()
                    .AllowAnyMethod()
                    .AllowAnyOrigin()
                    .Build()
                );
                app.UseDeveloperExceptionPage();

                app.UseSwagger().UseSwaggerUI(c => { c.SwaggerEndpoint("/swagger/v1/swagger.json", "HTTP API V1"); });
            }
            else
            {
                app.UseHsts();
            }

            app.UseMvc();
        }

        private static void AddSwagger(IServiceCollection services)
        {
            services.AddSwaggerGen(options =>
            {
                options.DescribeAllEnumsAsStrings();
                options.DescribeStringEnumsInCamelCase();
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "HTTP API",
                    Version = "v1",
                    Description = "The Service HTTP API",
                });
            });
        }
    }
}