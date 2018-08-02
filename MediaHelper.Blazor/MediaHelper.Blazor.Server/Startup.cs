using Microsoft.AspNetCore.Blazor.Server;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;
using System.Net.Mime;
using Autofac;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using Swashbuckle.AspNetCore.Swagger;

namespace MediaHelper.Blazor.Server
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
            #region Blazer

            // Adds the Server-Side Blazor services, and those registered by the app project's startup.
            services.AddServerSideBlazor<App.Startup>();

            services.AddResponseCompression(options =>
            {
                options.MimeTypes = ResponseCompressionDefaults.MimeTypes.Concat(new[]
                {
                    MediaTypeNames.Application.Octet,
                    WasmMediaTypeNames.Application.Wasm,
                });
            });

            #endregion
          
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            services.AddSignalR();
            
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "My API", Version = "v1" });
            });
            
        }
        
        public void ConfigureContainer(ContainerBuilder builder)
        {
//            builder.RegisterModule(new AutofacModule(Configuration));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseResponseCompression();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }
            
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.), 
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });
            
            app.UseCors(builder => builder.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin().AllowCredentials().Build());

            app.UseMvc();

//            app.UseSignalR(routes => { routes.MapHub<MediaPlayerHub>("/ws/mediaPlayerHub"); });

            // Use component registrations and static files from the app project.
            app.UseServerSideBlazor<App.Startup>();
            
            SetupEventListener();
        }
        
        private void SetupEventListener()
        {
            var factory = new ConnectionFactory() {HostName = "localhost"};
            var connection = factory.CreateConnection();
            var channel = connection.CreateModel();
            
            channel.QueueDeclare(queue: "hello",
                durable: false,
                exclusive: false,
                autoDelete: false,
                arguments: null);

            var consumer = new EventingBasicConsumer(channel);
            consumer.Received += (model, ea) =>
            {
//                var infoChanged = PlayingMediaInfoChanged.Parser.ParseFrom(ea.Body);
//                seriesService.NewSeriesInMediaPlayer(infoChanged.MediaInfo);
            };
            channel.BasicConsume(queue: "hello",
                autoAck: true,
                consumer: consumer);
        }
    }
}