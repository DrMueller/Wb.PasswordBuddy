using System.Threading.Tasks;
using JetBrains.Annotations;
using Mmu.Mlh.WpfCoreExtensions.Areas.Aspects.ApplicationInformations.Models;
using Mmu.Mlh.WpfCoreExtensions.Areas.Aspects.ApplicationInformations.Services;
using Mmu.Mlh.WpfCoreExtensions.Areas.MvvmShell.CommandManagement.Commands;
using Mmu.Mlh.WpfCoreExtensions.Areas.MvvmShell.CommandManagement.Components.CommandBars.ViewData;
using Mmu.Mlh.WpfCoreExtensions.Areas.MvvmShell.CommandManagement.ViewModelCommands;
using Mmu.Mlh.WpfCoreExtensions.Areas.MvvmShell.ViewModels.Services;
using Mmu.Wb.PasswordBuddy.WpfUI.Areas.CredentialsOverview.Views.CredentialsOverview;
using Mmu.Wb.PasswordBuddy.WpfUI.Areas.Details.Views.SystemData;
using Mmu.Wb.PasswordBuddy.WpfUI.Areas.Details.ViewServices;
using Mmu.Wb.PasswordBuddy.WpfUI.Areas.Overview.Views;

namespace Mmu.Wb.PasswordBuddy.WpfUI.Areas.Details.Views.Details
{
    [PublicAPI]
    public class CommandContainer : IViewModelCommandContainer<SystemDetailsViewModel>
    {
        private readonly ISystemDetailsService _detailsService;
        private readonly IViewModelDisplayService _vmDisplayService;
        private readonly IInformationPublisher _informationPublisher;
        private SystemDetailsViewModel _context;
        public CommandsViewData Commands { get; private set; }

        public CommandContainer(
            ISystemDetailsService detailsService,
            IViewModelDisplayService vmDisplayService,
            IInformationPublisher informationPublisher)
        {
            _detailsService = detailsService;
            _vmDisplayService = vmDisplayService;
            _informationPublisher = informationPublisher;
        }
        private ViewModelCommand Save =>
        new("Save",
            new AsyncRelayCommand(async () =>
                                  {
                                      await _detailsService.SaveAsync(_context.SystemData.Data);
                                      _informationPublisher.Publish(
                                          InformationEntry.CreateInfo("System saved.", false, 5));
                                      await NavigateToOverviewAsync();
                                  }));

        private ViewModelCommand Cancel =>
            new(
                "Cancel",
                new AsyncRelayCommand(async () => await NavigateToOverviewAsync()));

        private ViewModelCommand Credentials =>
            new(
                "Credentials",
                new AsyncRelayCommand(async () => await NavigateToCredentials()));

        private async Task NavigateToOverviewAsync()
        {
            await _vmDisplayService.DisplayAsync<SystemOverviewViewModel>();
        }

        private async Task NavigateToCredentials()
        {
            if (_context.SystemData.Data.SystemId == null)
            {
                _informationPublisher.Publish(
                    InformationEntry.CreateError("System must be saved before adding credentials."));
                return;
            }

            await _vmDisplayService.DisplayAsync<CredentialsOverviewViewModel>(_context.SystemData.Data.SystemId);
        }
        

        public Task InitializeAsync(SystemDetailsViewModel context)
        {
            _context = context;
            Commands = new CommandsViewData(
                Credentials,
                Save,
                Cancel);

            return Task.CompletedTask;
        }
    }
}