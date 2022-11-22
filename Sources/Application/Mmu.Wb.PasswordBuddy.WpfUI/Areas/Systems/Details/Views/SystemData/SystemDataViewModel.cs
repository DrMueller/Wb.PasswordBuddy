using System.Threading.Tasks;
using JetBrains.Annotations;
using Mmu.Mlh.WpfCoreExtensions.Areas.MvvmShell.ViewModels;
using Mmu.Mlh.WpfCoreExtensions.Areas.MvvmShell.ViewModels.Behaviors;
using Mmu.Wb.PasswordBuddy.WpfUI.Areas.Systems.Details.ViewData;

namespace Mmu.Wb.PasswordBuddy.WpfUI.Areas.Systems.Details.Views.SystemData
{
    [PublicAPI]
    public class SystemDataViewModel : ViewModelBase, IInitializableViewModel
    {
        public SystemDetailsViewData Data { get; private set; } = null!;

        public Task InitializeAsync(params object[] initParams)
        {
            Data = (SystemDetailsViewData)initParams[0];

            return Task.CompletedTask;
        }
    }
}