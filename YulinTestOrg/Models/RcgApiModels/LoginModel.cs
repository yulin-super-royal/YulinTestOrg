namespace YulinTestOrg.Models.RcgApiModels
{
    public class LoginRequest
    {
        public string SystemCode { get; set; }
        public string WebId { get; set; }
        public string MemberAccount { get; set; }
        public int WelletMode { get; set; }
        public int ItemNo { get; set; }
        public string BackUrl { get; set; }
        public string GameDeskID { get; set; }
        public string GroupLimitID { get; set; }
    }

    public class LoginResponse : ResponseBase<LoginResponseData>
    {
    }

    public class LoginResponseData
    {
        public string Url { get; set; }
        public string Token { get; set; }
    }
}
