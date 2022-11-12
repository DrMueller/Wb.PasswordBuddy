using Mmu.Mlh.WpfCoreExtensions.Areas.MvvmShell.ViewModels.Behaviors;
using Mmu.Mlh.WpfCoreExtensions.Areas.MvvmShell.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mmu.Wb.PasswordBuddy.WpfUI.Areas.System.Details.Views
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
            var existingOverview = initParams.Any() ? initParams.ElementAt(0) : null;
            await _commandContainer.InitializeAsync(this);
        }

        public string HeadingDescription => "Edit";
        public string NavigationDescription => "New";
        public int NavigationSequence => 2;
    }
}
