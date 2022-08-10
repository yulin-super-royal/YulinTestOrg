using Coravel.Invocable;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using YulinTestOrg.Data;
using YulinTestOrg.Interface;
using YulinTestOrg.Utility.Setting;

namespace YulinTestOrg.Schedule
{
    public class RcgGetBetRecordListSchedule : IInvocable
    {
        private readonly ILogger<RcgGetBetRecordListSchedule> logger;
        private readonly IRcgApiService rcgApiService;
        private readonly Appsetting appsetting;
        private readonly IRcgBetRecordService rcgBetRecordService;

        public RcgGetBetRecordListSchedule(ILogger<RcgGetBetRecordListSchedule> logger,
                                           IRcgApiService rcgApiService,
                                           IOptions<Appsetting> appsetting,
                                           IRcgBetRecordService rcgBetRecordService)
        {
            this.logger = logger;
            this.rcgApiService = rcgApiService;
            this.appsetting = appsetting.Value;
            this.rcgBetRecordService = rcgBetRecordService;
        }

        public async Task Invoke()
        {
            await ExecuteAsync();

            GC.Collect();
            GC.WaitForPendingFinalizers();
        }

        private async Task ExecuteAsync()
        {
            while (true)
            {
                var maxId = await this.rcgBetRecordService.GetMaxId();
                var betRecordList = await this.rcgApiService.GetBetRecordList(maxId);
                if (betRecordList.DataList.Count == 0)
                {
                    logger.LogInformation("RcgGetBetRecordList Finish");
                    break;
                }
                else
                {
                    logger.LogInformation("RcgGetBetRecordList - {Count}", betRecordList.DataList.Count);
                }

                var addBetRecordList = new List<RcgBetRecord>();
                foreach (var item in betRecordList.DataList)
                {
                    addBetRecordList.Add(new RcgBetRecord
                    {
                        MemberAccount = item.MemberAccount,
                        Id = item.Id,
                        GameId = item.GameId,
                        Desk = item.Desk,
                        BetArea = item.BetArea,
                        Bet = item.Bet,
                        Available = item.Available,
                        WinLose = item.WinLose,
                        WaterRate = item.WaterRate,
                        ActiveNo = item.ActiveNo,
                        RunNo = item.RunNo,
                        Balance = item.Balance,
                        DateTime = item.DateTime,
                        ReportDT = item.ReportDT,
                        Ip = item.Ip,
                        Odds = item.Odds,
                        OriginRecordId = item.OriginRecordId
                    });
                }

                await this.rcgBetRecordService.Import(addBetRecordList);
                await Task.Delay(100);
            }
        }
    }
}
