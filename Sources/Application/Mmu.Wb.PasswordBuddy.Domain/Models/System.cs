using Mmu.Mlh.LanguageExtensions.Areas.DeepCopying;
using Mmu.Mlh.LanguageExtensions.Areas.Invariance;
using Mmu.Wb.PasswordBuddy.Domain.Models.Base;

namespace Mmu.Wb.PasswordBuddy.Domain.Models
{
    public class System : AggregateRoot
    {
        private readonly Credentials _credentials;

        public System(
            string id,
            string name,
            Credentials credentials,
            string additionalData)
        {
            Guard.StringNotNullOrEmpty(() => name);
            Guard.ObjectNotNull(() => credentials);
            Id = id;
            Name = name;
            AdditionalData = additionalData;
            _credentials = credentials;
        }

        public string AdditionalData { get; }
        public Credentials Credentials => _credentials.DeepCopy();
        public string Name { get; }

        public void RemoveCredential(string credentialId)
        {
            _credentials.RemoveCredential(credentialId);
        }

        public void UpsertCredential(Credential cred)
        {
            _credentials.UpsertCredential(cred);
        }
    }
}