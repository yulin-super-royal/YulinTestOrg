using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using YulinTestOrg.Data;
using YulinTestOrg.Extensions;
using YulinTestOrg.Interface;
using YulinTestOrg.Models.JDataTableRequestModel;

namespace YulinTestOrg.Service.RcgService
{
    public class RcgBetRecordService : IRcgBetRecordService
    {
        private readonly ApplicationDbContext applicationDbContext;

        public RcgBetRecordService(ApplicationDbContext applicationDbContext)
        {
            this.applicationDbContext = applicationDbContext;
        }

        public async Task<long> GetMaxId()
        {
            try
            {
                var maxId = await this.applicationDbContext.RcgBetRecords
                     .OrderByDescending(x => x.Id)
                     .Select(x => x.Id)
                     .FirstOrDefaultAsync();

                return maxId;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task Import(List<RcgBetRecord> importList)
        {
            try
            {
                await this.applicationDbContext.AddRangeAsync(importList);
                await this.applicationDbContext.SaveChangesAsync();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<SearchResult<RcgBetRecord>> Search(SearchParameters param,
                                                             List<Expression<Func<RcgBetRecord, bool>>> expression)
        {
            try
            {
                var searchResult = new SearchResult<RcgBetRecord>
                {
                    ListData = new List<RcgBetRecord>()
                };

                var result = this.applicationDbContext.RcgBetRecords.AsQueryable();
                foreach (var item in expression)
                {
                    result = result.Where(item);
                }
                searchResult.TotalCount = result.Count();

                if (param.SortColumn != null)
                {
                    result = param.Order == OrderBehavior.ASC ? EntityOrderHelper.OrderBy(result, param.SortColumn) : EntityOrderHelper.OrderByDescending(result, param.SortColumn);
                }
                result = EntityPagingHelper<RcgBetRecord>.Paging(result, param.PageSize, param.Index);
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
