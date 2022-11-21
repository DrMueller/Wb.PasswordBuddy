using System;

namespace Mmu.Wb.PasswordBuddy.WpfUI.Areas.CredentialDetails.ViewData
{
    public class CredentialDetailsViewData
    {
        public CredentialDetailsViewData(
            string? id,
            string name,
            string userName,
            string password,
            DateTime? lastChanged)
        {
            Name = name;
            UserName = userName;
            Password = password;
            ID = id;
            LastChanged = lastChanged;
        }

        public string ID { get; }

        public string IdDescription => string.IsNullOrEmpty(ID) ? "New" : ID;

        public DateTime? LastChanged { get; }

        public string LastChangedDescription => LastChanged == null ? "Never" : LastChanged.ToString();
        public string Name { get; set; }
        public string Password { get; set; }
        public string UserName { get; set; }

        public static CredentialDetailsViewData CreateEmpty()
        {
            return new CredentialDetailsViewData(
                null,
                string.Empty,
                string.Empty,
                string.Empty,
                null);
        }
    }
}