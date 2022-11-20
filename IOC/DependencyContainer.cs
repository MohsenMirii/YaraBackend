using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;

namespace Yara.Infrastructure.IOC
{
    public static class DependencyContainer
    {
        public static IServiceCollection AddDependencies(this IServiceCollection services,  IConfiguration Configuration)
        {
            // Application Services
          /*  var appSettingSection = Configuration.GetSection("AppSettings");
            services.Configure<AppSetting>(appSettingSection);
            services.AddAuthorization(appSettingSection.Get<AppSetting>());


            
            
            services.AddScoped<IAccount_BL, Account_BL>();
          

            
            services.AddScoped<IGenericRepository_BL<DataModel.DomainClasses.Analysis>, Analysis_BL>();
            
            services.AddScoped<IPermission_BL, Permission_BL>();
            */

            return services;
        }
    }
}

