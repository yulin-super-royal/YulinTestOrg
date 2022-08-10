using Coravel;
using Microsoft.Extensions.Options;
using YulinTestOrg.Schedule;
using YulinTestOrg.Utility.Setting;

namespace YulinTestOrg.Extensions
{
    public static class CoravelExtensions
    {
        public static IServiceCollection AddCoravelExtension(this IServiceCollection services)
        {
            services.AddQueue();
            services.AddScheduler();

            services.AddTransient<RcgGetBetRecordListSchedule>();

            return services;
        }

        public static void UseCoravelSchedule(this IApplicationBuilder app)
        {
            var provider = app.ApplicationServices;
            var appSetting = provider.GetRequiredService<IOptions<Appsetting>>().Value;

            provider.UseScheduler(scheduler =>
            {
                scheduler.Schedule<RcgGetBetRecordListSchedule>()
                    .EverySeconds(appSetting.RCGSetting.RcgGetBetRecordListCron)
                    .PreventOverlapping("RcgGetBetRecordListSchedule");
            });
        }
    }
}
