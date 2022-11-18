using Mmu.Mlh.LanguageExtensions.Areas.Invariance;
using Mmu.Wb.PasswordBuddy.Domain.Models.Base;

namespace Mmu.Wb.PasswordBuddy.Domain.Models
{
    public class System : AggregateRoot
    {
        public Credentials Credentials { get; }
        public string AdditionalData { get; }
        public string Name { get; }

        public System(
            string? id,
            string name,
            Credentials credentials,
            string additionalData )
        {
            Guard.StringNotNullOrEmpty(() => name);
            Guard.ObjectNotNull(() => credentials);
            Id = id;
            Name = name;
            AdditionalData = additionalData;
            Credentials = credentials;
        }
    }
}