using System.Threading.Tasks;
using Mmu.Mlh.WpfCoreExtensions.Areas.MvvmShell.ViewModels.Services;
using Mmu.Wb.PasswordBuddy.WpfUI.Areas.Overview.Views;

namespace Mmu.Wb.PasswordBuddy.WpfUI.Areas.Common.Services.Implementation
{
    public class NavigationService : INavigationService
    {
        private readonly IViewModelDisplayService _vmDisplayService;

        public NavigationService(IViewModelDisplayService vmDisplayService)
        {
            _vmDisplayService = vmDisplayService;
        }

        public async Task NavigateToMainAsync()
        {
            await _vmDisplayService.DisplayAsync<SystemOverviewViewModel>();
        }
    }
}