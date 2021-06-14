using CloudyMobile.Maui.Helpers;
using System.Net.Http;
using System.Net.Http.Headers;

namespace CloudyMobile.Maui.Services.Concretions
{
    public class BaseService
    {
        private static HttpClient _client;

        public static HttpClient httpClient
        {
            get
            {
                if (_client is null)
                {
                    InitialiseClient();
                }
                return _client;
            }
        }

        public static string apiUri;

        public BaseService()
        {
            InitialiseClient();
            apiUri = App.Constants.BaseUrl;
        }

        protected static void InitialiseClient()
        {
            _client = new HttpClient(new RetryHandler());
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", App.Constants.AccessToken ?? string.Empty);
        }
    }
}