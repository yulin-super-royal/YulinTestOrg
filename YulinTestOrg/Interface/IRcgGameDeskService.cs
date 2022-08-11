using YulinTestOrg.Data;

namespace YulinTestOrg.Interface
{
    public interface IRcgGameDeskService
    {
        Task<List<RcgGameDesk>> Get();

        Task Add(RcgGameDesk request);

        Task Update(RcgGameDesk request);
    }
}
