using Microsoft.Extensions.Options;
using System.Text;
using System.Text.Json;
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

        public async Task<LoginResponseData> Login()
        {
            try
            {
                var request = new LoginRequest
                {
                    SystemCode = this.appsetting.RCGSetting.OrganizationInfo.SystemCode,
                    WebId = this.appsetting.RCGSetting.OrganizationInfo.WebId,
                    MemberAccount = "",
                    WelletMode = 1,
                    ItemNo = 1,
                    BackUrl = "",
                    GameDeskID = "",
                    GroupLimitID = ""
                };
                var requestJson = JsonSerializer.Serialize(request);
                var timestamp = GetUNIXTimestamp();
                var desEncrypt = DataToDES(requestJson);
                var md5Encrypt = DESToMD5(desEncrypt, timestamp);

                var req = await HttpHelper<LoginResponse>("/api/Player/Login",
                                                          requestJson,
                                                          md5Encrypt,
                                                          timestamp);

                return req.Data;
            }
            catch (Exception)
            {

                throw;
            }
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
            var dto = new DateTimeOffset(DateTime.UtcNow);
            var unixTime = dto.ToUnixTimeSeconds().ToString();

            return unixTime;
        }

        private async Task<TResponse> HttpHelper<TResponse>(string requestPath,
                                                            string requestJson,
                                                            string md5Encrypt,
                                                            string timestamp)
            where TResponse : class
        {
            try
            {
                var httpClient = this.clientFactory.CreateClient();
                httpClient.DefaultRequestHeaders.Add("X-API-ClientID", this.appsetting.RCGSetting.OrganizationInfo.OrganizationId.ToString());
                httpClient.DefaultRequestHeaders.Add("X-API-Signature", md5Encrypt);
                httpClient.DefaultRequestHeaders.Add("X-API-Timestamp", timestamp);
                httpClient.DefaultRequestHeaders.Add("Content-Type", "application/json");

                var requestBody = new StringContent(requestJson,
                                                    Encoding.UTF8,
                                                    "application/json");
                var response = await httpClient.PostAsync(this.appsetting.RCGSetting.ApiUrl + requestPath, requestBody);
                response.EnsureSuccessStatusCode();

                var responseJson = await response.Content.ReadAsStringAsync();
                var desDecrypt = this.desService.Decrypt(responseJson,
                                                         this.appsetting.RCGSetting.OrganizationInfo.DesKey,
                                                         this.appsetting.RCGSetting.OrganizationInfo.DesIV);
                var result = JsonSerializer.Deserialize<TResponse>(desDecrypt);

                return result;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
