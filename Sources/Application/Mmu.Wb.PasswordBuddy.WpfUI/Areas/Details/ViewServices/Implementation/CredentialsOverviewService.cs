using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mmu.Mlh.LanguageExtensions.Areas.Types.Maybes;
using Mmu.Wb.PasswordBuddy.CrossCutting.LanguageExtensions.Collections;
using Mmu.Wb.PasswordBuddy.Domain.Data.Repositories;
using Mmu.Wb.PasswordBuddy.WpfUI.Areas.CredentialsOverview.ViewData;

namespace Mmu.Wb.PasswordBuddy.WpfUI.Areas.Details.ViewServices.Implementation
{
    public class CredentialsOverviewService : ICredentialsOverviewService
    {
        private readonly ISystemRepository _systemRepo;

        public CredentialsOverviewService(ISystemRepository systemRepo)
        {
            _systemRepo = systemRepo;
        }

        public async Task<IReadOnlyCollection<CredentialOverviewEntryViewData>> LoadAsync(string systemId)
        {
            if (string.IsNullOrEmpty(systemId))
            {
                return new List<CredentialOverviewEntryViewData>();
            }

            var system = await _systemRepo.LoadAsync(systemId);

            return system.Credentials.Values
                .Where(f => f.Changes.HasChanges)
                .Select(f => new { f.Id, f.Changes.Latest })
                .Select(cred => new CredentialOverviewEntryViewData(cred.Id, cred.Latest.UserName, cred.Latest.Password, cred.Latest.Changed))
                .ToList();
        }
        
    }
}
