using Coravel.Queuing.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using YulinTestOrg.Data;
using YulinTestOrg.Interface;
using YulinTestOrg.Models;

namespace YulinTestOrg.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IRcgApiService rcgApiService;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IQueue _queue;

        public HomeController(ILogger<HomeController> logger, IRcgApiService rcgApiService, UserManager<ApplicationUser> userManager, IQueue queue)
        {
            _logger = logger;
            this.rcgApiService = rcgApiService;
            _userManager = userManager;
            _queue = queue;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            //var user = await _userManager.GetUserAsync(HttpContext.User);
            var userName = HttpContext.User.Identity.Name;

            //await rcgApiService.CreateOrSetUser(userName);
            //var result1 = await rcgApiService.Login(userName);
            //await rcgApiService.KickOut(userName);
            //await rcgApiService.KickOutByCompany();
            //var result2 = await rcgApiService.GetBetLimit();
            //var result3 = await rcgApiService.GetBalance(userName);
            //var result4 = await rcgApiService.GetPlayerOnlineList();
            //var result5 = await rcgApiService.Deposit(userName, 10000);
            //var result6 = await rcgApiService.Withdraw(userName, 10000);
            //var result7 = await rcgApiService.GetBetRecordList(1);
            //var result8 = await rcgApiService.GetGameDeskList();
            //var result9 = await rcgApiService.GetChangeRecordList();
            //var result10 = await rcgApiService.GetTransactionLog(result5.TransactionId);
            //var result11 = await rcgApiService.GetOpenList("SYBC20204101", new DateTime(2022, 8, 9), "620809004", "0302");
            return View();
        }

        [Authorize]
        public IActionResult BetRecord()
        {
            return View();
        }

        [Authorize]
        public IActionResult PointManage()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}