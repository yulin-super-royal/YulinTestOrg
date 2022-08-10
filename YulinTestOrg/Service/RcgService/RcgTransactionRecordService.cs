using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using YulinTestOrg.Data;
using YulinTestOrg.Extensions;
using YulinTestOrg.Interface;
using YulinTestOrg.Models.JDataTableRequestModel;

namespace YulinTestOrg.Service.RcgService
{
    public class RcgTransactionRecordService : IRcgTransactionRecordService
    {
        private readonly ApplicationDbContext applicationDbContext;

        public RcgTransactionRecordService(ApplicationDbContext applicationDbContext)
        {
            this.applicationDbContext = applicationDbContext;
        }

        public async Task Add(RcgTransactionRecord request)
        {
            try
            {
                await this.applicationDbContext.RcgTransactionRecords.AddAsync(request);
                await this.applicationDbContext.SaveChangesAsync();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<SearchResult<RcgTransactionRecord>> Search(SearchParameters param,
                                                                     List<Expression<Func<RcgTransactionRecord, bool>>> expression)
        {
            try
            {
                var searchResult = new SearchResult<RcgTransactionRecord>
                {
                    ListData = new List<RcgTransactionRecord>()
                };

                var result = this.applicationDbContext.RcgTransactionRecords.AsQueryable();
                foreach (var item in expression)
                {
                    result = result.Where(item);
                }
                searchResult.TotalCount = result.Count();

                if (param.SortColumn != null)
                {
                    result = param.Order == OrderBehavior.ASC ? EntityOrderHelper.OrderBy(result, param.SortColumn) : EntityOrderHelper.OrderByDescending(result, param.SortColumn);
                }
                result = EntityPagingHelper<RcgTransactionRecord>.Paging(result, param.PageSize, param.Index);
                searchResult.ListData = await result.ToListAsync();

                return searchResult;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
