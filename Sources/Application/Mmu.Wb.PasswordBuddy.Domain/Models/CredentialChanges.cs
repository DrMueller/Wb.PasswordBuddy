using Mmu.Mlh.LanguageExtensions.Areas.Types.Maybes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mmu.Wb.PasswordBuddy.Domain.Models
{
    public class CredentialChanges
    {
        public IList<CredentialChange> Values { get; }

        public bool HasChanges
        {
            get
            {
                return Values.Any();
            }
        }

        public CredentialChange Latest
        {
            get
            {
                return Values.OrderByDescending(f => f.Changed).First();
            }
        }

    public CredentialChanges(IList<CredentialChange>? changes = null)
        {
            Values = changes ?? new List<CredentialChange>();
        }

    }
}
