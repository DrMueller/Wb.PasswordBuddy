using System;

namespace Mmu.Wb.PasswordBuddy.WpfUI.Areas.CredentialsOverview.ViewData
{
    public class CredentialOverviewEntryViewData
    {
        public CredentialOverviewEntryViewData(
            string credentialId,
            string userName,
            string password,
            DateTime? lastChanged)
        {
            CredentialId = credentialId;
            Password = password;
            LastChanged = lastChanged;
            UserName = userName;
        }

        public string CredentialId { get; }
        public DateTime? LastChanged { get; }
        public string Password { get; }
        public string UserName { get; }
    }
}