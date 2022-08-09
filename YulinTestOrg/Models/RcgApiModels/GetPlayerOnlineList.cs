namespace YulinTestOrg.Models.RcgApiModels
{
    public class GetPlayerOnlineListRequest
    {
        public string SystemCode { get; set; }
        public string WebId { get; set; }
    }

    public class GetPlayerOnlineListResponse : ResponseBase<GetPlayerOnlineListResponseData>
    {

    }

    public class GetPlayerOnlineListResponseData
    {
        public List<GetPlayerOnlineListResponseDatalist> DataList { get; set; }
    }

    public class GetPlayerOnlineListResponseDatalist
    {
        public string SystemCode { get; set; }
        public string WebId { get; set; }
        public string MemberAccount { get; set; }
        public string ServerNo { get; set; }
        public string Ip { get; set; }
        public string Device { get; set; }
        public DateTime LoginTime { get; set; }
    }

}
