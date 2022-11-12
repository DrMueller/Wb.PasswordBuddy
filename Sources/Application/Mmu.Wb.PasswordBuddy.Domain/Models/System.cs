using Mmu.Mlh.LanguageExtensions.Areas.Invariance;
using Mmu.Wb.PasswordBuddy.Domain.Models.Base;

namespace Mmu.Wb.PasswordBuddy.Domain.Models
{
    public class System : AggregateRoot
    {
        private readonly CredentialChanges _credentialChanges;
        public string AdditionalData { get; }
        public string Name { get; }

        public System(
            string id,
            string name,
            CredentialChanges credentialChanges,
            string additionalData)
        {
            Guard.StringNotNullOrEmpty(() => name);
            Guard.ObjectNotNull(() => credentialChanges);
            Id = id;
            Name = name;
            AdditionalData = additionalData;
            _credentialChanges = credentialChanges;
        }
    }
}