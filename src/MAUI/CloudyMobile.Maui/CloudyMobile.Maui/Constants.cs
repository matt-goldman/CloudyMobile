namespace CloudyMobile.Maui
{
    public class Constants
    {
        public string BaseUrl { get; set; } = "https://cloudymobile.azurewebsites.net";

        //public string AuthUrl { get; set; } = $"{BaseUrl}/Identity/Account/Login?ReturnUrl=";

        public string CallbackUrl { get; set; }

        public string RedirectUri { get; set; } = "auth.com.ssw.cloudymobile.maui://";

        public string AuthToken { get; set; }
    }
}