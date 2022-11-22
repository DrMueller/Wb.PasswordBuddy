using System.Threading.Tasks;
using System.Windows.Input;
using JetBrains.Annotations;
using Mmu.Mlh.WpfCoreExtensions.Areas.Aspects.ApplicationInformations.Models;
using Mmu.Mlh.WpfCoreExtensions.Areas.Aspects.ApplicationInformations.Services;
using Mmu.Mlh.WpfCoreExtensions.Areas.MvvmShell.CommandManagement.Commands;
using Mmu.Mlh.WpfCoreExtensions.Areas.MvvmShell.CommandManagement.Components.CommandBars.ViewData;
using Mmu.Mlh.WpfCoreExtensions.Areas.MvvmShell.CommandManagement.ViewModelCommands;
using Mmu.Mlh.WpfCoreExtensions.Areas.MvvmShell.ViewModels.Services;
using Mmu.Wb.PasswordBuddy.Domain.Data.Repositories;
using Mmu.Wb.PasswordBuddy.Domain.Services;
using Mmu.Wb.PasswordBuddy.WpfUI.Areas.Systems.Details.Views.Details;
using Mmu.Wb.PasswordBuddy.WpfUI.Areas.Systems.Overview.ViewData;
using Mmu.Wb.PasswordBuddy.WpfUI.Areas.Systems.Overview.ViewServices;

namespace Mmu.Wb.PasswordBuddy.WpfUI.Areas.Systems.Overview.Views
{
    [PublicAPI]
    public class CommandContainer : IViewModelCommandContainer<SystemOverviewViewModel>
    {
        private readonly IBackupService _backupService;
        private readonly IViewModelDisplayService _displayService;
        private readonly IInformationPublisher _infoPublisher;
        private readonly ISystemOverviewService _overviewService;
        private readonly ISystemRepository _systemRepo;
        private SystemOverviewViewModel _context = null!;

        public CommandContainer(
            IViewModelDisplayService displayService,
            ISystemOverviewService overviewService,
            ISystemRepository systemRepo,
            IBackupService backupService,
            IInformationPublisher infoPublisher)
        {
            _displayService = displayService;
            _overviewService = overviewService;
            _systemRepo = systemRepo;
            _backupService = backupService;
            _infoPublisher = infoPublisher;
        }

        public CommandsViewData Commands { get; private set; } = null!;

        public ICommand DeleteSystem =>
            new ParametredAsyncRelayCommand(
                async obj =>
                {
                    var data = (SystemOverviewEntryViewData)obj;
                    await _systemRepo.DeleteAsync(data.SystemId);
                    _context.OverviewEntries.Remove(data);
                });

        private IViewModelCommand CreateBackup =>
            new ViewModelCommand(
                "Backup",
                new AsyncRelayCommand(
                    async () =>
                    {
                        var backupPath = await _backupService.BackupAsync();
                        _infoPublisher.Publish(InformationEntry.CreateInfo($"Backup finished in path {backupPath}.",
                            false, 5));
                    }));

        public ICommand EditSystem =>
            new ParametredAsyncRelayCommand(async obj =>
            {
                var data = (SystemOverviewEntryViewData)obj;
                await _displayService.DisplayAsync<SystemDetailsViewModel>(data.SystemId);
            });

        public async Task InitializeAsync(SystemOverviewViewModel context)
        {
            _context = context;
            Commands = new CommandsViewData(CreateBackup);

            _context.OverviewEntries = await _overviewService.LoadOverviewAsync();
        }
    }
}