using Microsoft.Maui;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Controls.PlatformConfiguration.WindowsSpecific;
using Application = Microsoft.Maui.Controls.Application;
using Maui.Plugins.PageResolver;

namespace CloudyMobile.Maui
{
    public partial class App : Application
    {
        public static Constants Constants { get; set; } = new Constants();

        public App(IServiceProvider sp)
        {
            InitializeComponent();
            this.UsePageResolver(sp);
        }

        protected override IWindow CreateWindow(IActivationState activationState)
        {
            Microsoft.Maui.Controls.Compatibility.Forms.Init(activationState);

            this.On<Microsoft.Maui.Controls.PlatformConfiguration.Windows>()
                .SetImageDirectory("Assets");

            return new Microsoft.Maui.Controls.Window(new NavigationPage(new MainPage()));
        }
    }
}
