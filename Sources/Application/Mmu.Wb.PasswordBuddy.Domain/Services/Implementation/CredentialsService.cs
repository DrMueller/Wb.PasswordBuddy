using Mmu.Wb.PasswordBuddy.Domain.Data.Repositories;

namespace Mmu.Wb.PasswordBuddy.Domain.Services.Implementation
{
    public class CredentialsService : ICredentialsService
    {
        private readonly ISystemRepository _systemRepo;

        public CredentialsService(ISystemRepository systemRepo)
        {
            _systemRepo = systemRepo;
        }

        public async Task DeleteCredentials(string systemId, string credentialsId)
        {
            var system = await _systemRepo.LoadAsync(systemId);
            system.RemoveCredential(credentialsId);

            await _systemRepo.SaveAsync(system);
        }
    }
}