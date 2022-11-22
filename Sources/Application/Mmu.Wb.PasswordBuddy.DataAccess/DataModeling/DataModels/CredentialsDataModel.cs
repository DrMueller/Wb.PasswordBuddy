using JetBrains.Annotations;

namespace Mmu.Wb.PasswordBuddy.DataAccess.DataModeling.DataModels
{
    [PublicAPI]
    public class CredentialsDataModel
    {
        public List<CredentialDataModel> Values { get; set; } = null!;
    }
}