using System.Threading.Tasks;
using JetBrains.Annotations;
using Mmu.Mlh.WpfCoreExtensions.Areas.MvvmShell.CommandManagement.Components.CommandBars.ViewData;
using Mmu.Mlh.WpfCoreExtensions.Areas.MvvmShell.CommandManagement.ViewModelCommands;
using Mmu.Wb.PasswordBuddy.WpfUI.Areas.Overview.Views;

namespace Mmu.Wb.PasswordBuddy.WpfUI.Areas.Details
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