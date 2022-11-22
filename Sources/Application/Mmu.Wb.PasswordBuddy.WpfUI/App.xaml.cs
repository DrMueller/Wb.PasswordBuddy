using System;
using System.Windows;
using Mmu.Mlh.ServiceProvisioning.Areas.Provisioning.Services;
using Mmu.Mlh.WpfCoreExtensions.Areas.Initialization.Orchestration.Models;
using Mmu.Mlh.WpfCoreExtensions.Areas.Initialization.Orchestration.Services;

namespace Mmu.Wb.PasswordBuddy.WpfUI
{
    /// <summary>
    ///     Interaction logic for App.xaml
    /// </summary>
    public partial class App
    {
        protected override async void OnStartup(StartupEventArgs e)
        {
            var assembly = typeof(App).Assembly;
            var windowConfig = WindowConfiguration.CreateWithDefaultIcon(assembly, "Password Buddy");
            var appConfig = new WpfAppConfiguration(assembly, windowConfig);

            await AppStartService.StartAppAsync(appConfig, AfterInitialized);
        }

        private static void AfterInitialized(IServiceLocator obj)
        {
            Current.Resources.MergedDictionaries.Add(new ResourceDictionary
            {
                Source = new Uri("/Infrastructure/Dictionaries/GlobalDict.xaml", UriKind.Relative)
            });
        }
    }
}