using System.Linq;
using System.Threading.Tasks;
using Mmu.Wb.PasswordBuddy.Domain.Data.Repositories;
using Mmu.Wb.PasswordBuddy.Domain.Models;
using Mmu.Wb.PasswordBuddy.WpfUI.Areas.CredentialDetails.ViewData;

namespace Mmu.Wb.PasswordBuddy.WpfUI.Areas.CredentialDetails.ViewServices.Implementatiom
{
    public class CredentialDetailsViewService : ICredentialDetailsViewService
    {
        private readonly ISystemRepository _systemRepo;

        public CredentialDetailsViewService(ISystemRepository systemRepo)
        {
            _systemRepo = systemRepo;
        }

        public async Task<CredentialDetailsViewData> LoadAsync(string systemId, string? credentialId)
        {
            if (string.IsNullOrEmpty(credentialId))
            {
                return CredentialDetailsViewData.CreateEmpty();
            }

            var system = await _systemRepo.LoadAsync(systemId);
            var cred = system.Credentials.Values.Single(f => f.Id == credentialId);

            return new CredentialDetailsViewData(
                cred.Id,
                cred.Name,
                cred.UserName,
                cred.Password,
                cred.LastChanged);
        }

        public async Task SaveAsync(string systemId, CredentialDetailsViewData data)
        {
            var system = await _systemRepo.LoadAsync(systemId);
            var cred = new Credential(
                data.ID,
                data.Name,
                data.UserName,
                data.Password,
                data.LastChanged);

            system.UpsertCredential(cred);

            await _systemRepo.SaveAsync(system);
        }
    }
}