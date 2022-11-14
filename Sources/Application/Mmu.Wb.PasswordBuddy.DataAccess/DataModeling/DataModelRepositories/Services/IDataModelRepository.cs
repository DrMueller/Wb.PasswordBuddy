using System.Linq.Expressions;
using Mmu.Mlh.DataAccess.Areas.DataModeling.Models;
using Mmu.Mlh.LanguageExtensions.Areas.Types.Maybes;

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