namespace YulinTestOrg.Models.RcgApiModels
{
    public class WithdrawRequest
    {
        public string SystemCode { get; set; }
        public string WebId { get; set; }
        public string MemberAccount { get; set; }
        public string TransactionId { get; set; }
        public decimal TransctionAmount { get; set; }
    }

    public class WithdrawResponse : ResponseBase<WithdrawResponseData>
    {

    }

    public class WithdrawResponseData
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
