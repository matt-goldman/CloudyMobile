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

        public async Task<bool> Authenticate()
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
                // TODO: handle error
                return false;
            }

            App.Constants.AccessToken = loginResult?.AccessToken ?? string.Empty;

            return true;
        }
    }
}