using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mmu.Wb.PasswordBuddy.WpfUI.Areas.CredentialsOverview.ViewData
{
    public class CredentialOverviewEntryViewData
    {
        public string CredentialId { get; }
        public string Password { get; }
        public DateTime Changed { get; }
        public string UserName { get; }

        public CredentialOverviewEntryViewData(
            string credentialId,
            string userName,
            string password,
            DateTime changed)
        {
            CredentialId = credentialId;
            Password = password;
            Changed = changed;
            UserName = userName;
        }

    }
}
