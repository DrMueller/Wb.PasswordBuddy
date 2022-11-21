using Mmu.Wb.PasswordBuddy.DataAccess.DataModeling.DataModels.Base;
using File = Mmu.Wb.PasswordBuddy.DataAccess.DataModeling.DataModelRepositories.Models.File;

namespace Mmu.Wb.PasswordBuddy.DataAccess.DataModeling.DataModelRepositories.Services.Servants
{
    public interface IDataModelFileAdapter<T>
        where T : AggregateRootDataModel
    {
        T AdaptToDataModel(File dataModelFile);

        File AdaptToFile(T dataModel);
    }
}