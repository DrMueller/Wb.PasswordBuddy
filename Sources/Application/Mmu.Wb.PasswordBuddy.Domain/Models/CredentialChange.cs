using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mmu.Wb.PasswordBuddy.Domain.Models
{
    public class CredentialChange
    {
        public string Password { get; }
        public string UserName { get; }
        public DateTime Changed { get; }

        public CredentialChange(
            string userName,
            string password,
            DateTime changed)
        {
            Password = password;
            UserName = userName;
            Changed = changed;
        }

    }
}
