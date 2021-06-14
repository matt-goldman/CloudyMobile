using CloudyMobile.Maui.Helpers;
using System;
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
            Console.WriteLine("Base service constructor called");
            InitialiseClient();
            apiUri = App.Constants.BaseUrl;

            Console.WriteLine("Base service constructed");
        }

        static void InitialiseClient()
        {
            Console.WriteLine("Initialising http client");
            _client = new HttpClient(new RetryHandler());
            Console.WriteLine("Setting http client headers");
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", App.Constants.AccessToken ?? string.Empty);
        }
    }
}