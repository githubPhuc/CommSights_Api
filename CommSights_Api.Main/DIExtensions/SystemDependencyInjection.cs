using CommSights_Api.Abstractions.Services;
using CommSights_Api.Abstractions.Utilities;
using CommSights_Api.Core.Interfaces;
using CommSights_Api.Library.Helps;
using Microsoft.EntityFrameworkCore;

namespace CommSights_Api.Main.DIExtensions
{
    public static class SystemDependencyInjection
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<ICoreUploadGoogleSearch, CoreUploadGoogleSearchService>();
            services.AddScoped<IQcMonthly, QcMonthlyService>();
            services.AddScoped<IConfigRepository, ConfigRepositoryService>();
            services.AddScoped<IMembershipPermissionRepository, MembershipPermissionRepositoryServices>();
            services.AddScoped<IProductPropertyRepository, ProductPropertyRepositoryService>();
            services.AddScoped<AppGlobal>();
            return services;
        }
    }
}
