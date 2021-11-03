using DevHops.Maui.Services.Abstractions;
using IdentityModel.OidcClient;
using IdentityModel.OidcClient.Browser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevHops.Maui.Services.Concretions
{
    public class AuthService : IAuthService
    {
        private readonly IBrowser browser;

        public AuthService(IBrowser browser)
        {
            this.browser = browser;
        }

        public async Task<bool> Authenticate()
        {
            try
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

                if (loginResult.IsError)
                {
                    // TODO: handle error
                    return false;
                }

                App.Constants.AccessToken = loginResult?.AccessToken ?? string.Empty;

                return true;
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Login failed");
                Console.WriteLine(ex.Message);
                return false;
            }
        }
    }
}
