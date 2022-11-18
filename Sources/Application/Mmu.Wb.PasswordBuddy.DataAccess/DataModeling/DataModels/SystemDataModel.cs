using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mmu.Wb.PasswordBuddy.DataAccess.DataModeling.DataModels.Base;

namespace Mmu.Wb.PasswordBuddy.DataAccess.DataModeling.DataModels
{
    public class SystemDataModel : AggregateRootDataModel
    {
        public CredentialsDataModel Credentials { get; set; }

        public string Name { get; set; }

        public string AdditionalData { get; set; }
    }
}
