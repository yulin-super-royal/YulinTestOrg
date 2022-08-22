using YulinTestOrg.Data;

namespace YulinTestOrg.Interface
{
    public interface IRcgBetAreaService
    {
        Task<List<RcgBetArea>> Get();

        Task Add(RcgBetArea request);

        Task Update(RcgBetArea request);
    }
}
