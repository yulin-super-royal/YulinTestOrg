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

        public RcgServiceController(IRcgApiService rcgApiService,
                                    IRcgBetRecordService rcgBetRecordService)
        {
            this.rcgApiService = rcgApiService;
            this.rcgBetRecordService = rcgBetRecordService;
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
        [Route("Deposit")]
        public async Task<IActionResult> PointManage([FromBody] PointManageRequset requset)
        {
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

    }
}
