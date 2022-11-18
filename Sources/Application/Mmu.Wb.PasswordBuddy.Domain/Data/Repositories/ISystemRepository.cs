using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mmu.Mlh.LanguageExtensions.Areas.Types.Maybes;

namespace Mmu.Wb.PasswordBuddy.Domain.Data.Repositories
{
    public interface ISystemRepository
    {
        Task<IReadOnlyCollection<Models.System>> LoadAllAsync();

        Task<Models.System> LoadAsync(string id);

        Task SaveAsync(Models.System system);

        Task DeleteAsync(string systemId);
    }
}
