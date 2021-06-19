namespace CloudyMobile.Maui
{
    public class Constants
    {
        public string BaseUrl { get; set; } = "https://cloudymobile.azurewebsites.net";

        public string CallbackUrl { get; set; }

        public string RedirectUri { get; set; } = "auth.com.ssw.cloudymobile.maui://callback";

        public string AccessToken { get; set; }

        public string AuthorityUri = "https://demo.identityserver.io";//"https://cloudymobile.azurewebsites.net";

        public string SigninPath = "/Identity/Account/Login";

        public string ClientId = "interactive.public";//"CloudyMobile.Maui";

        public string Scope = "openid profile offline_access";//"openid profile CloudMobile.APIAPI offline_access";
    }
}