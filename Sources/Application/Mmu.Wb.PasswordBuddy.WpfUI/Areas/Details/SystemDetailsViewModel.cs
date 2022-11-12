using System.Linq;
using System.Threading.Tasks;
using Mmu.Mlh.WpfCoreExtensions.Areas.MvvmShell.ViewModels;
using Mmu.Mlh.WpfCoreExtensions.Areas.MvvmShell.ViewModels.Behaviors;

namespace Mmu.Wb.PasswordBuddy.WpfUI.Areas.Details
{
    public class SystemDetailsViewModel : ViewModelBase, IInitializableViewModel, INavigatableViewModel
    {
        private readonly CommandContainer _commandContainer;

        public SystemDetailsViewModel(CommandContainer commandContainer)
        {
            _commandContainer = commandContainer;
        }

        public async Task InitializeAsync(params object[] initParams)
        {
            var existingOverview = initParams?.Any() == true ? initParams.ElementAt(0) : null;
            await _commandContainer.InitializeAsync(this);
        }

        public string HeadingDescription => "Edit";
        public string NavigationDescription => "New";
        public int NavigationSequence => 2;
    }
}
