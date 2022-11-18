using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mmu.Mlh.LanguageExtensions.Areas.Invariance;
using Mmu.Wb.PasswordBuddy.Domain.Models.Base;

namespace Mmu.Wb.PasswordBuddy.Domain.Models
{
    public class Credential : Entity
    {
        public string Name { get; }
        public CredentialChanges Changes { get; }

        public Credential(string name, CredentialChanges changes)
        {
            Guard.StringNotNullOrEmpty(() => name);
            Guard.ObjectNotNull(() => changes);

            Name = name;
            Changes = changes;
        }
    }
}
