using Microsoft.Maui;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Controls.PlatformConfiguration.WindowsSpecific;
using Application = Microsoft.Maui.Controls.Application;

namespace DevHops.Maui
{
	public partial class App : Application
	{
		public static Constants Constants { get; set; } = new Constants();

		public App(MainPage page)
		{
			InitializeComponent();

			MainPage = new NavigationPage(page);
		}
	}
}
