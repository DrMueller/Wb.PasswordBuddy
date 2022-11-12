using System.Threading.Tasks;
using System.Windows.Input;
using JetBrains.Annotations;
using Mmu.Mlh.WpfCoreExtensions.Areas.MvvmShell.CommandManagement.Commands;
using Mmu.Mlh.WpfCoreExtensions.Areas.MvvmShell.CommandManagement.Components.CommandBars.ViewData;
using Mmu.Mlh.WpfCoreExtensions.Areas.MvvmShell.CommandManagement.ViewModelCommands;
using Mmu.Mlh.WpfCoreExtensions.Areas.MvvmShell.ViewModels.Services;
using Mmu.Wb.PasswordBuddy.WpfUI.Areas.System.Details.Views;
using Mmu.Wb.PasswordBuddy.WpfUI.Areas.System.Overview.ViewData;
using Mmu.Wb.PasswordBuddy.WpfUI.Areas.System.Overview.ViewServices;

namespace Mmu.Wb.PasswordBuddy.WpfUI.Areas.System.Overview.Views
{
    [PublicAPI]
    public class CommandContainer : IViewModelCommandContainer<SystemOverviewViewModel>
    {
        private readonly IViewModelDisplayService _displayService;
        private readonly ISystemOverviewService _overviewService;
        private SystemOverviewViewModel _context;
        public CommandsViewData Commands { get; private set; }

        public ICommand EditSystem
        {
            get
            {
                return new ParametredAsyncRelayCommand(async obj =>
                                                       {
                                                           var data = (SystemOverviewEntryViewData)obj;
                                                           await _displayService.DisplayAsync<SystemDetailsViewModel>(data);
                                                       });
            }
        }

        public CommandContainer(
            IViewModelDisplayService displayService,
            ISystemOverviewService overviewService)
        {
            _displayService = displayService;
            _overviewService = overviewService;
        }

        public async Task InitializeAsync(SystemOverviewViewModel context)
        {
            Commands = new CommandsViewData();

            _context.OverviewEntries = await _overviewService.LoadOverviewAsync();
        }
    }
}