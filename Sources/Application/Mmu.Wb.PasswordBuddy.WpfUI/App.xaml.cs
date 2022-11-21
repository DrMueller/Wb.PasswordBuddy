using System.Diagnostics.CodeAnalysis;
using System.Windows;
using Mmu.Mlh.WpfCoreExtensions.Areas.Initialization.Orchestration.Models;
using Mmu.Mlh.WpfCoreExtensions.Areas.Initialization.Orchestration.Services;

namespace Mmu.Wb.PasswordBuddy.WpfUI
{
    /// <summary>
    ///     Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        [SuppressMessage(
            "Usage",
            "VSTHRD100:Avoid async void methods",
            Justification = "Need to use Application interface")]
        protected override async void OnStartup(StartupEventArgs e)
        {
            var assembly = typeof(App).Assembly;
            var windowConfig = WindowConfiguration.CreateWithDefaultIcon(assembly, "Password Buddy");
            var appConfig = new WpfAppConfiguration(assembly, windowConfig);
            await AppStartService.StartAppAsync(appConfig);
        }
    }
}