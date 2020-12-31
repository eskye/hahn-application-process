namespace Hahn.ApplicatonProcess.December2020.Web.Configuration
{
    using Data;
    using Domain.Interfaces;
    using Domain.Services; 
    using Microsoft.Extensions.DependencyInjection;

    public static class ConfigureCoreServices
    {
        public static IServiceCollection AddCoreServices(this IServiceCollection services)
        {
            services.AddScoped(typeof(IAsyncRepository<>), typeof(EfRepository<>));
            services.AddScoped<IApplicantService, ApplicantService>();

            return services;
        }
    }
}
