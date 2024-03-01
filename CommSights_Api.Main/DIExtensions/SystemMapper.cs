

using CommSights_Api.Abstractions.Maper;

namespace CommSights_Api.Main.DIExtensions
{
    public static class SystemMapper
    {
        public static IServiceCollection AddMapper(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(AutoMapperTmpUploadExcelMonthls));
            return services;
        }
    }
}
