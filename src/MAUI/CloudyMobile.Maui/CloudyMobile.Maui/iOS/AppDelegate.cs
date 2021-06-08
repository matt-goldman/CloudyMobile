using Foundation;
using Microsoft.Maui;
using UIKit;

namespace CloudyMobile.Maui
{
	[Register("AppDelegate")]
	public class AppDelegate : MauiUIApplicationDelegate<Startup>
	{
		public override bool OpenUrl(UIApplication app, NSUrl url, NSDictionary options)
		{
			if (Microsoft.Maui.Essentials.Platform.OpenUrl(app, url, options))
				return true;

			return base.OpenUrl(app, url, options);
		}

		public override bool ContinueUserActivity(UIApplication application, NSUserActivity userActivity, UIApplicationRestorationHandler completionHandler)
		{
			if (Microsoft.Maui.Essentials.Platform.ContinueUserActivity(application, userActivity, completionHandler))
				return true;
			return base.ContinueUserActivity(application, userActivity, completionHandler);
		}
	}
}