using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace DevHops.Maui.Services.Concretions
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
            //var handler = Resolver.Resolve<RetryHandler>();
            _client = new HttpClient();// handler);
            //_client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", App.Constants.AccessToken ?? string.Empty);
        }
    }
}
