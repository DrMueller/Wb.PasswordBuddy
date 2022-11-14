using Mmu.Mlh.DataAccess.Areas.DataModeling.Models;
using Newtonsoft.Json;

namespace Mmu.Wb.PasswordBuddy.DataAccess.DataModeling.DataModelRepositories.Services.Servants.Implementation
{
    internal class DataModelFileAdapter<T> : IDataModelFileAdapter<T>
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