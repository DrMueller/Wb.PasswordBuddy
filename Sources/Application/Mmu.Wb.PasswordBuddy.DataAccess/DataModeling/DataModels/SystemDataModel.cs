using JetBrains.Annotations;
using Mmu.Wb.PasswordBuddy.DataAccess.DataModeling.DataModels.Base;

namespace Mmu.Wb.PasswordBuddy.DataAccess.DataModeling.DataModels
{
    [PublicAPI]
    public class SystemDataModel : AggregateRootDataModel
    {
        public string AdditionalData { get; set; } = null!;
        public CredentialsDataModel Credentials { get; set; } = null!;
        public string Name { get; set; } = null!;
    }
}