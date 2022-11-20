using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;

namespace Yara.Infrastructure.IOC
{
    public static class Validation
    {
        public static IServiceCollection AddValidation(this IServiceCollection services)
        {
            services.AddMvcCore()
                .AddFluentValidation(fv =>
                {
                    fv.ImplicitlyValidateChildProperties = true;
                });

          

            return services;
        }
    }
}
