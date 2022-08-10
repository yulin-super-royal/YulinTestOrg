using System.Linq.Expressions;
using YulinTestOrg.Data;
using YulinTestOrg.Models.JDataTableRequestModel;

namespace YulinTestOrg.Interface
{
    public interface IRcgBetRecordService
    {
        Task<long> GetMaxId();

        Task Import(List<RcgBetRecord> importList);

        Task<SearchResult<RcgBetRecord>> Search(SearchParameters param,
                                                List<Expression<Func<RcgBetRecord, bool>>> expression);
    }
}
