using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mmu.Wb.PasswordBuddy.Domain.Services
{
    public interface ICredentialsService
    {
        Task DeleteCredentials(string systemId, string credentialsId);
    }
}
