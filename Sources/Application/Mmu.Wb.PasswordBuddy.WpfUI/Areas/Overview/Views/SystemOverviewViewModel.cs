using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Mmu.Mlh.WpfCoreExtensions.Areas.MvvmShell.CommandManagement.Components.CommandBars.ViewData;
using Mmu.Mlh.WpfCoreExtensions.Areas.MvvmShell.ViewModels;
using Mmu.Mlh.WpfCoreExtensions.Areas.MvvmShell.ViewModels.Behaviors;
using Mmu.Wb.PasswordBuddy.WpfUI.Areas.Overview.ViewData;

namespace Mmu.Wb.PasswordBuddy.WpfUI.Areas.Overview.Views
{
    public class SystemOverviewViewModel : ViewModelBase, IInitializableViewModel, INavigatableViewModel
    {
        private readonly CommandContainer _commandContainer;

        public CommandsViewData Commands => _commandContainer.Commands;

        public ICommand EditSystem => _commandContainer.EditSystem;
        public ICommand DeleteSystem => _commandContainer.DeleteSystem;

        public ObservableCollection<SystemOverviewEntryViewData> OverviewEntries { get; set; }

        public SystemOverviewViewModel(CommandContainer commandContainer)
        {
            _commandContainer = commandContainer;
        }

        public async Task InitializeAsync(params object[] initParams)
        {
            await _commandContainer.InitializeAsync(this);
        }

        public string HeadingDescription => "Overview";
        public string NavigationDescription => "Overview";
        public int NavigationSequence => 1;
    }
}
