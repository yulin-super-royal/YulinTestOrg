using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using YulinTestOrg.Data;
using YulinTestOrg.Interface;

namespace YulinTestOrg.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class RcgServiceController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IRcgApiService _rcgApiService;

        public RcgServiceController(UserManager<ApplicationUser> userManager,
                                    IRcgApiService rcgApiService)
        {
            _userManager = userManager;
            _rcgApiService = rcgApiService;
        }

        [HttpPost]
        [Route("LoginToRcg")]
        public async Task<IActionResult> LoginToRcg()
        {
            var userName = HttpContext.User.Identity.Name;
            var result = await _rcgApiService.Login(userName);
            return Ok(result);
        }
    }
}
