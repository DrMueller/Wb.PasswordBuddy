using Mmu.Wb.PasswordBuddy.DataAccess.DataModeling.DataModels.Base;

namespace Mmu.Wb.PasswordBuddy.DataAccess.DataModeling.DataModelRepositories.Services.Servants
{
    public interface IIdSetter
    {
        void SetIds(AggregateRootDataModel ag);
    }
}