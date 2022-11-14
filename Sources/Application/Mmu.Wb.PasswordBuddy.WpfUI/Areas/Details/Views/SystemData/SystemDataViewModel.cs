using System.Threading.Tasks;
using System.Windows.Markup;
using Mmu.Mlh.LanguageExtensions.Areas.Invariance;
using Mmu.Mlh.WpfCoreExtensions.Areas.MvvmShell.ViewModels;
using Mmu.Mlh.WpfCoreExtensions.Areas.MvvmShell.ViewModels.Behaviors;
using Mmu.Wb.PasswordBuddy.WpfUI.Areas.Details.ViewData;

namespace Mmu.Wb.PasswordBuddy.WpfUI.Areas.Details.Views.SystemData
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