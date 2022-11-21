using Mmu.Mlh.LanguageExtensions.Areas.Invariance;
using Mmu.Wb.PasswordBuddy.Domain.Models.Base;

namespace Mmu.Wb.PasswordBuddy.Domain.Models
{
    public class Credential : Entity
    {
        public Credential(
            string? id,
            string name,
            string userName,
            string password,
            DateTime? lastChanged)
        {
            Guard.StringNotNullOrEmpty(() => name);
            Guard.StringNotNullOrEmpty(() => password);

            Name = name;
            UserName = userName;
            Password = password;
            LastChanged = lastChanged;
        }

        public DateTime? LastChanged { get; }
        public string Name { get; }
        public string Password { get; }
        public string UserName { get; }
    }
}