using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mmu.Wb.PasswordBuddy.DataAccess.DataModeling.DataModels
{
    public class CredentialChangeDataModel
    {
        public string Password { get; set; }
        public string UserName { get; set; }
        public DateTime Changed { get; set; }
    }
}
