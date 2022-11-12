using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Mmu.Wb.PasswordBuddy.WpfUI.Areas.System.Overview.ViewData;

namespace Mmu.Wb.PasswordBuddy.WpfUI.Areas.System.Overview.ViewServices
{
    public interface ISystemOverviewService
    {
        Task<ObservableCollection<SystemOverviewEntryViewData>> LoadOverviewAsync();
    }
}