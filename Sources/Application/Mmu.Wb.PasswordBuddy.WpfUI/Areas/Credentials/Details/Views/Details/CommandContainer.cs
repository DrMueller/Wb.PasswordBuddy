using System.Threading.Tasks;
using Mmu.Mlh.WpfCoreExtensions.Areas.Aspects.ApplicationInformations.Models;
using Mmu.Mlh.WpfCoreExtensions.Areas.Aspects.ApplicationInformations.Services;
using Mmu.Mlh.WpfCoreExtensions.Areas.MvvmShell.CommandManagement.Commands;
using Mmu.Mlh.WpfCoreExtensions.Areas.MvvmShell.CommandManagement.Components.CommandBars.ViewData;
using Mmu.Mlh.WpfCoreExtensions.Areas.MvvmShell.CommandManagement.ViewModelCommands;
using Mmu.Wb.PasswordBuddy.WpfUI.Areas.Common.Services;
using Mmu.Wb.PasswordBuddy.WpfUI.Areas.Credentials.Details.ViewServices;

namespace Mmu.Wb.PasswordBuddy.WpfUI.Areas.Credentials.Details.Views.Details
{
    public class CommandContainer : IViewModelCommandContainer<CredentialDetailsViewModel>
    {
        private readonly ICredentialDetailsViewService _credentialDetailsService;
        private readonly IInformationPublisher _informationPublisher;
        private readonly INavigationService _navigationService;
        private CredentialDetailsViewModel _context;

        public CommandContainer(
            IInformationPublisher informationPublisher,
            INavigationService navigationService,
            ICredentialDetailsViewService credentialDetailsService)
        {
            _informationPublisher = informationPublisher;
            _navigationService = navigationService;
            _credentialDetailsService = credentialDetailsService;
        }

        public CommandsViewData Commands { get; private set; }

        private ViewModelCommand Cancel =>
            new(
                "Cancel",
                new AsyncRelayCommand(async () => await NavigateToCredentialsOverviewAsync()));

        private ViewModelCommand Save =>
            new("Save",
                new AsyncRelayCommand(async () =>
                {
                    await _credentialDetailsService.SaveAsync(_context.SystemId, _context.CredentialData.Data);
                    _informationPublisher.Publish(
                        InformationEntry.CreateInfo("Credential saved.", false, 5));
                    await NavigateToCredentialsOverviewAsync();
                }, () => !_context.CredentialData.Data.HasErrors));

        public Task InitializeAsync(CredentialDetailsViewModel context)
        {
            _context = context;

            Commands = new CommandsViewData(
                Save,
                Cancel);

            return Task.CompletedTask;
        }

        private async Task NavigateToCredentialsOverviewAsync()
        {
            await _navigationService.ToCredentialsOverviewAsync(_context.SystemId);
        }
    }
}