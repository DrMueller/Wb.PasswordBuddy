using Mmu.Wb.PasswordBuddy.DataAccess.DataModeling.DataModels.Base;

namespace Mmu.Wb.PasswordBuddy.DataAccess.DataModeling.DataModelRepositories.Services
{
    public interface IDataModelRepository<T>
        where T : AggregateRootDataModel
    {
        Task DeleteAsync(string id);

        Task<IReadOnlyCollection<T>> LoadAllAsync();

        Task<T> LoadAsync(string id);

        Task<T> SaveAsync(T aggregateRootDataModel);
    }
}