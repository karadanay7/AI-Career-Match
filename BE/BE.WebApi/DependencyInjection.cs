using BE.Application.Common.Interfaces;
using BE.WebApi.Services;

namespace BE.WebApi
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddWebServices(this IServiceCollection services,IConfiguration configuration)
        {
            services.AddHttpContextAccessor();

            services.AddScoped<ICurrentUserService, CurrentUserManager>();

            return services;
        }
    }
}
