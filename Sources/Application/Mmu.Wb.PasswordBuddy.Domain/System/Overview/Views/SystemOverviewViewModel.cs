using Mmu.Mlh.WpfCoreExtensions.Areas.MvvmShell.ViewModels.Behaviors;
using Mmu.Mlh.WpfCoreExtensions.Areas.MvvmShell.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mmu.Mlh.WpfCoreExtensions.Areas.MvvmShell.CommandManagement.Components.CommandBars.ViewData;
using System.Collections.ObjectModel;
using Mmu.Wb.PasswordBuddy.WpfUI.Areas.System.Overview.ViewData;

namespace Mmu.Wb.PasswordBuddy.WpfUI.Areas.System.Overview.Views
{
    public class SystemOverviewViewModel : ViewModelBase, IInitializableViewModel, INavigatableViewModel
    {
        private readonly CommandContainer _commandContainer;

        public CommandsViewData Commands => _commandContainer.Commands;
        
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
