namespace YulinTestOrg.Utility.Response
{
    public static class ResponseErrorCodeText
    {
        /// <summary>正常</summary>
        public const string OK = "OK";

        /// <summary>執行錯誤</summary>
        public const string ERROR = "ERROR";

        /// <summary>系統維護中</summary>
        public const string MATAINING = "MATAINING";

        /// <summary>傳入系數錯誤</summary>
        public const string ILLEGAL_ARGUMENT = "ILLEGAL_ARGUMENT";

        /// <summary>交易流水號已存在</summary>
        public const string DUPLICATE_TRANSACTION_ID = "DUPLICATE_TRANSACTION_ID";

        /// <summary>無效的簽章</summary>
        public const string INVALD_SIGNATURE = "INVALD_SIGNATURE";

        /// <summary>逾時5秒</summary>
        public const string TIMEOUT = "TIMEOUT";

        /// <summary>找不到資料</summary>
        public const string DATA_NOT_FOUND = "DATA_NOT_FOUND";

        /// <summary>餘額為0</summary>
        public const string BALANCE_ZERO = "BALANCE_ZERO";

        /// <summary>帳號停用</summary>
        public const string ACCOUNT_DISABLED = "ACCOUNT_DISABLED";

        /// <summary>帳號鎖定</summary>
        public const string ACCOUNT_LOCKED = "ACCOUNT_LOCKED";

        /// <summary>帳號凍結</summary>
        public const string ACCOUNT_FREEZE = "ACCOUNT_FREEZE";


        #region 錯誤代碼表
        /// <summary>正常</summary>
        public const int NORMAL = 0;

        /// <summary>其它失敗</summary>
        public const int OTHERS = -1;

        /// <summary>未預期的例外</summary>
        public const int UNEXPECTED_EXCEPTION = -2;

        /// <summary>請求驗證失敗</summary>
        public const int REQUEST_INVALID = -3;

        /// <summary>會員在線</summary>
        public const int MEMBER_ONLINE = -4;

        /// <summary>停用</summary>
        public const int SUSPENDED = -5;

        /// <summary>會員鎖定</summary>
        public const int LOCKED = -6;

        /// <summary>會員凍結</summary>
        public const int FREEZED = -7;

        /// <summary>無此帳號</summary>
        public const int NO_SUCH_ACCOUNT = -8;

        /// <summary>遊戲關閉</summary>
        public const int GAME_OFF = -9;

        /// <summary>系統維護</summary>
        public const int MAINTENANCE = -10;

        /// <summary>額度異常</summary>
        public const int ABNORMAL_BALANCE = -11;

        /// <summary>公司代碼不存在</summary>
        public const int COMPANY_NOT_EXIST = -12;

        /// <summary>找不到資料</summary>
        public const int FOUND_NO_DATA = -13;

        /// <summary>Header錯誤</summary>
        public const int HEADER_INVALID = -14;

        /// <summary>簽章錯誤</summary>
        public const int SIGNATURE_INVALID = -15;

        /// <summary>加密錯誤</summary>
        public const int ENCRYPTION_ERROR = -16;

        /// <summary>簽章錯誤</summary>
        public const int URL_ENCODE_ERROR = -17;
        /// <summary>簽章錯誤</summary>
        public const int Data_Format_Error = -18;

        #endregion
    }
}
