namespace YulinTestOrg.Models.RcgApiModels
{
    public class ResponseBase<TModel>
    {
        public int MsgId { get; set; }
        public string Message { get; set; }
        public TModel Data { get; set; }
        public int Timestamp { get; set; }
    }
}
