using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using Mmu.Mlh.WpfCoreExtensions.Areas.MvvmShell.CommandManagement.Components.CommandBars.ViewData;
using Mmu.Mlh.WpfCoreExtensions.Areas.MvvmShell.ViewModels;
using Mmu.Mlh.WpfCoreExtensions.Areas.MvvmShell.ViewModels.Behaviors;
using Mmu.Mlh.WpfCoreExtensions.Areas.MvvmShell.ViewModels.Services;
using Mmu.Mlh.WpfCoreExtensions.Areas.Validations.Validation.Models;
using Mmu.Wb.PasswordBuddy.WpfUI.Areas.CredentialsOverview.Views.CredentialsOverview;
using Mmu.Wb.PasswordBuddy.WpfUI.Areas.Details.ViewData;
using Mmu.Wb.PasswordBuddy.WpfUI.Areas.Details.Views.SystemData;
using Mmu.Wb.PasswordBuddy.WpfUI.Areas.Details.ViewServices;

namespace Mmu.Wb.PasswordBuddy.WpfUI.Areas.Details.Views.Details
{
    public class SystemDetailsViewModel : ViewModelBase, IInitializableViewModel, INavigatableViewModel
    {
        private readonly IViewModelFactory _vmFactory;
        private readonly ISystemDetailsService _detailsService;
        private readonly CommandContainer _commandContainer;
        private readonly ICredentialsOverviewService _credentialsOverviewService;
        private SystemDataViewModel _systemData;
        private CredentialsOverviewViewModel _credentialsOverview;

        public CredentialsOverviewViewModel CredentialsOverview
        {
            get => _credentialsOverview;
            set => OnPropertyChanged(value, ref _credentialsOverview);
        }

        public SystemDataViewModel SystemData
        {
            get => _systemData;
            set => OnPropertyChanged(value, ref _systemData);
        }

        public CommandsViewData Commands => _commandContainer.Commands;

        public SystemDetailsViewModel(
            IViewModelFactory vmFactory,
            ISystemDetailsService detailsService,
            CommandContainer commandContainer,
            ICredentialsOverviewService credentialsOverviewService)
        {
            _vmFactory = vmFactory;
            _detailsService = detailsService;
            _commandContainer = commandContainer;
            _credentialsOverviewService = credentialsOverviewService;
        }

        public async Task InitializeAsync(params object[] initParams)
        {
            await _commandContainer.InitializeAsync(this);
            var id = initParams?.Any() ?? false ? (string) initParams.ElementAt(0) : null;
            var viewData = await _detailsService.LoadAsync(id);
            SystemData = await _vmFactory.CreateAsync<SystemDataViewModel>(viewData);
            CredentialsOverview = await _vmFactory.CreateAsync<CredentialsOverviewViewModel>(id);
            

        }

        public string HeadingDescription => "Edit";
        public string NavigationDescription => "New";
        public int NavigationSequence => 2;
    }
}
