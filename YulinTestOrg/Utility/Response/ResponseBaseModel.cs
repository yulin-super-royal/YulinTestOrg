namespace YulinTestOrg.Utility.Response
{
    /// <summary>
    /// 通用回傳格式
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class ResponseBaseModel<T>
    {
        /// <summary>
        /// 狀態碼, 0:正常, -1:系統錯誤, -2:檢核錯誤
        /// </summary>
        public ResponseErrCode ErrCode { get; set; } = ResponseErrCode.NORMAL;

        public string MsgCode { get; set; }

        /// <summary>
        /// 若狀態碼為 -2 時，此欄位自帶客製錯誤訊息
        /// </summary>
        public string ErrMsg { get; set; } = "";

        /// <summary>
        /// 回傳物件
        /// </summary>
        public T Data { get; set; }
    }
}
