namespace YulinTestOrg.Models.RcgApiModels
{
    public class ResponseBase<TModel> where TModel : class
    {
        public int MsgId { get; set; }
        public string Message { get; set; }
        public TModel Data { get; set; }
        public int Timestamp { get; set; }
    }
}
