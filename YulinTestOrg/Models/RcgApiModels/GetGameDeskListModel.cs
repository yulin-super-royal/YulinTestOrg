namespace YulinTestOrg.Models.RcgApiModels
{
    public class GetGameDeskListResponse : ResponseBase<GetGameDeskListResponseData>
    {
    }

    public class GetGameDeskListResponseData
    {
        public List<GetGameDeskListResponseDatalist> DataList { get; set; }
    }

    public class GetGameDeskListResponseDatalist
    {
        public string Id { get; set; }
        public int ServerNo { get; set; }
        public int LobbyNo { get; set; }
        public int GameNo { get; set; }
        public string Tag { get; set; }
        public string Name { get; set; }
        public string ServerProperty { get; set; }
    }
}
