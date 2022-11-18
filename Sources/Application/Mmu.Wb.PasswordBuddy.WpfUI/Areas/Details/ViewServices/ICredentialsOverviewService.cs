using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mmu.Wb.PasswordBuddy.WpfUI.Areas.CredentialsOverview.ViewData;

namespace Mmu.Wb.PasswordBuddy.WpfUI.Areas.Details.ViewServices
{
    public interface ICredentialsOverviewService
    {
        Task<IReadOnlyCollection<CredentialOverviewEntryViewData>> LoadAsync(string systemId);
    }
}
