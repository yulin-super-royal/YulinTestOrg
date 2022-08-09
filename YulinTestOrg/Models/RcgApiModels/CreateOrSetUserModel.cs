namespace YulinTestOrg.Models.RcgApiModels
{
    public class CreateOrSetUserRequest
    {
        public string SystemCode { get; set; }

        public string WebId { get; set; }

        public string MemberAccount { get; set; }

        public string MemberName { get; set; }

        public int StopBalance { get; set; }

        public string BetLimitGroup { get; set; }

        public string Currency { get; set; }

        public string Language { get; set; }

        public string OpenGameList { get; set; }
    }

    public class CreateOrSetUserResponse
    {
        public int MsgId { get; set; }
        public string Message { get; set; }
        public CreateOrSetUserResponseData Data { get; set; }
        public int Timestamp { get; set; }
    }

    public class CreateOrSetUserResponseData
    {
        public string SystemCode { get; set; }
        public string WebId { get; set; }
        public string MemberAccount { get; set; }
    }

}
