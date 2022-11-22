using System.Threading.Tasks;
using JetBrains.Annotations;
using Mmu.Mlh.WpfCoreExtensions.Areas.MvvmShell.ViewModels;
using Mmu.Mlh.WpfCoreExtensions.Areas.MvvmShell.ViewModels.Behaviors;
using Mmu.Wb.PasswordBuddy.WpfUI.Areas.Credentials.Details.ViewData;

namespace Mmu.Wb.PasswordBuddy.WpfUI.Areas.Credentials.Details.Views.CredentialData
{
    [PublicAPI]
    public class CredentialDataViewModel : ViewModelBase, IInitializableViewModel
    {
        public CredentialDetailsViewData Data { get; private set; } = null!;

        public Task InitializeAsync(params object[] initParams)
        {
            Data = (CredentialDetailsViewData)initParams[0];

            return Task.CompletedTask;
        }
    }
}