using CommSights_Api.Data.ModelCommSights;
using Microsoft.EntityFrameworkCore;

namespace CommSights_Api.Main.DIExtensions
{
    public static class SystemDatabase
    {
        public static IServiceCollection AddSystemDatabase(this IServiceCollection services, IConfiguration configuration)
        {
            //builder.Services.AddDbContext<CommSightsContext>(options =>
            //     options.UseSqlServer(builder.Configuration.GetConnectionString("CommSightsContext") ??
            //                            throw new InvalidOperationException("Connection string 'CommSightsContext' not found."),
            //                            b => b.MigrationsAssembly("CommSights_Api.Database")));
            services.AddDbContext<CommSightsContext>(options =>
            {
                options.UseSqlServer(
                    configuration.GetConnectionString("CommSightsContext")
                    ?? throw new InvalidOperationException("Connection string 'CommSightsContext' not found."),
                    sqlServerOptionsAction: sqlOptions =>
                    {
                        sqlOptions.EnableRetryOnFailure(
                            maxRetryCount: 5,
                            maxRetryDelay: TimeSpan.FromSeconds(30),
                            errorNumbersToAdd: null
                        );
                    });
            }, ServiceLifetime.Scoped);
            return services;
        }
    }
}
