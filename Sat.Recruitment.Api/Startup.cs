using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Sat.Recruitment.Api.ExceptionHandler;
using Sat.Recruitment.Data;
using Sat.Recruitment.Data.Repositories;
using Sat.Recruitment.Service.Interfaces;
using Sat.Recruitment.Service.MappingProfiles;
using Sat.Recruitment.Service.Services;
using Sat.Recruitment.Service.Utils;

namespace Sat.Recruitment.Api
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
            services.Configure<ApiBehaviorOptions>(opt =>
            {
                opt.SuppressModelStateInvalidFilter = true;
            });
            services.AddControllers(
                //add unhandled exception filter
                options =>
                {
                    options.Filters.Add<UnhandledExceptionFilterAttribute>();
                    options.Filters.Add<ValidationFilter>();
                });
            
            
            services.AddSwaggerGen();
            services.SetUpAppDependencies(Configuration.GetConnectionString("defaultConnection"));
            
            //DI
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IUserTypeRepository, UserTypeRepository>();
            services.AddTransient<IFunctions, Functions>();
            
            
            //Adding automapper
            var mapperConfig = new MapperConfiguration(m => { m.AddProfile(new AutoMapperProfiles()); });
            IMapper mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);
            


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env,ILogger<Startup> logger)
        {
            if (env.IsDevelopment())
            {
                app.UseSwagger();
                //app.UseDeveloperExceptionPage();
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
                });
            }
            

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
            // specifying the Swagger JSON endpoint.
            
            app.UseRouting();

            app.UseAuthorization();
            
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
