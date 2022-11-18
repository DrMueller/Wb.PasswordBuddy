using System.Threading.Tasks;
using System.Windows.Input;
using JetBrains.Annotations;
using Mmu.Mlh.WpfCoreExtensions.Areas.Aspects.ApplicationInformations.Services;
using Mmu.Mlh.WpfCoreExtensions.Areas.MvvmShell.CommandManagement.Commands;
using Mmu.Mlh.WpfCoreExtensions.Areas.MvvmShell.CommandManagement.Components.CommandBars.ViewData;
using Mmu.Mlh.WpfCoreExtensions.Areas.MvvmShell.CommandManagement.ViewModelCommands;
using Mmu.Mlh.WpfCoreExtensions.Areas.MvvmShell.ViewModels.Services;
using Mmu.Wb.PasswordBuddy.Domain.Services;
using Mmu.Wb.PasswordBuddy.WpfUI.Areas.CredentialDetails.Views.Details;
using Mmu.Wb.PasswordBuddy.WpfUI.Areas.CredentialsOverview.ViewData;
using Mmu.Wb.PasswordBuddy.WpfUI.Areas.Details.Views.Details;
using Mmu.Wb.PasswordBuddy.WpfUI.Areas.Details.ViewServices;
using Mmu.Wb.PasswordBuddy.WpfUI.Areas.Overview.ViewData;

namespace Mmu.Wb.PasswordBuddy.WpfUI.Areas.CredentialsOverview.Views.CredentialsOverview
{
    [PublicAPI]
    public class CommandContainer : IViewModelCommandContainer<CredentialsOverviewViewModel>
    {
        private readonly ICredentialsService _credentialsService;
        private readonly IViewModelDisplayService _displayService;
        private CredentialsOverviewViewModel _context;
        public CommandsViewData Commands { get; private set; }

        public CommandContainer(
            ICredentialsService credentialsService,
            IViewModelDisplayService displayService)
        {
            _credentialsService = credentialsService;
            _displayService = displayService;
        }

        private IViewModelCommand CreateCredential
        {
            get
            {
                return new ViewModelCommand("New",
                    new AsyncRelayCommand(async () =>
                    {
                        await _displayService.DisplayAsync<CredentialDetailsViewModel>(_context.SelectedSystemId);
                    }));
            }
        }

        public ICommand DeleteCredential
        {
            get
            {
                return new ParametredAsyncRelayCommand(async obj =>
                {
                    var data = (CredentialOverviewEntryViewData)obj;
                    await _credentialsService.DeleteCredentials(_context.SelectedSystemId, data.CredentialId);
                    _context.Overview.Remove(data);
                });
            }
        }

        public ICommand EditCredential
        {
            get
            {
                return new ParametredAsyncRelayCommand(async obj =>
                {
                    var data = (CredentialOverviewEntryViewData)obj;
                    await _displayService.DisplayAsync<CredentialDetailsViewModel>(_context.SelectedSystemId, data.CredentialId);
                });
            }
        }

        public Task InitializeAsync(CredentialsOverviewViewModel context)
        {
            _context = context;
            Commands = new CommandsViewData();

            return Task.CompletedTask;
        }
    }
}