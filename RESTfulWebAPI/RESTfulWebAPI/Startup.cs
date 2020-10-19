using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using RESTfulWebAPI.Application;
using RESTfulWebAPI.Application.Movie.Commands;
using RESTfulWebAPI.Application.Movie.Querys;
using RESTfulWebAPI.Infrastructure;

namespace RESTfulWebAPI
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
            services.AddTransient<ISearchMovieQuery, SearchMovieQuery>();
            services.AddTransient<IDataBaseService, DataBaseService>();
            services.AddTransient<IUpdateMovieCommand, UpdateMovieCommand>();
            services.AddTransient<ICreateMovieCommand, CreateMovieCommand>();


            services.AddControllers();
            services.AddOpenApiDocument();

            services.AddDbContext<DataBaseService>(options =>
            {
                options.UseNpgsql(Configuration.GetValue<string>("ConnString"));
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseOpenApi(); 

            app.UseSwaggerUi3(); 

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
