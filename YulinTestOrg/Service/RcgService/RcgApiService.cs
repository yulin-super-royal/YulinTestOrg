using Microsoft.Extensions.Options;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Web;
using YulinTestOrg.Interface;
using YulinTestOrg.Models.RcgApiModels;
using YulinTestOrg.Utility.Setting;

namespace YulinTestOrg.Service.RcgService
{
    public class RcgApiService : IRcgApiService
    {
        private readonly ILogger<RcgApiService> logger;
        private readonly Appsetting appsetting;
        private readonly IHttpClientFactory clientFactory;
        private readonly DESService desService;
        private readonly MD5Service md5Service;

        public RcgApiService(ILogger<RcgApiService> logger,
                             IOptions<Appsetting> appsetting,
                             IHttpClientFactory clientFactory,
                             DESService desService,
                             MD5Service md5Service)
        {
            this.logger = logger;
            this.appsetting = appsetting.Value;
            this.clientFactory = clientFactory;
            this.desService = desService;
            this.md5Service = md5Service;
        }

        public async Task<LoginResponseData> Login(string userName)
        {
            var request = new LoginRequest
            {
                SystemCode = this.appsetting.RCGSetting.OrganizationInfo.SystemCode,
                WebId = this.appsetting.RCGSetting.OrganizationInfo.WebId,
                MemberAccount = userName,
                WelletMode = 1,
                ItemNo = 0,
                BackUrl = "",
                GameDeskID = "",
                GroupLimitID = ""
            };
            var response = await PostData<LoginRequest,
                                          LoginResponse>("/api/Player/Login", request);
            return response.Data;
        }

        public async Task CreateOrSetUser(string userName)
        {
            var request = new CreateOrSetUserRequest
            {
                SystemCode = this.appsetting.RCGSetting.OrganizationInfo.SystemCode,
                WebId = this.appsetting.RCGSetting.OrganizationInfo.WebId,
                MemberAccount = userName,
                MemberName = userName,
                StopBalance = -1,
                BetLimitGroup = "4,7,10",
                Currency = "TWD",
                Language = "zh-TW",
                OpenGameList = "ALL"
            };

            var response = await PostData<CreateOrSetUserRequest,
                                          CreateOrSetUserResponse>("/api/Player/CreateOrSetUser", request);
        }

        public async Task KickOut(string userName)
        {
            var request = new KickOutRequest
            {
                SystemCode = this.appsetting.RCGSetting.OrganizationInfo.SystemCode,
                WebId = this.appsetting.RCGSetting.OrganizationInfo.WebId,
                MemberAccount = userName
            };

            var response = await PostData<KickOutRequest,
                                          KickOutResponse>("/api/Player/KickOut", request);
        }

        public async Task KickOutByCompany()
        {
            var request = "";
            var response = await PostData<string,
                                          KickOutByCompanyResponse>("/api/Player/KickOutByCompany", request);
        }

        public async Task<GetBetLimitResponseData> GetBetLimit()
        {
            var request = "";
            var response = await PostData<string,
                                          GetBetLimitResponse>("/api/Player/GetBetLimit", request);

            return response.Data;
        }

        public async Task<GetBalanceResponseData> GetBalance(string userName)
        {
            var request = new GetBalanceRequest
            {
                SystemCode = this.appsetting.RCGSetting.OrganizationInfo.SystemCode,
                WebId = this.appsetting.RCGSetting.OrganizationInfo.WebId,
                MemberAccount = userName
            };
            var response = await PostData<GetBalanceRequest,
                                          GetBalanceResponse>("/api/Player/GetBalance", request);

            return response.Data;
        }

        public async Task<GetPlayerOnlineListResponseData> GetPlayerOnlineList()
        {
            var request = new GetPlayerOnlineListRequest
            {
                SystemCode = this.appsetting.RCGSetting.OrganizationInfo.SystemCode,
                WebId = this.appsetting.RCGSetting.OrganizationInfo.WebId
            };
            var response = await PostData<GetPlayerOnlineListRequest,
                                          GetPlayerOnlineListResponse>("/api/Player/GetPlayerOnlineList", request);

            return response.Data;
        }

        public async Task<DepositResponseData> Deposit(string userName, string transactionId, decimal transctionAmount)
        {
            var request = new DepositRequest
            {
                SystemCode = this.appsetting.RCGSetting.OrganizationInfo.SystemCode,
                WebId = this.appsetting.RCGSetting.OrganizationInfo.WebId,
                MemberAccount = userName,
                TransactionId = transactionId,
                TransctionAmount = transctionAmount
            };
            var response = await PostData<DepositRequest,
                                          DepositResponse>("/api/Player/Deposit", request);

            return response.Data;
        }

        public async Task<DepositResponseData> Withdraw(string userName, string transactionId, decimal transctionAmount)
        {
            var request = new WithdrawRequest
            {
                SystemCode = this.appsetting.RCGSetting.OrganizationInfo.SystemCode,
                WebId = this.appsetting.RCGSetting.OrganizationInfo.WebId,
                MemberAccount = userName,
                TransactionId = transactionId,
                TransctionAmount = transctionAmount
            };
            var response = await PostData<WithdrawRequest,
                                          WithdrawResponse>("/api/Player/Withdraw", request);

            return response.Data;
        }

