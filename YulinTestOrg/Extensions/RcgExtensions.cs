using YulinTestOrg.Interface;
using YulinTestOrg.Service.RcgService;

namespace YulinTestOrg.Extensions
{
    public static class RcgExtensions
    {
        public static IServiceCollection AddRcgExtension(this IServiceCollection services)
        {
            services.AddScoped<IRcgApiService, RcgApiService>();
            services.AddScoped<IRcgBetRecordService, RcgBetRecordService>();
            return services;
        }

        public static void UseRcgExtension(this IApplicationBuilder app)
        {

        }
    }
}
