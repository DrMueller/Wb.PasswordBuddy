using Mmu.Wb.PasswordBuddy.DataAccess.DataModeling.DataModels.Base;
using Mmu.Wb.PasswordBuddy.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mmu.Wb.PasswordBuddy.DataAccess.DataModeling.DataModels
{
    public class CredentialDataModel : EntityDataModel
    {
        public string Name { get; set; }
        public CredentialChangesDataModel Changes { get; set; }
    }
}
