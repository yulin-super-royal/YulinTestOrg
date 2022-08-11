using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Linq.Expressions;
using YulinTestOrg.Data;
using YulinTestOrg.Interface;
using YulinTestOrg.Models;
using YulinTestOrg.Models.JDataTableRequestModel;

namespace YulinTestOrg.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class RcgServiceController : APILiteBaseController
    {
        private readonly IRcgApiService rcgApiService;
        private readonly IRcgBetRecordService rcgBetRecordService;
        private readonly IRcgTransactionRecordService rcgTransactionRecordService;
        private readonly IRcgGameDeskService rcgGameDeskService;

        public RcgServiceController(IRcgApiService rcgApiService,
                                    IRcgBetRecordService rcgBetRecordService,
                                    IRcgTransactionRecordService rcgTransactionRecordService,
                                    IRcgGameDeskService rcgGameDeskService)
        {
            this.rcgApiService = rcgApiService;
            this.rcgBetRecordService = rcgBetRecordService;
            this.rcgTransactionRecordService = rcgTransactionRecordService;
            this.rcgGameDeskService = rcgGameDeskService;
        }

        [HttpPost]
        [Route("LoginToRcg")]
        public async Task<IActionResult> LoginToRcg()
        {
            var userName = HttpContext.User.Identity.Name;
            var result = await this.rcgApiService.Login(userName);
            return Ok(result);
        }

        [HttpPost]
        [Route("SearchBetRecord")]
        public async Task<IActionResult> SearchBetRecord([FromForm] SearchBetRecordRequest request)
        {
            var userName = HttpContext.User.Identity.Name;
            var sortColumn = new Dictionary<int, string>
            {
                { 0, "Id" },
                { 1, "Desk" },
                { 2, "RunNo" },
                { 3, "ActiveNo" },
                { 4, "BetArea" },
                { 5, "Bet" },
                { 6, "Available" },
                { 7, "WinLose" },
                { 8, "Odds" },
                { 9, "DateTime" },
                { 10, "ReportDT" }
            };

            SearchParameters searchParameters = BindingSearchParam(request, sortColumn);

            var exp = new List<Expression<Func<RcgBetRecord, bool>>>
            {
                x => x.MemberAccount == userName
            };

            var searchResult = await this.rcgBetRecordService.Search(searchParameters, exp);

            return Ok(new JDataTableResponse<RcgBetRecord>(request.Draw,
                                                           searchResult.ListData,
                                                           searchResult.TotalCount));
        }

        public class SearchBetRecordRequest : JDataTableRequest
        {
        }

        [HttpPost]
        [Route("GetBalance")]
        public async Task<IActionResult> GetBalance()
        {
            var userName = HttpContext.User.Identity.Name;
            var result = await this.rcgApiService.GetBalance(userName);

            return Ok(result);
        }

        [HttpPost]
        [Route("PointManage")]
        public async Task<IActionResult> PointManage([FromBody] PointManageRequset requset)
        {
            var userName = HttpContext.User.Identity.Name;
            var transactionId = Guid.NewGuid().ToString();
            if (requset.TransactionType)
            {
                var depositResult = await this.rcgApiService.Deposit(userName, transactionId, requset.Amount);
                await this.rcgTransactionRecordService.Add(new RcgTransactionRecord
                {
                    SystemCode = depositResult.SystemCode,
                    WebId = depositResult.WebId,
                    MemberAcount = depositResult.MemberAcount,
                    TransactionId = transactionId,
                    TransactionAmount = requset.Amount,
                    Balance = depositResult.Balance,
                    TransactionTime = depositResult.TransactionTime,
                    TransactionType = requset.TransactionType,
                    CreateDateTime = DateTime.Now
                });
            }
            else
            {
                var withdrawResult = await this.rcgApiService.Withdraw(userName, transactionId, requset.Amount);
                await this.rcgTransactionRecordService.Add(new RcgTransactionRecord
                {
                    SystemCode = withdrawResult.SystemCode,
                    WebId = withdrawResult.WebId,
                    MemberAcount = withdrawResult.MemberAcount,
                    TransactionId = transactionId,
                    TransactionAmount = requset.Amount,
                    Balance = withdrawResult.Balance,
                    TransactionTime = withdrawResult.TransactionTime,
                    TransactionType = requset.TransactionType,
                    CreateDateTime = DateTime.Now
                });
            }

            return Ok();
        }

        public class PointManageRequset
        {
            /// <summary>
            /// true: 存入RCG
            /// false: 取回
            /// </summary>
            public bool TransactionType { get; set; }

            public decimal Amount { get; set; }
        }

        [HttpPost]
        [Route("SearchRcgTransactionRecord")]
        public async Task<IActionResult> SearchRcgTransactionRecord([FromForm] SearchRcgTransactionRecordRequest request)
        {
            var userName = HttpContext.User.Identity.Name;
            var sortColumn = new Dictionary<int, string>
            {
                { 0, "TransactionId" },
                { 1, "TransactionType" },
                { 2, "TransactionAmount" },
                { 3, "Balance" },
                { 4, "CreateDateTime" }
            };

            SearchParameters searchParameters = BindingSearchParam(request, sortColumn);

            var exp = new List<Expression<Func<RcgTransactionRecord, bool>>>
            {
                x => x.MemberAcount == userName
            };

            var searchResult = await this.rcgTransactionRecordService.Search(searchParameters, exp);

            return Ok(new JDataTableResponse<RcgTransactionRecord>(request.Draw,
                                                                   searchResult.ListData,
                                                                   searchResult.TotalCount));
        }

        public class SearchRcgTransactionRecordRequest : JDataTableRequest
        {
        }

        [HttpPost]
        [Route("GetGameDesk")]
        public async Task<IActionResult> GetGameDesk()
        {
            var result = await this.rcgGameDeskService.Get();

            return Ok(result);
        }
    }
}
