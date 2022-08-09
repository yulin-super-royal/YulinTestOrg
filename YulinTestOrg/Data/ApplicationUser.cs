using Microsoft.AspNetCore.Identity;

namespace YulinTestOrg.Data
{
    public class ApplicationUser : IdentityUser
    {
        public string FullName { get; set; }
    }
}
