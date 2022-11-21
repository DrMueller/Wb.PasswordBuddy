using System.Threading.Tasks;
using Mmu.Mlh.WpfCoreExtensions.Areas.MvvmShell.ViewModels;
using Mmu.Mlh.WpfCoreExtensions.Areas.MvvmShell.ViewModels.Behaviors;
using Mmu.Wb.PasswordBuddy.WpfUI.Areas.Credentials.Details.ViewData;

namespace Mmu.Wb.PasswordBuddy.WpfUI.Areas.Credentials.Details.Views.CredentialData
{
    public class CredentialDataViewModel : ViewModelBase, IInitializableViewModel
    {
        public CredentialDetailsViewData Data { get; private set; }

        public Task InitializeAsync(params object[] initParams)
        {
            Data = (CredentialDetailsViewData)initParams[0];

            return Task.CompletedTask;
        }
    }
}