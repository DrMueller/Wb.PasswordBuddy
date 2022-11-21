using System.Threading.Tasks;
using Mmu.Wb.PasswordBuddy.WpfUI.Areas.Systems.Details.ViewData;

namespace Mmu.Wb.PasswordBuddy.WpfUI.Areas.Systems.Details.ViewServices
{
    public interface ISystemDetailsService
    {
        Task<SystemDetailsViewData> LoadAsync(string? id);

        Task SaveAsync(SystemDetailsViewData data);
    }
}