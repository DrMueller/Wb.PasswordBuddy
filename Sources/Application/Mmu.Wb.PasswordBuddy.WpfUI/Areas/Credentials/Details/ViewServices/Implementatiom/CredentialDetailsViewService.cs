using System.Linq;
using System.Threading.Tasks;
using Mmu.Mlh.WpfCoreExtensions.Areas.MvvmShell.ViewModels.Services;
using Mmu.Wb.PasswordBuddy.Domain.Data.Repositories;
using Mmu.Wb.PasswordBuddy.Domain.Models;
using Mmu.Wb.PasswordBuddy.WpfUI.Areas.Credentials.Details.ViewData;

namespace Mmu.Wb.PasswordBuddy.WpfUI.Areas.Credentials.Details.ViewServices.Implementatiom
{
    public class CredentialDetailsViewService : ICredentialDetailsViewService
    {
        private readonly ISystemRepository _systemRepo;
        private readonly IViewModelFactory _vmFactory;

        public CredentialDetailsViewService(
            ISystemRepository systemRepo,
            IViewModelFactory vmFactory)
        {
            _systemRepo = systemRepo;
            _vmFactory = vmFactory;
        }

        public async Task<CredentialDetailsViewData> LoadAsync(string systemId, string? credentialId)
        {
            if (string.IsNullOrEmpty(credentialId))
            {
                return await _vmFactory.CreateAsync<CredentialDetailsViewData>(null, null);
            }

            var system = await _systemRepo.LoadAsync(systemId);
            var cred = system.Credentials.Values.Single(f => f.Id == credentialId);

            var viewData = await _vmFactory.CreateAsync<CredentialDetailsViewData>(credentialId, cred.LastChanged);

            viewData.Name = cred.Name;
            viewData.UserName = cred.UserName;
            viewData.Password = cred.Password;

            return viewData;
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