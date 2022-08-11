using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace YulinTestOrg.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<RcgBetRecord> RcgBetRecords { get; set; }
        public DbSet<RcgTransactionRecord> RcgTransactionRecords { get; set; }
        public DbSet<RcgGameDesk> RcgGameDesks { get; set; }
    }
}