using YulinTestOrg.Models.RcgApiModels;

namespace YulinTestOrg.Interface
{
    public interface IRcgApiService
    {
        /// <summary>
        /// 登入遊戲
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        Task<LoginResponseData> Login(string userName);

        /// <summary>
        /// 建立或更新玩家
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        Task CreateOrSetUser(string userName);

        /// <summary>
        /// 踢除玩家
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        Task KickOut(string userName);

        /// <summary>
        /// 踢除代理商所有玩家
        /// </summary>
        /// <returns></returns>
        Task KickOutByCompany();

        /// <summary>
        /// 取得限注範本
        /// </summary>
        /// <returns></returns>
        Task<GetBetLimitResponseData> GetBetLimit();

        /// <summary>
        /// 取得玩家錢包餘額
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        Task<GetBalanceResponseData> GetBalance(string userName);

        /// <summary>
        /// 取得在線玩家清單
        /// </summary>
        /// <returns></returns>
        Task<GetPlayerOnlineListResponseData> GetPlayerOnlineList();

        /// <summary>
        /// 存錢
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="transctionAmount"></param>
        /// <returns></returns>
        Task<DepositResponseData> Deposit(string userName, decimal transctionAmount);

        /// <summary>
        /// 取款
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="transctionAmount"></param>
        /// <returns></returns>
        Task<WithdrawResponseData> Withdraw(string userName, decimal transctionAmount);

        /// <summary>
        /// 取得下注紀錄
        /// </summary>
        /// <returns></returns>
        Task<GetBetRecordListResponseData> GetBetRecordList();

        /// <summary>
        /// 取得開放桌別清單
        /// </summary>
        /// <returns></returns>
        Task<GetGameDeskListResponseData> GetGameDeskList();

        /// <summary>
        /// 取得改單紀錄
        /// </summary>
        /// <returns></returns>
        Task<GetChangeRecordListResponseData> GetChangeRecordList();

        /// <summary>
        /// 取得交易紀錄
        /// </summary>
        /// <param name="transactionId"></param>
        /// <returns></returns>
        Task<GetTransactionLogResponseData> GetTransactionLog(string transactionId);

        /// <summary>
        /// 取得開牌紀錄
        /// </summary>
        /// <param name="gameDeskID"></param>
        /// <param name="date"></param>
        /// <param name="activeNo"></param>
        /// <param name="runNo"></param>
        /// <returns></returns>
        Task<GetOpenListResponseData> GetOpenList(string gameDeskID,
                                                  DateTime date,
                                                  string activeNo,
                                                  string runNo);
    }
}
