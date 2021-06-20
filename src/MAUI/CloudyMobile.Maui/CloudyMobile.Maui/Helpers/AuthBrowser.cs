using System;
using System.Threading;
using System.Threading.Tasks;
using IdentityModel.OidcClient.Browser;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Essentials;

namespace CloudyMobile.Maui.Helpers
{
    public class AuthBrowser : IBrowser
    {
        public async Task<BrowserResult> InvokeAsync(BrowserOptions options, CancellationToken cancellationToken = default)
        {
            WebAuthenticatorResult authResult = await WebAuthenticator.AuthenticateAsync(new Uri(options.StartUrl), new Uri(App.Constants.RedirectUri));

            return new BrowserResult()
            {
                Response = ParseAuthenticationResult(authResult)
            };
        }

        private string ParseAuthenticationResult(WebAuthenticatorResult result)
        {
            string code = result?.Properties["code"];
            string scope = result?.Properties["scope"];
            string state = result?.Properties["state"];
            string sessionState = result?.Properties["session_state"];
            return $"{App.Constants.RedirectUri}#code={code}&scope={scope}&state={state}&session_state={sessionState}";
        }
    }
}