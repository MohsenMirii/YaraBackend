using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json.Serialization;
using Yara.Infrastructure.Data.Context;
using Microsoft.EntityFrameworkCore;
using MediatR;
using System.Reflection;
using FluentValidation.AspNetCore;

using DataAccess.Config;
using System.Text;

namespace Yara.WebApi
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
            // Framework Services
            //services.AddValidation();
            services.AddMvcCore()
              .AddFluentValidation(fv =>
              {
                  fv.ImplicitlyValidateChildProperties = true;
              });


            services.AddControllers().AddNewtonsoftJson(options =>
                {
                    options.SerializerSettings.ContractResolver = new DefaultContractResolver();
                    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
                    options.SerializerSettings.PreserveReferencesHandling = Newtonsoft.Json.PreserveReferencesHandling.None;
                    options.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
                });
            
            services.AddDbContext<YaraContext>(options => options.UseSqlServer(Configuration.GetConnectionString("Yara")));
           
//            services.AddDependencies(Configuration);

            var appSettingSection = Configuration.GetSection("AppSettings");
            services.Configure<AppSetting>(appSettingSection);
            services.AddAuthorization(appSettingSection.Get<AppSetting>());

           
            services.AddCors(options =>
            {
                options.AddPolicy("MyAllowHeadersPolicy",
                      builder =>
                      {
                          builder.AllowAnyOrigin()
                                 .AllowAnyMethod()
                                 .AllowAnyHeader();
                      });
            });
            services.AddSwaggerGen(c =>{});

            //IServiceCollection serviceCollection = services.AddMediatR(typeof(Command).GetTypeInfo().Assembly);
            services.AddMediatR(Assembly.GetExecutingAssembly());

        }


        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "SSS"));
            }
            else
            {
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "SSS"));
            }
            
            app.UseRouting();

            app.UseCors(option =>
                option.AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader()
                    );

            app.UseAuthentication();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });


           
        }

      
    }
}
