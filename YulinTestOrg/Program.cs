using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Serilog;
using YulinTestOrg.Data;
using YulinTestOrg.Extensions;
using YulinTestOrg.Middleware;
using YulinTestOrg.Utility.Setting;

namespace YulinTestOrg
{
    public class Program
    {
        public static void Main(string[] args)
        {
            GlobalExceptionHandler();

            Log.Logger = new LoggerConfiguration()
               .WriteTo.Console()
               .CreateLogger();

            try
            {
                var builder = WebApplication.CreateBuilder(args);

                builder.Configuration.AddJsonFile("appsettings.json", false)
                    .AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", optional: true, reloadOnChange: true)
                    .AddEnvironmentVariables();

                builder.Services.Configure<Appsetting>(builder.Configuration.GetSection("AppSetting"));

                builder.Host.UseSerilog((ctx, lc) => lc
                    .ReadFrom.Configuration(ctx.Configuration));

                // Add services to the container.
                builder.Services.AddServiceExtension(builder.Configuration);
                builder.Services.AddRcgExtension();

                var app = builder.Build();

                // Configure the HTTP request pipeline.
                if (app.Environment.IsDevelopment())
                {
                    app.UseMigrationsEndPoint();
                }
                else
                {
                    app.UseExceptionHandler("/Home/Error");
                    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                    app.UseHsts();
                }

                app.UseMiddleware<ExceptionHandleMiddleware>();

                app.UseHttpsRedirection();
                app.UseStaticFiles();

                app.UseRouting();

                app.UseAuthentication();
                app.UseAuthorization();

                app.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                app.MapRazorPages();

                app.UseServiceExtension();
                app.UseRcgExtension();
                app.Run();
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "Unhandled exception");
            }
            finally
            {
                Log.Information("Shut down complete");
                Log.CloseAndFlush();
            }
        }

        static void GlobalExceptionHandler()
        {
            AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(ExceptionHandler);

            void ExceptionHandler(object sender, UnhandledExceptionEventArgs args)
            {
                var exception = (Exception)args.ExceptionObject;
                Log.Information("Global Exception Handler Caught: " + exception.Message);
            }
        }
    }
}