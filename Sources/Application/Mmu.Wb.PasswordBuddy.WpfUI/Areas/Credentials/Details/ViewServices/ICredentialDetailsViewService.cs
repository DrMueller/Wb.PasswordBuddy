using System.Threading.Tasks;
using Mmu.Wb.PasswordBuddy.WpfUI.Areas.Credentials.Details.ViewData;

namespace Mmu.Wb.PasswordBuddy.WpfUI.Areas.Credentials.Details.ViewServices
{
    public interface ICredentialDetailsViewService
    {
        Task<CredentialDetailsViewData> LoadAsync(string systemId, string? credentialId);

        Task SaveAsync(string systemId, CredentialDetailsViewData data);
    }
}