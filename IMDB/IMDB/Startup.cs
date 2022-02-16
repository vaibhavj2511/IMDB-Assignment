using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SessionDemoApp;
using SessionDemoApp.Repository;
using SessionDemoApp.Services;
using SessionDemoApp.Helper;
using Microsoft.OpenApi.Models;

namespace IMDB
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; set; }
        public string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy(MyAllowSpecificOrigins,
                    builder => { builder.WithOrigins("localhost:5500").AllowAnyHeader().AllowAnyMethod(); });
            });
            services.Configure<ConnectionString>(Configuration.GetSection("ConnectionString"));

            services.AddScoped(typeof(ISqlHelper<>), typeof(SqlHelper<>));

            services.AddScoped<IActorRepository, ActorRepository>();
            services.AddScoped<IProducerRepository, ProducerRepository>();
            services.AddScoped<IGenreRepository, GenreRepository>();
            services.AddScoped<IMovieRepository, MovieRepository>();
            services.AddScoped<IMovieService, MovieService>();

            services.AddControllers().AddNewtonsoftJson();

            services.AddCors(options => options.AddPolicy("MyPolicy",
                    builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader()
                ));
            services.AddSwaggerGen(c => {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "Test API",
                    Description = "A simple example for swagger api information",
                    TermsOfService = new Uri("https://example.com/terms")
                 });
            });
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

            app.UseCors("MyPolicy");

            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My Test1 Api v1");
            });
        }
    }
}
