using Microsoft.EntityFrameworkCore;
using YulinTestOrg.Data;
using YulinTestOrg.Interface;

namespace YulinTestOrg.Service.RcgService
{
    public class RcgGameDeskService : IRcgGameDeskService
    {
        private readonly ApplicationDbContext applicationDbContext;

        public RcgGameDeskService(ApplicationDbContext applicationDbContext)
        {
            this.applicationDbContext = applicationDbContext;
        }

        public async Task<List<RcgGameDesk>> Get()
        {
            try
            {
                var result = await this.applicationDbContext.RcgGameDesks
                    .ToListAsync();

                return result;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task Add(RcgGameDesk request)
        {
            try
            {
                await this.applicationDbContext.RcgGameDesks.AddAsync(request);
                await this.applicationDbContext.SaveChangesAsync();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task Update(RcgGameDesk request)
        {
            try
            {
                var target = await this.applicationDbContext.RcgGameDesks
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
