using Mmu.Wb.PasswordBuddy.DataAccess.DataModeling.DataModels.Base;

namespace Mmu.Wb.PasswordBuddy.DataAccess.DataModeling.DataModelRepositories.Services.Servants
{
    public interface IDataModelFileAdapter<T>
        where T : AggregateRootDataModel
    {
        T AdaptToDataModel(Models.File dataModelFile);

        Models.File AdaptToFile(T dataModel);
    }
}