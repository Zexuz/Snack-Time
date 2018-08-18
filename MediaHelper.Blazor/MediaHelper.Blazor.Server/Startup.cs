using System;
using Microsoft.AspNetCore.Blazor.Server;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;
using System.Net.Mime;
using Autofac;
using MediaHelper.Backend;
using MediaHelper.Blazor.Server.Controllers.v1;
using MediaHelper.Blazor.Server.DependencyModules;
using MediaHelper.EventBus;
using MediaHelper.Model;
using MediaHelper.Protobuf.generated;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
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

            services.AddSwaggerGen(c => { c.SwaggerDoc("v1", new Info {Title = "My API", Version = "v1"}); });
        }

        public void ConfigureContainer(ContainerBuilder builder)
        {
            builder.RegisterModule(new AutofacModule(Configuration));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, IEventBus eventBus)
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
            app.UseSwaggerUI(c => { c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1"); });

            app.UseCors(builder => builder.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin().AllowCredentials().Build());

            app.UseMvc();

//            app.UseSignalR(routes => { routes.MapHub<MediaPlayerHub>("/ws/mediaPlayerHub"); });

            // Use component registrations and static files from the app project.
            app.UseServerSideBlazor<App.Startup>();

            SetupEventListener(eventBus);
        }

        private void SetupEventListener(IEventBus eventBus)
        {
            eventBus.Subscribe("hello", (sender, data) =>
            {
                var _medieFileService = new MedieFileService();
                var playingInfo = PlayingMediaInfoChanged.Parser.ParseFrom(data).MediaInfo;

                var mediaFile = new SeriesFile()
                {
                    SeriesId = CurrentlyPlayingManager.EpisodeFile.SeriesId,
                    LastWatched = DateTimeOffset.Now,
                    IdFromProvider = CurrentlyPlayingManager.EpisodeFile.Id,
                    Length = TimeSpan.FromSeconds(playingInfo.Duration),
                    Watched = TimeSpan.FromSeconds(playingInfo.Eplipsed),
                };

                if (CurrentlyPlayingManager.EpisodeFile.Id == mediaFile.IdFromProvider)
                {
                    if (mediaFile.Watched < TimeSpan.FromSeconds(5))
                    {
                        var file = _medieFileService.GetLastWatched();
                        if (file.IsCompleted)
                            mediaFile.Watched = mediaFile.Length;
                    }
                }

                _medieFileService.AddOrUpdate(mediaFile);
            });
        }
    }
}