using Coravel.Invocable;
using Microsoft.Extensions.Options;
using YulinTestOrg.Data;
using YulinTestOrg.Interface;
using YulinTestOrg.Utility.Setting;

namespace YulinTestOrg.Schedule
{
    public class RcgGetBetAreaListSchedule : IInvocable
    {
        private readonly ILogger<RcgGetBetAreaListSchedule> logger;
        private readonly IRcgApiService rcgApiService;
        private readonly Appsetting appsetting;
        private readonly IRcgBetAreaService rcgBetAreaService;

        public RcgGetBetAreaListSchedule(ILogger<RcgGetBetAreaListSchedule> logger,
                                         IRcgApiService rcgApiService,
                                         IOptions<Appsetting> appsetting,
                                         IRcgBetAreaService rcgBetAreaService)
        {
            this.logger = logger;
            this.rcgApiService = rcgApiService;
            this.appsetting = appsetting.Value;
            this.rcgBetAreaService = rcgBetAreaService;
        }

        public async Task Invoke()
        {
            await ExecuteAsync();

            GC.Collect();
            GC.WaitForPendingFinalizers();
        }

        private async Task ExecuteAsync()
        {
            try
            {
                var betAreaList = await this.rcgBetAreaService.Get();
                var rcgBetArea = await this.rcgApiService.GetBetAreaList();
                rcgBetArea = rcgBetArea
                    .Where(x => x.Lang == "zh-TW")
                    .ToList();

                foreach (var item in rcgBetArea)
                {
                    var target = betAreaList.FirstOrDefault(x => x.GameId == item.GameId
                                                                 && x.GameName == item.GameName
                                                                 && x.BetArea == item.BetArea);
                    if (target == null)
                    {
                        await this.rcgBetAreaService.Add(new RcgBetArea
                        {
                            GameId = item.GameId,
                            GameName = item.GameName,
                            BetArea = item.BetArea,
                            Context = item.Context,
                            Lang = item.Lang,
                        });
                    }
                    else
                    {
                        await this.rcgBetAreaService.Update(new RcgBetArea
                        {
                            Id = target.Id,
                            GameId = item.GameId,
                            GameName = item.GameName,
                            BetArea = item.BetArea,
                            Context = item.Context,
                            Lang = item.Lang,
                        });
                    }
                }

                this.logger.LogInformation("RcgGetBetArea Sync Finish");
            }
            catch (Exception ex)
            {
                this.logger.LogError("RcgGetBetArea Sync Error {Error}", ex);
            }
        }
    }
}
