using System.Threading.Tasks;
using JetBrains.Annotations;
using Mmu.Mlh.WpfCoreExtensions.Areas.MvvmShell.CommandManagement.Components.CommandBars.ViewData;
using Mmu.Mlh.WpfCoreExtensions.Areas.MvvmShell.ViewModels;
using Mmu.Mlh.WpfCoreExtensions.Areas.MvvmShell.ViewModels.Behaviors;
using Mmu.Mlh.WpfCoreExtensions.Areas.MvvmShell.ViewModels.Services;
using Mmu.Wb.PasswordBuddy.WpfUI.Areas.Credentials.Details.Views.CredentialData;
using Mmu.Wb.PasswordBuddy.WpfUI.Areas.Credentials.Details.ViewServices;

namespace Mmu.Wb.PasswordBuddy.WpfUI.Areas.Credentials.Details.Views.Details
{
    [PublicAPI]
    public class CredentialDetailsViewModel : ViewModelBase, IInitializableViewModel, IDisplayableViewModel
    {
        private readonly CommandContainer _commandContainer;
        private readonly ICredentialDetailsViewService _credentialDetailsService;
        private readonly IViewModelFactory _viewModelFactory;
        private CredentialDataViewModel _credentialData = null!;

        public CredentialDetailsViewModel(
            IViewModelFactory viewModelFactory,
            CommandContainer commandContainer,
            ICredentialDetailsViewService credentialDetailsService)
        {
            _viewModelFactory = viewModelFactory;
            _commandContainer = commandContainer;
            _credentialDetailsService = credentialDetailsService;
        }

        public CommandsViewData Commands => _commandContainer.Commands;

        public CredentialDataViewModel CredentialData
        {
            get => _credentialData;
            set => OnPropertyChanged(value, ref _credentialData);
        }

        public string SystemId { get; private set; } = null!;
        public string HeadingDescription { get; } = "Edit Credentials";

        public async Task InitializeAsync(params object[] initParams)
        {
            SystemId = (string)initParams[0];
            var credentialId = initParams.Length == 2 ? (string?)initParams[1] : null;

            var credDetails = await _credentialDetailsService.LoadAsync(SystemId, credentialId);
            _credentialData = await _viewModelFactory.CreateAsync<CredentialDataViewModel>(credDetails);

            await _commandContainer.InitializeAsync(this);
        }
    }
}