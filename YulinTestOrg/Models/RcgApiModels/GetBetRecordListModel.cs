namespace YulinTestOrg.Models.RcgApiModels
{
    public class GetBetRecordListRequest
    {
        public string SystemCode { get; set; }
        public string WebId { get; set; }
        public long MaxId { get; set; }
        public int Rows { get; set; }
    }

    public class GetBetRecordListResponse : ResponseBase<GetBetRecordListResponseData>
    {
    }

    public class GetBetRecordListResponseData
    {
        public string SystemCode { get; set; }
        public string WebId { get; set; }
        public List<GetBetRecordListResponseDatalist> DataList { get; set; }
    }

    public class GetBetRecordListResponseDatalist
    {
        public string MemberAccount { get; set; }
        public int Id { get; set; }
        public int GameId { get; set; }
        public string Desk { get; set; }
        public string BetArea { get; set; }
        public double Bet { get; set; }
        public double Available { get; set; }
        public double WinLose { get; set; }
        public double WaterRate { get; set; }
        public string ActiveNo { get; set; }
        public string RunNo { get; set; }
        public double Balance { get; set; }
        public DateTime DateTime { get; set; }
        public DateTime ReportDT { get; set; }
        public string Ip { get; set; }
        public double Odds { get; set; }
        public long OriginRecordId { get; set; }
    }

}
