using System.Threading.Tasks;
using Mmu.Wb.PasswordBuddy.WpfUI.Areas.Details.ViewData;

namespace Mmu.Wb.PasswordBuddy.WpfUI.Areas.Details.ViewServices
{
    public interface ISystemDetailsService
    {
        Task<SystemDetailsViewData> LoadAsync(string? id);

        Task SaveAsync(SystemDetailsViewData data);
    }
}
