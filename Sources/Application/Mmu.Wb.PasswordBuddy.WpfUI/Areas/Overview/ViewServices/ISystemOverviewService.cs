using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Mmu.Wb.PasswordBuddy.WpfUI.Areas.Overview.ViewData;

namespace Mmu.Wb.PasswordBuddy.WpfUI.Areas.Overview.ViewServices
{
    public interface ISystemOverviewService
    {
        Task<ObservableCollection<SystemOverviewEntryViewData>> LoadOverviewAsync();
    }
}