using Mmu.Mlh.LanguageExtensions.Areas.DeepCopying;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mmu.Wb.PasswordBuddy.Domain.Models
{
    public class Credentials
    {
        private readonly List<Credential> _values;

        public IReadOnlyCollection<Credential> Values => _values.DeepCopy();
            
        public Credentials(List<Credential> values)
        {
            _values = values;
        }

    }
}
