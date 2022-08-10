using System.Linq.Expressions;
using YulinTestOrg.Data;
using YulinTestOrg.Models.JDataTableRequestModel;

namespace YulinTestOrg.Interface
{
    public interface IRcgTransactionRecordService
    {
        Task Add(RcgTransactionRecord request);

        Task<SearchResult<RcgTransactionRecord>> Search(SearchParameters param,
                                                        List<Expression<Func<RcgTransactionRecord, bool>>> expression);
    }
}
