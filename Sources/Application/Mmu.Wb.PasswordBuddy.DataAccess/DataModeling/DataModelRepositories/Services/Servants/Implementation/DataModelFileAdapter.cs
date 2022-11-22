using Mmu.Wb.PasswordBuddy.DataAccess.DataModeling.DataModels.Base;
using Newtonsoft.Json;
using File = Mmu.Wb.PasswordBuddy.DataAccess.DataModeling.DataModelRepositories.Models.File;

namespace Mmu.Wb.PasswordBuddy.DataAccess.DataModeling.DataModelRepositories.Services.Servants.Implementation
{
    public class DataModelFileAdapter<T> : IDataModelFileAdapter<T>
        where T : AggregateRootDataModel
    {
        public T AdaptToDataModel(File dataModelFile)
        {
            return JsonConvert.DeserializeObject<T>(dataModelFile.Content)!;
        }

        public File AdaptToFile(T dataModel)
        {
            var fileContent = JsonConvert.SerializeObject(dataModel);

            return new File(dataModel.Id, fileContent);
        }
    }
}