using System.Linq.Expressions;
using Mmu.Mlh.LanguageExtensions.Areas.Types.Maybes;
using Mmu.Wb.PasswordBuddy.DataAccess.DataModeling.DataModels.Base;

namespace Mmu.Wb.PasswordBuddy.DataAccess.DataModeling.DataModelRepositories.Services
{
    public interface IDataModelRepository<T>
        where T : AggregateRootDataModel
    {
        Task DeleteAsync(string id);

        Task<IReadOnlyCollection<T>> LoadAllAsync();

        Task<Maybe<T>> LoadAsync(string id);

        Task<T> SaveAsync(T aggregateRootDataModel);
    }
}