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
                new Domain.Models.System(
                    Guid.NewGuid().ToString(),
                    "Tra",
                    new CredentialChanges(
                        new List<CredentialChange>()),
                    "")
            };

            return Task.FromResult<IReadOnlyCollection<Domain.Models.System>>(list);
        }
    }
}