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

    public class WithdrawResponse : ResponseBase<DepositResponseData>
    {

    }

}
