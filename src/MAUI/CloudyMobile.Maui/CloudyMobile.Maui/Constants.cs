namespace CloudyMobile.Maui
{
    public class Constants
    {
        public string BaseUrl { get; set; } = "https://cloudymobile.azurewebsites.net";

        //public string AuthUrl { get; set; } = $"{BaseUrl}/Identity/Account/Login?ReturnUrl=";

        public string CallbackUrl { get; set; }

        public string RedirectUri { get; set; } = "auth.com.ssw.cloudymobile.maui://";

        public string AccessToken { get; set; }

        public static string AuthorityUri = "https://demo.identityserver.io";
        //public static string RedirectUri = "io.identitymodel.native://callback";
        public static string ApiUri = "https://demo.identityserver.io/api/";
        public static string ClientId = "interactive.public";
        public static string Scope = "openid profile email api offline_access";
    }
}