        public async Task<GetBetRecordListResponseData> GetBetRecordList(long maxId)
        {
            var request = new GetBetRecordListRequest
            {
                SystemCode = this.appsetting.RCGSetting.OrganizationInfo.SystemCode,
                WebId = this.appsetting.RCGSetting.OrganizationInfo.WebId,
                MaxId = maxId,
                Rows = this.appsetting.RCGSetting.RcgGetBetRecordListBatchSize
            };
            var response = await PostData<GetBetRecordListRequest,
                                          GetBetRecordListResponse>("/api/Record/GetBetRecordList", request);

            return response.Data;
        }

        public async Task<GetGameDeskListResponseData> GetGameDeskList()
        {
            var request = "";
            var response = await PostData<string,
                                          GetGameDeskListResponse>("/api/Record/GetGameDeskList", request);

            return response.Data;
        }

        public async Task<GetChangeRecordListResponseData> GetChangeRecordList()
        {
            var request = new GetChangeRecordListRequest
            {
                SystemCode = this.appsetting.RCGSetting.OrganizationInfo.SystemCode,
                WebId = this.appsetting.RCGSetting.OrganizationInfo.WebId,
                MaxId = 1,
                Rows = 100
            };
            var response = await PostData<GetChangeRecordListRequest,
                                          GetChangeRecordListResponse>("/api/Record/GetChangeRecordList", request);

            return response.Data;
        }

        public async Task<GetTransactionLogResponseData> GetTransactionLog(string transactionId)
        {
            var request = new GetTransactionLogRequest
            {
                SystemCode = this.appsetting.RCGSetting.OrganizationInfo.SystemCode,
                WebId = this.appsetting.RCGSetting.OrganizationInfo.WebId,
                TransactionId = transactionId
            };
            var response = await PostData<GetTransactionLogRequest,
                                          GetTransactionLogResponse>("/api/Record/GetTransactionLog", request);

            return response.Data;
        }

        public async Task<GetOpenListResponseData> GetOpenList(string gameDeskID,
                                                               DateTime date,
                                                               string activeNo,
                                                               string runNo)
        {
            var request = new GetOpenListRequest
            {
                GameDeskID = gameDeskID,
                Date = date,
                ActiveNo = activeNo,
                RunNo = runNo
            };
            var response = await PostData<GetOpenListRequest,
                                          GetOpenListResponse>("/api/Record/GetOpenList", request);

            return response.Data;
        }

        private string DataToDES(string jsonString)
        {
            var desEncrypt = this.desService.Encrypt(jsonString,
                                                     this.appsetting.RCGSetting.OrganizationInfo.DesKey,
                                                     this.appsetting.RCGSetting.OrganizationInfo.DesIV);

            return desEncrypt;
        }

        private string DESToMD5(string desEncrypt, string timestamp)
        {
            var md5HashFormaatter = string.Format("{0}{1}{2}{3}",
                                                  this.appsetting.RCGSetting.OrganizationInfo.OrganizationId,
                                                  this.appsetting.RCGSetting.OrganizationInfo.ClientSecret,
                                                  timestamp,
                                                  desEncrypt);
            (bool, string) md5Encrypt = this.md5Service.Encrypt(md5HashFormaatter);

            return md5Encrypt.Item2;
        }

        private static string GetUNIXTimestamp()
        {
            var dto = DateTimeOffset.UtcNow.ToUnixTimeSeconds();
            var unixTime = dto.ToString();

            return unixTime;
        }

        private async Task<TResponse> PostData<TRequest, TResponse>(string requestPath, TRequest request)
        {
            try
            {
                var requestJson = JsonSerializer.Serialize(request);
                var timestamp = GetUNIXTimestamp();
                var desEncrypt = DataToDES(requestJson);
                var md5Encrypt = DESToMD5(desEncrypt, timestamp);

                var httpClient = this.clientFactory.CreateClient();
                httpClient.DefaultRequestHeaders.Add("X-API-ClientID", this.appsetting.RCGSetting.OrganizationInfo.OrganizationId.ToString());
                httpClient.DefaultRequestHeaders.Add("X-API-Signature", md5Encrypt);
                httpClient.DefaultRequestHeaders.Add("X-API-Timestamp", timestamp);
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var requestBody = new StringContent(HttpUtility.UrlEncode(desEncrypt),
                                                    Encoding.UTF8,
                                                    "application/json");
                var response = await httpClient.PostAsync(this.appsetting.RCGSetting.ApiUrl + requestPath, requestBody);
                response.EnsureSuccessStatusCode();

                var responseJson = await response.Content.ReadAsStringAsync();
                var desDecrypt = this.desService.Decrypt(responseJson,
                                                         this.appsetting.RCGSetting.OrganizationInfo.DesKey,
                                                         this.appsetting.RCGSetting.OrganizationInfo.DesIV);

                var serializeOptions = new JsonSerializerOptions
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                };
                var result = JsonSerializer.Deserialize<TResponse>(desDecrypt, serializeOptions);

                return result;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
