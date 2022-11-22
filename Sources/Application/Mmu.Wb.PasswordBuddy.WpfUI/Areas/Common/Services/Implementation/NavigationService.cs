using System.Threading.Tasks;
using Mmu.Mlh.WpfCoreExtensions.Areas.MvvmShell.ViewModels.Services;
using Mmu.Wb.PasswordBuddy.WpfUI.Areas.Credentials.Overview.Views.CredentialsOverview;
using Mmu.Wb.PasswordBuddy.WpfUI.Areas.Systems.Overview.Views;

namespace Mmu.Wb.PasswordBuddy.WpfUI.Areas.Common.Services.Implementation
{
    public class NavigationService : INavigationService
    {
        private readonly IViewModelDisplayService _vmDisplayService;

        public NavigationService(IViewModelDisplayService vmDisplayService)
        {
            _vmDisplayService = vmDisplayService;
        }

        public async Task ToMainAsync()
        {
            await _vmDisplayService.DisplayAsync<SystemOverviewViewModel>();
        }

        public async Task ToCredentialsOverviewAsync(string systemId)
        {
            await _vmDisplayService.DisplayAsync<CredentialsOverviewViewModel>(systemId);
        }
    }
}