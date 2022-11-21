using System.Threading.Tasks;
using Mmu.Mlh.WpfCoreExtensions.Areas.MvvmShell.ViewModels;
using Mmu.Mlh.WpfCoreExtensions.Areas.MvvmShell.ViewModels.Behaviors;
using Mmu.Wb.PasswordBuddy.WpfUI.Areas.Systems.Details.ViewData;

namespace Mmu.Wb.PasswordBuddy.WpfUI.Areas.Systems.Details.Views.SystemData
{
    public class SystemDataViewModel : ViewModelBase, IInitializableViewModel
    {
        public SystemDetailsViewData Data { get; private set; }

        public Task InitializeAsync(params object[] initParams)
        {
            Data = (SystemDetailsViewData)initParams[0];

            return Task.CompletedTask;
        }
    }
}