using Mmu.Wb.PasswordBuddy.DataAccess.DataModeling.DataModels.Base;

namespace Mmu.Wb.PasswordBuddy.DataAccess.DataModeling.DataModels
{
    public class CredentialDataModel : EntityDataModel
    {
        public DateTime? LastChanged { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public string UserName { get; set; }
    }
}