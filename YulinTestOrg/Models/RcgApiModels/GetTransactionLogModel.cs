namespace YulinTestOrg.Models.RcgApiModels
{
    public class GetTransactionLogRequest
    {
        public string SystemCode { get; set; }
        public string WebId { get; set; }
        public string TransactionId { get; set; }
    }

    public class GetTransactionLogResponse : ResponseBase<GetTransactionLogResponseData>
    {
    }

    public class GetTransactionLogResponseData
    {
        public string TransactionId { get; set; }
        public string SystemCode { get; set; }
        public string WebId { get; set; }
        public string MemberAccount { get; set; }
        public int TransactionType { get; set; }
        public decimal TransactionAmount { get; set; }
        public decimal BeforeBalance { get; set; }
        public decimal AfterBalance { get; set; }
        public int Status { get; set; }
        public DateTime TransactionTime { get; set; }
    }

}
