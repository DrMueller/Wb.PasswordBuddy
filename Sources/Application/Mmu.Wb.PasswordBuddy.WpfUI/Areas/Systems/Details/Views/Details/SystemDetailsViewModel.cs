using System.Linq;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Mmu.Mlh.WpfCoreExtensions.Areas.MvvmShell.CommandManagement.Components.CommandBars.ViewData;
using Mmu.Mlh.WpfCoreExtensions.Areas.MvvmShell.ViewModels;
using Mmu.Mlh.WpfCoreExtensions.Areas.MvvmShell.ViewModels.Behaviors;
using Mmu.Mlh.WpfCoreExtensions.Areas.MvvmShell.ViewModels.Services;
using Mmu.Wb.PasswordBuddy.WpfUI.Areas.Systems.Details.Views.SystemData;
using Mmu.Wb.PasswordBuddy.WpfUI.Areas.Systems.Details.ViewServices;

namespace Mmu.Wb.PasswordBuddy.WpfUI.Areas.Systems.Details.Views.Details
{
    [PublicAPI]
    public class SystemDetailsViewModel : ViewModelBase, IInitializableViewModel, INavigatableViewModel
    {
        private readonly CommandContainer _commandContainer;
        private readonly ISystemDetailsService _detailsService;
        private readonly IViewModelFactory _vmFactory;
        private SystemDataViewModel _systemData = null!;

        public SystemDetailsViewModel(
            IViewModelFactory vmFactory,
            ISystemDetailsService detailsService,
            CommandContainer commandContainer)
        {
            _vmFactory = vmFactory;
            _detailsService = detailsService;
            _commandContainer = commandContainer;
        }

        public CommandsViewData Commands => _commandContainer.Commands;

        public SystemDataViewModel SystemData
        {
            get => _systemData;
            set => OnPropertyChanged(value, ref _systemData);
        }

        public async Task InitializeAsync(params object[] initParams)
        {
            await _commandContainer.InitializeAsync(this);
            var id = initParams?.Any() ?? false ? (string)initParams.ElementAt(0) : null;
            var viewData = await _detailsService.LoadAsync(id);
            SystemData = await _vmFactory.CreateAsync<SystemDataViewModel>(viewData);
        }

        public string HeadingDescription => "Edit";
        public string NavigationDescription => "New";
        public int NavigationSequence => 2;
    }
}