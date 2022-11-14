using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mmu.Wb.PasswordBuddy.Domain.Models
{
    public class CredentialChanges
    {
        public IList<CredentialChange> Changes { get; }

        public CredentialChanges(IList<CredentialChange>? changes = null)
        {
            Changes = changes ?? new List<CredentialChange>();
        }

    }
}
