using Coravel.Invocable;
using YulinTestOrg.Data;
using YulinTestOrg.Interface;

namespace YulinTestOrg.Schedule
{
    public class RcgGetGameDeskListSchedule : IInvocable
    {
        private readonly IRcgApiService rcgApiService;
        private readonly IRcgGameDeskService rcgGameDeskService;

        public RcgGetGameDeskListSchedule(IRcgApiService rcgApiService,
                                          IRcgGameDeskService rcgGameDeskService)
        {
            this.rcgApiService = rcgApiService;
            this.rcgGameDeskService = rcgGameDeskService;
        }

        public async Task Invoke()
        {
            await ExecuteAsync();

            GC.Collect();
            GC.WaitForPendingFinalizers();
        }

        private async Task ExecuteAsync()
        {
            var rcgGameDeskList = await this.rcgApiService.GetGameDeskList();
            var localGameDeskList = await this.rcgGameDeskService.Get();

            foreach (var item in rcgGameDeskList.DataList)
            {
                var target = localGameDeskList.FirstOrDefault(x => x.Id == item.Id);

                if (target == null)
                {
                    await this.rcgGameDeskService.Add(new RcgGameDesk
                    {
                        Id = item.Id,
                        ServerNo = item.ServerNo,
                        LobbyNo = item.LobbyNo,
                        GameNo = item.GameNo,
                        Tag = item.Tag,
                        Name = item.Name,
                        ServerProperty = item.ServerProperty
                    });
                }
                else
                {
                    await this.rcgGameDeskService.Update(new RcgGameDesk
                    {
                        Id = item.Id,
                        ServerNo = item.ServerNo,
                        LobbyNo = item.LobbyNo,
                        GameNo = item.GameNo,
                        Tag = item.Tag,
                        Name = item.Name,
                        ServerProperty = item.ServerProperty
                    });
                }
            }
        }
    }
}
