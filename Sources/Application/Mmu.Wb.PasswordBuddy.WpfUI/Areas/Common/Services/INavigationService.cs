using System.Threading.Tasks;

namespace Mmu.Wb.PasswordBuddy.WpfUI.Areas.Common.Services
{
    public interface INavigationService
    {
        Task ToMainAsync();

        Task ToCredentialsOverviewAsync(string systemId);
    }
}