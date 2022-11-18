using System.Threading.Tasks;
using Mmu.Mlh.WpfCoreExtensions.Areas.MvvmShell.ViewModels;
using Mmu.Mlh.WpfCoreExtensions.Areas.MvvmShell.ViewModels.Behaviors;

namespace Mmu.Wb.PasswordBuddy.WpfUI.Areas.CredentialDetails.Views.Details
{
    public class CredentialDetailsViewModel : ViewModelBase, IInitializableViewModel, IDisplayableViewModel
    {
        public string HeadingDescription { get; } = "Edit Credentials";

        public Task InitializeAsync(params object[] initParams)
        {
            return Task.CompletedTask;
        }
    }
}