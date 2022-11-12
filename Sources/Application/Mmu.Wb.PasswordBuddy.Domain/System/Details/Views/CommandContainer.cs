using System.Threading.Tasks;
using System.Windows.Input;
using JetBrains.Annotations;
using Mmu.Mlh.WpfCoreExtensions.Areas.MvvmShell.CommandManagement.Commands;
using Mmu.Mlh.WpfCoreExtensions.Areas.MvvmShell.CommandManagement.Components.CommandBars.ViewData;
using Mmu.Mlh.WpfCoreExtensions.Areas.MvvmShell.CommandManagement.ViewModelCommands;
using Mmu.Mlh.WpfCoreExtensions.Areas.MvvmShell.ViewModels.Services;
using Mmu.Wb.PasswordBuddy.WpfUI.Areas.System.Overview.ViewData;
using Mmu.Wb.PasswordBuddy.WpfUI.Areas.System.Overview.Views;
using Mmu.Wb.PasswordBuddy.WpfUI.Areas.System.Overview.ViewServices;

namespace Mmu.Wb.PasswordBuddy.WpfUI.Areas.System.Details.Views
{
    [PublicAPI]
    public class CommandContainer : IViewModelCommandContainer<SystemDetailsViewModel>
    {
        private SystemOverviewViewModel _context;
        public CommandsViewData Commands { get; private set; }

        public Task InitializeAsync(SystemDetailsViewModel context)
        {
            Commands = new CommandsViewData();

            return Task.CompletedTask;
        }
    }
}