namespace YulinTestOrg.Models.RcgApiModels
{
    public class GetOpenListRequest
    {
        public string GameDeskID { get; set; }
        public DateTime Date { get; set; }
        public string ActiveNo { get; set; }
        public string RunNo { get; set; }
    }

    public class GetOpenListResponse : ResponseBase<GetOpenListResponseData>
    {
    }

    public class GetOpenListResponseData
    {
        public List<GetOpenListResponseDatalist> DataList { get; set; }
    }

    public class GetOpenListResponseDatalist
    {
        public string ActiveNo { get; set; }
        public string RunNo { get; set; }
        public string Result { get; set; }
        public string Url { get; set; }
    }

}
