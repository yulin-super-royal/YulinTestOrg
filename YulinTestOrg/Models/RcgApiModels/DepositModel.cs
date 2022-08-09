namespace YulinTestOrg.Models.RcgApiModels
{
    public class DepositRequest
    {
        public string SystemCode { get; set; }
        public string WebId { get; set; }
        public string MemberAccount { get; set; }
        public string TransactionId { get; set; }
        public decimal TransctionAmount { get; set; }
    }

    public class DepositResponse : ResponseBase<DepositResponseData>
    {

    }

    public class DepositResponseData
    {
        public string SystemCode { get; set; }
        public string WebId { get; set; }
        public string MemberAcount { get; set; }
        public string TransactionId { get; set; }
        public decimal TransactionAmount { get; set; }
        public decimal Balance { get; set; }
        public long TransactionTime { get; set; }
    }
}
