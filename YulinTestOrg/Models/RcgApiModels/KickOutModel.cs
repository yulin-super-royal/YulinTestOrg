namespace YulinTestOrg.Models.RcgApiModels
{
    public class KickOutRequest
    {
        public string SystemCode { get; set; }
        public string WebId { get; set; }
        public string MemberAccount { get; set; }
    }

    public class KickOutResponse : ResponseBase<KickOutResponseData>
    {
    }

    public class KickOutResponseData
    {
        public string SystemCode { get; set; }
        public string WebId { get; set; }
        public string MemberAccount { get; set; }
    }
}
