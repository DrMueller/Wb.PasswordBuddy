using Mmu.Mlh.LanguageExtensions.Areas.Invariance;
using Mmu.Wb.PasswordBuddy.Domain.Models.Base;

namespace Mmu.Wb.PasswordBuddy.Domain.Models
{
    public class System : AggregateRoot
    {
        public CredentialChanges CredentialChanges { get; }
        public string AdditionalData { get; }
        public string Name { get; }

        public System(
            string name,
            CredentialChanges credentialChanges,
            string additionalData,
            string? id = null)
        {
            Guard.StringNotNullOrEmpty(() => name);
            Guard.ObjectNotNull(() => credentialChanges);
            Id = id ?? Guid.NewGuid().ToString();
            Name = name;
            AdditionalData = additionalData;
            CredentialChanges = credentialChanges;
        }
    }
}