using System.Threading.Tasks;
using Mmu.Mlh.WpfCoreExtensions.Areas.MvvmShell.ViewModels;
using Mmu.Mlh.WpfCoreExtensions.Areas.MvvmShell.ViewModels.Behaviors;
using Mmu.Wb.PasswordBuddy.WpfUI.Areas.CredentialDetails.ViewData;

namespace Mmu.Wb.PasswordBuddy.WpfUI.Areas.CredentialDetails.Views.CredentialData
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