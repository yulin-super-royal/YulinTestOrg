namespace YulinTestOrg.Models.RcgApiModels
{
    public class GetBetLimitResponse : ResponseBase<GetBetLimitResponseData>
    {
    }

    public class GetBetLimitResponseData
    {
        public List<GetBetLimitResponseDataContent> Content { get; set; }
    }

    public class GetBetLimitResponseDataContent
    {
        public int ItemNo { get; set; }
        public string BpMax { get; set; }
        public string BpMin { get; set; }
    }

}
