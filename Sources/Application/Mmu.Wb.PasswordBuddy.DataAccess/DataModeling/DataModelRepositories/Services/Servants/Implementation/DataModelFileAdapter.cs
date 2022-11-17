using Mmu.Wb.PasswordBuddy.DataAccess.DataModeling.DataModels.Base;
using Newtonsoft.Json;

namespace Mmu.Wb.PasswordBuddy.DataAccess.DataModeling.DataModelRepositories.Services.Servants.Implementation
{
    public class DataModelFileAdapter<T> : IDataModelFileAdapter<T>
        where T : AggregateRootDataModel
    {
        public T AdaptToDataModel(Mmu.Wb.PasswordBuddy.DataAccess.DataModeling.DataModelRepositories.Models.File dataModelFile)
        {
            return JsonConvert.DeserializeObject<T>(dataModelFile.Content);
        }

        public Models.File AdaptToFile(T dataModel)
        {
            var fileContent = JsonConvert.SerializeObject(dataModel);

            return new Models.File(dataModel.Id, fileContent);
        }
    }
}