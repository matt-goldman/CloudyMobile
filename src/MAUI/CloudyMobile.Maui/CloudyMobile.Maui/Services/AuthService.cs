using IdentityModel.OidcClient;
using IdentityModel.OidcClient.Browser;
using System.Threading.Tasks;

namespace CloudyMobile.Maui.Services
{
    public class AuthService
    {
        private readonly IBrowser browser;

        public AuthService(IBrowser browser)
        {
            this.browser = browser;
        }

        public async Task Authenticate()
        {
            var options = new OidcClientOptions
            {
                Authority = App.Constants.AuthorityUri,
                ClientId = App.Constants.ClientId,
                Scope = App.Constants.Scope,
                RedirectUri = App.Constants.RedirectUri,
                Browser = browser
            };

            var oidcClient = new OidcClient(options);

            var loginResult = await oidcClient.LoginAsync(new LoginRequest());

            if(loginResult.IsError)
            {
                // handle error
                return;
            }

            App.Constants.AccessToken = loginResult?.AccessToken ?? string.Empty;
        }
    }
}