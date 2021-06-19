using Android.App;
using Android.Content;
using Android.Content.PM;
using Microsoft.Maui;

namespace CloudyMobile.Maui
{
    [Activity(NoHistory = true, LaunchMode = LaunchMode.SingleTop)]
    [IntentFilter(new[] { Android.Content.Intent.ActionView },
        Categories = new[] { Android.Content.Intent.CategoryDefault, Android.Content.Intent.CategoryBrowsable },
        DataScheme = "auth.com.ssw.cloudymobile.maui",
        DataHost = "callback")]
    public class WebAuthenticationCallbackActivity : Microsoft.Maui.Essentials.WebAuthenticatorCallbackActivity
    {
    }
}