using System.Threading.Tasks;
using System.Windows.Input;
using JetBrains.Annotations;
using Mmu.Mlh.WpfCoreExtensions.Areas.MvvmShell.CommandManagement.Commands;
using Mmu.Mlh.WpfCoreExtensions.Areas.MvvmShell.CommandManagement.Components.CommandBars.ViewData;
using Mmu.Mlh.WpfCoreExtensions.Areas.MvvmShell.CommandManagement.ViewModelCommands;
using Mmu.Mlh.WpfCoreExtensions.Areas.MvvmShell.ViewModels.Services;
using Mmu.Wb.PasswordBuddy.Domain.Services;
using Mmu.Wb.PasswordBuddy.WpfUI.Areas.Credentials.Details.Views.Details;
using Mmu.Wb.PasswordBuddy.WpfUI.Areas.Credentials.Overview.ViewData;

namespace Mmu.Wb.PasswordBuddy.WpfUI.Areas.Credentials.Overview.Views.CredentialsOverview
{
    [PublicAPI]
    public class CommandContainer : IViewModelCommandContainer<CredentialsOverviewViewModel>
    {
        private readonly ICredentialsService _credentialsService;
        private readonly IViewModelDisplayService _displayService;
        private CredentialsOverviewViewModel _context;

        public CommandContainer(
            ICredentialsService credentialsService,
            IViewModelDisplayService displayService)
        {
            _credentialsService = credentialsService;
            _displayService = displayService;
        }

        public CommandsViewData Commands { get; private set; }

        public ICommand DeleteCredential =>
            new ParametredAsyncRelayCommand(async obj =>
            {
                var data = (CredentialOverviewEntryViewData)obj;
                await _credentialsService.DeleteCredentials(_context.SelectedSystem.Id, data.CredentialId);
                _context.Overview.Remove(data);
            });

        public ICommand EditCredential =>
            new ParametredAsyncRelayCommand(async obj =>
            {
                var data = (CredentialOverviewEntryViewData)obj;
                await _displayService.DisplayAsync<CredentialDetailsViewModel>(_context.SelectedSystem.Id, data.CredentialId);
            });

        private IViewModelCommand CreateCredential =>
            new ViewModelCommand("New",
                new AsyncRelayCommand(async () =>
                {
                    await _displayService.DisplayAsync<CredentialDetailsViewModel>(_context.SelectedSystem.Id);
                }));

        public Task InitializeAsync(CredentialsOverviewViewModel context)
        {
            _context = context;
            Commands = new CommandsViewData(
                CreateCredential);

            return Task.CompletedTask;
        }
    }
}