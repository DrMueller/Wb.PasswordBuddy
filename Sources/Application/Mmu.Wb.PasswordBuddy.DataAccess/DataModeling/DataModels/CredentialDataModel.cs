using JetBrains.Annotations;
using Mmu.Wb.PasswordBuddy.DataAccess.DataModeling.DataModels.Base;

namespace Mmu.Wb.PasswordBuddy.DataAccess.DataModeling.DataModels
{
    [PublicAPI]
    public class CredentialDataModel : EntityDataModel
    {
        public DateTime? LastChanged { get; set; }
        public string Name { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string UserName { get; set; } = null!;
    }
}