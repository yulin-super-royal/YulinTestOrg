using YulinTestOrg.Utility.Response;

namespace YulinTestOrg.Extensions
{
    public class ValidateException : Exception
    {
        public int MsgId { get; set; }
        public string MsgCode { get; set; }

        public ValidateException(string message, int msgID, string msgCode) : base(message)
        {
            this.MsgId = msgID;
            this.MsgCode = msgCode;
        }

        public ValidateException(string message) : base(message)
        {
            this.MsgId = ResponseErrorCodeText.OTHERS;
            this.MsgCode = "";
        }
    }
}
