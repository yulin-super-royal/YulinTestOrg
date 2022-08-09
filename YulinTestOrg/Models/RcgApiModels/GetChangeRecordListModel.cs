namespace YulinTestOrg.Models.RcgApiModels
{
    public class GetChangeRecordListRequest
    {
        public string SystemCode { get; set; }
        public string WebId { get; set; }
        public long MaxId { get; set; }
        public int Rows { get; set; }
    }

    public class GetChangeRecordListResponse : ResponseBase<GetChangeRecordListResponseData>
    {
    }

    public class GetChangeRecordListResponseData
    {
        public string SystemCode { get; set; }
        public string WebId { get; set; }
        public List<GetChangeRecordListResponseDatalist> DataList { get; set; }
    }

    public class GetChangeRecordListResponseDatalist
    {
        public string MemberAccount { get; set; }
        public int Id { get; set; }
        public int ModifyId { get; set; }
        public string GameId { get; set; }
        public string ServerId { get; set; }
        public string AreaId { get; set; }
        public double BetPoint { get; set; }
        public double PointEffective { get; set; }
        public double WinLosePoint { get; set; }
        public double MbDiscountRate { get; set; }
        public string NoRun { get; set; }
        public string NoActive { get; set; }
        public double Balance { get; set; }
        public DateTime BetDT { get; set; }
        public string Ip { get; set; }
        public int Status { get; set; }
        public double Odds { get; set; }
        public DateTime LastChangeTime { get; set; }
        public int RecordId { get; set; }
    }

}
