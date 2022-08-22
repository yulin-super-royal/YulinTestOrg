using Microsoft.EntityFrameworkCore;
using YulinTestOrg.Data;
using YulinTestOrg.Interface;

namespace YulinTestOrg.Service.RcgService
{
    public class RcgBetAreaService : IRcgBetAreaService
    {
        private readonly ApplicationDbContext applicationDbContext;

        public RcgBetAreaService(ApplicationDbContext applicationDbContext)
        {
            this.applicationDbContext = applicationDbContext;
        }

        public async Task<List<RcgBetArea>> Get()
        {
            try
            {
                var result = await this.applicationDbContext.RcgBetAreas
                     .OrderBy(x => x.GameId)
                     .ThenBy(x => x.BetArea)
                     .ToListAsync();

                return result;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task Add(RcgBetArea request)
        {
            try
            {
                await this.applicationDbContext.RcgBetAreas.AddAsync(request);
                await this.applicationDbContext.SaveChangesAsync();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task Update(RcgBetArea request)
        {
            try
            {
                var target = await this.applicationDbContext.RcgBetAreas
                    .FirstOrDefaultAsync(x => x.Id == request.Id);

                if (target != null)
                {
                    this.applicationDbContext.Entry(target).CurrentValues.SetValues(request);
                }

                await this.applicationDbContext.SaveChangesAsync();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
