using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Mmu.Wb.PasswordBuddy.WpfUI.Areas.Systems.Overview.ViewData;

namespace Mmu.Wb.PasswordBuddy.WpfUI.Areas.Systems.Overview.ViewServices
{
    public interface ISystemOverviewService
    {
        Task<ObservableCollection<SystemOverviewEntryViewData>> LoadOverviewAsync();
    }
}