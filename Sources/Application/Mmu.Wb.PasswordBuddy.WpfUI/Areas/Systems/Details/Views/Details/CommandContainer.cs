using System.Threading.Tasks;
using JetBrains.Annotations;
using Mmu.Mlh.WpfCoreExtensions.Areas.Aspects.ApplicationInformations.Models;
using Mmu.Mlh.WpfCoreExtensions.Areas.Aspects.ApplicationInformations.Services;
using Mmu.Mlh.WpfCoreExtensions.Areas.MvvmShell.CommandManagement.Commands;
using Mmu.Mlh.WpfCoreExtensions.Areas.MvvmShell.CommandManagement.Components.CommandBars.ViewData;
using Mmu.Mlh.WpfCoreExtensions.Areas.MvvmShell.CommandManagement.ViewModelCommands;
using Mmu.Mlh.WpfCoreExtensions.Areas.MvvmShell.ViewModels.Services;
using Mmu.Wb.PasswordBuddy.WpfUI.Areas.Common.Services;
using Mmu.Wb.PasswordBuddy.WpfUI.Areas.Systems.Details.ViewServices;

namespace Mmu.Wb.PasswordBuddy.WpfUI.Areas.Systems.Details.Views.Details
{
    [PublicAPI]
    public class CommandContainer : IViewModelCommandContainer<SystemDetailsViewModel>
    {
        private readonly ISystemDetailsService _detailsService;
        private readonly IInformationPublisher _informationPublisher;
        private readonly INavigationService _navigationService;
        private readonly IViewModelDisplayService _vmDisplayService;
        private SystemDetailsViewModel _context = null!;

        public CommandContainer(
            ISystemDetailsService detailsService,
            IInformationPublisher informationPublisher,
            INavigationService navigationService,
            IViewModelDisplayService vmDisplayService)
        {
            _detailsService = detailsService;
            _informationPublisher = informationPublisher;
            _navigationService = navigationService;
            _vmDisplayService = vmDisplayService;
        }

        public CommandsViewData Commands { get; private set; } = null!;

        private ViewModelCommand Cancel =>
            new(
                "Cancel",
                new AsyncRelayCommand(_navigationService.ToMainAsync));

        private ViewModelCommand Credentials =>
            new(
                "Credentials",
                new AsyncRelayCommand(async () => await NavigateToCredentials()));

        private ViewModelCommand Save =>
            new("Save",
                new AsyncRelayCommand(async () =>
                {
                    await _detailsService.SaveAsync(_context.SystemData.Data);
                    _informationPublisher.Publish(
                        InformationEntry.CreateInfo("System saved.", false, 5));
                    await _navigationService.ToMainAsync();
                }, () => !_context.SystemData.Data.RevalidateAnyErrors()));

        public Task InitializeAsync(SystemDetailsViewModel context)
        {
            _context = context;
            Commands = new CommandsViewData(
                Credentials,
                Save,
                Cancel);

            return Task.CompletedTask;
        }

        private async Task NavigateToCredentials()
        {
            if (string.IsNullOrEmpty(_context.SystemData.Data.SystemId))
            {
                _informationPublisher.Publish(
                    InformationEntry.CreateError("System must be saved before adding credentials."));

                return;
            }

            await _navigationService.ToCredentialsOverviewAsync(_context.SystemData.Data.SystemId);
        }
    }
}