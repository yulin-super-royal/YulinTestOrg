using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using YulinTestOrg.Data;
using YulinTestOrg.Service;

namespace YulinTestOrg.Extensions
{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddServiceExtension(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlite(connectionString));
            services.AddDatabaseDeveloperPageExceptionFilter();

            services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = false)
                .AddEntityFrameworkStores<ApplicationDbContext>();
            services.AddControllersWithViews();
            services.AddHttpClient();
            services.AddScoped<DESService>();
            services.AddScoped<MD5Service>();

            return services;
        }

        public static void UseServiceExtension(this IApplicationBuilder app)
        {

        }
    }
}
