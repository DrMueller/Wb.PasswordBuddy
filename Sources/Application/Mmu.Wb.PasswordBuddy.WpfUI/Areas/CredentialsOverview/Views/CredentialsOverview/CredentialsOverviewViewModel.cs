using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Mmu.Mlh.WpfCoreExtensions.Areas.MvvmShell.CommandManagement.Components.CommandBars.ViewData;
using Mmu.Mlh.WpfCoreExtensions.Areas.MvvmShell.ViewModels;
using Mmu.Mlh.WpfCoreExtensions.Areas.MvvmShell.ViewModels.Behaviors;
using Mmu.Wb.PasswordBuddy.WpfUI.Areas.CredentialsOverview.ViewData;
using Mmu.Wb.PasswordBuddy.WpfUI.Areas.Details.ViewServices;

namespace Mmu.Wb.PasswordBuddy.WpfUI.Areas.CredentialsOverview.Views.CredentialsOverview
{
    public class CredentialsOverviewViewModel : ViewModelBase, IInitializableViewModel, IDisplayableViewModel
    {
        private readonly ICredentialsOverviewService _credentialsOverviewService;
        private readonly CommandContainer _commandContainer;
        public ObservableCollection<CredentialOverviewEntryViewData> Overview { get; private set; }

        public CommandsViewData Commands => _commandContainer.Commands;

        public ICommand EditCredential => _commandContainer.EditCredential;
        public ICommand DeleteCredential => _commandContainer.DeleteCredential;

        public string SelectedSystemId { get; private set; }

        public CredentialsOverviewViewModel(
            ICredentialsOverviewService credentialsOverviewService,
            CommandContainer commandContainer)
        {
            _credentialsOverviewService = credentialsOverviewService;
            _commandContainer = commandContainer;
        }

        public async Task InitializeAsync(params object[] initParams)
        {
            SelectedSystemId = (string)initParams[0];
            var creds = await _credentialsOverviewService.LoadAsync(SelectedSystemId);
            Overview = new ObservableCollection<CredentialOverviewEntryViewData>(creds);
        }

        public string HeadingDescription => "Credentials";
    }
}