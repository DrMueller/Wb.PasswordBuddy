using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using JetBrains.Annotations;
using Mmu.Mlh.WpfCoreExtensions.Areas.MvvmShell.CommandManagement.Components.CommandBars.ViewData;
using Mmu.Mlh.WpfCoreExtensions.Areas.MvvmShell.ViewModels;
using Mmu.Mlh.WpfCoreExtensions.Areas.MvvmShell.ViewModels.Behaviors;
using Mmu.Wb.PasswordBuddy.Domain.Data.Repositories;
using Mmu.Wb.PasswordBuddy.WpfUI.Areas.Credentials.Overview.ViewData;

namespace Mmu.Wb.PasswordBuddy.WpfUI.Areas.Credentials.Overview.Views.CredentialsOverview
{
    [PublicAPI]
    public class CredentialsOverviewViewModel : ViewModelBase, IInitializableViewModel, IDisplayableViewModel
    {
        private readonly CommandContainer _commandContainer;
        private readonly ISystemRepository _systemRepo;

        public CredentialsOverviewViewModel(
            CommandContainer commandContainer,
            ISystemRepository systemRepo)
        {
            _commandContainer = commandContainer;
            _systemRepo = systemRepo;
        }

        public CommandsViewData Commands => _commandContainer.Commands;
        public ICommand DeleteCredential => _commandContainer.DeleteCredential;
        public ICommand EditCredential => _commandContainer.EditCredential;
        public ObservableCollection<CredentialOverviewEntryViewData> Overview { get; private set; } = null!;

        public Domain.Models.System SelectedSystem { get; private set; } = null!;

        public string HeadingDescription => $"Credentials for System {SelectedSystem.Name}";

        public async Task InitializeAsync(params object[] initParams)
        {
            await _commandContainer.InitializeAsync(this);
            var systemId = (string)initParams[0];

            if (!string.IsNullOrEmpty(systemId))
            {
                SelectedSystem = await _systemRepo.LoadAsync(systemId);
                InitializeOverview();
            }
            else
            {
                Overview = new ObservableCollection<CredentialOverviewEntryViewData>();
            }
        }

        private void InitializeOverview()
        {
            var lst = SelectedSystem.Credentials.Values
                .Select(cred =>
                    new CredentialOverviewEntryViewData(cred.Id, cred.UserName, cred.Password, cred.LastChanged))
                .ToList();

            Overview = new ObservableCollection<CredentialOverviewEntryViewData>(lst);
        }
    }
}