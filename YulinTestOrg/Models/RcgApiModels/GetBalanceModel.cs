namespace YulinTestOrg.Models.RcgApiModels
{
    public class GetBalanceRequest
    {
        public string SystemCode { get; set; }
        public string WebId { get; set; }
        public string MemberAccount { get; set; }
    }

    public class GetBalanceResponse : ResponseBase<GetBalanceResponseData>
    {

    }

    public class GetBalanceResponseData
    {
        public string SystemCode { get; set; }
        public string WebId { get; set; }
        public string MemberAccount { get; set; }
        public decimal Balance { get; set; }
        public string Online { get; set; }
        public string MemberType { get; set; }
    }

}
