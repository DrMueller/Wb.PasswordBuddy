using Mmu.Wb.PasswordBuddy.Domain.Data.Repositories;
using Mmu.Wb.PasswordBuddy.Domain.Models;

namespace Mmu.Wb.PasswordBuddy.DataAccess.Repositories
{
    public class SystemRepository : ISystemRepository
    {
        public Task<IReadOnlyCollection<Domain.Models.System>> LoadAllAsync()
        {
            var list = new List<Domain.Models.System>
            {
                new(
                    "Name123",
                    new CredentialChanges(
                        new List<CredentialChange>()),
                    "Tra")
            };

            return Task.FromResult<IReadOnlyCollection<Domain.Models.System>>(list);
        }

        public Task<Domain.Models.System> LoadAsync(string id)
        {
            return Task.FromResult(new Domain.Models.System(
                "Name123 " + id,
                new CredentialChanges(
                    new List<CredentialChange>()),
                "Tra", id));
        }

        public Task SaveAsync(Domain.Models.System system)
        {
            return Task.CompletedTask;
        }
    }
}