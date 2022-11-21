using System.Threading.Tasks;
using System.Windows.Input;
using JetBrains.Annotations;
using Mmu.Mlh.WpfCoreExtensions.Areas.MvvmShell.CommandManagement.Commands;
using Mmu.Mlh.WpfCoreExtensions.Areas.MvvmShell.CommandManagement.Components.CommandBars.ViewData;
using Mmu.Mlh.WpfCoreExtensions.Areas.MvvmShell.CommandManagement.ViewModelCommands;
using Mmu.Mlh.WpfCoreExtensions.Areas.MvvmShell.ViewModels.Services;
using Mmu.Wb.PasswordBuddy.Domain.Data.Repositories;
using Mmu.Wb.PasswordBuddy.WpfUI.Areas.Details.Views.Details;
using Mmu.Wb.PasswordBuddy.WpfUI.Areas.Overview.ViewData;
using Mmu.Wb.PasswordBuddy.WpfUI.Areas.Overview.ViewServices;

namespace Mmu.Wb.PasswordBuddy.WpfUI.Areas.Overview.Views
{
    [PublicAPI]
    public class CommandContainer : IViewModelCommandContainer<SystemOverviewViewModel>
    {
        private readonly IViewModelDisplayService _displayService;
        private readonly ISystemOverviewService _overviewService;
        private readonly ISystemRepository _systemRepo;
        private SystemOverviewViewModel _context;

        public CommandContainer(
            IViewModelDisplayService displayService,
            ISystemOverviewService overviewService,
            ISystemRepository systemRepo)
        {
            _displayService = displayService;
            _overviewService = overviewService;
            _systemRepo = systemRepo;
        }

        public CommandsViewData Commands { get; private set; }

        public ICommand DeleteSystem =>
            new ParametredAsyncRelayCommand(
                async obj =>
                {
                    var data = (SystemOverviewEntryViewData)obj;
                    await _systemRepo.DeleteAsync(data.SystemId);
                    _context.OverviewEntries.Remove(data);
                });

        public ICommand EditSystem =>
            new ParametredAsyncRelayCommand(async obj =>
            {
                var data = (SystemOverviewEntryViewData)obj;
                await _displayService.DisplayAsync<SystemDetailsViewModel>(data.SystemId);
            });

        public async Task InitializeAsync(SystemOverviewViewModel context)
        {
            _context = context;
            Commands = new CommandsViewData();

            _context.OverviewEntries = await _overviewService.LoadOverviewAsync();
        }
    }
}