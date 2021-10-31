using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevHops.Maui
{
    public class Constants
    {
        public string BaseUrl { get; set; } = "https://cloudymobile.azurewebsites.net";

        public string CallbackUrl { get; set; }

        public string RedirectUri { get; set; } = "auth.com.ssw.cloudymobile.maui://callback";

        public string AccessToken { get; set; }

        public string AuthorityUri = "https://cloudymobile.azurewebsites.net";

        public string SigninPath = "/Identity/Account/Login";

        public string ClientId = "CloudyMobile.Maui";

        public string Scope = "openid profile CloudMobile.APIAPI offline_access";
    }
}
