using System;
using System.Net.Http;
using Hahn.ApplicatonProcess.December2020.Web.Filters;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Hahn.ApplicatonProcess.December2020.Web.Services;

namespace Hahn.ApplicatonProcess.December2020.Web.Configuration
{
    public static class ConfigureWebServices
    {
       
        public static IServiceCollection AddWebServices(this IServiceCollection services)
        {
            services.AddSingleton<ValidatorActionFilterAttribute>();
            services.AddSingleton<ApiExceptionFilter>();
            services.Configure<MvcOptions>(options =>
            {
                options.Filters.AddService<ValidatorActionFilterAttribute>();
                options.Filters.AddService<ApiExceptionFilter>();
            });

            services.Configure<ApiBehaviorOptions>(options => options.SuppressModelStateInvalidFilter = true);

            services.AddScoped<IValidateCountryName, ValidateCountryName>();

            services.AddScoped(sp => new HttpClient() { BaseAddress = new Uri("https://restcountries.eu") });
            return services;
        }
    }
}
