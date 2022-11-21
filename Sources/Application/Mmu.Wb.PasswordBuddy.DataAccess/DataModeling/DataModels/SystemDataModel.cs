using Mmu.Wb.PasswordBuddy.DataAccess.DataModeling.DataModels.Base;

namespace Mmu.Wb.PasswordBuddy.DataAccess.DataModeling.DataModels
{
    public class SystemDataModel : AggregateRootDataModel
    {
        public string AdditionalData { get; set; }
        public CredentialsDataModel Credentials { get; set; }

        public string Name { get; set; }
    }
}