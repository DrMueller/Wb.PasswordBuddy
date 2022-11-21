using System.Diagnostics.CodeAnalysis;
using JetBrains.Annotations;
using Mmu.Mlh.LanguageExtensions.Areas.Types.Maybes;
using Mmu.Wb.PasswordBuddy.Domain.Models.Base;

namespace Mmu.Wb.PasswordBuddy.Domain.Data.Repositories.Base
{
    [SuppressMessage("Design", "CA1040:Avoid empty interfaces", Justification = "Marker interface for easier generic handling")]
    public interface IRepository
    {
    }

    [PublicAPI]
    public interface IRepository<TAg> : IRepository
        where TAg : IAggregateRoot
    {
        Task DeleteAsync(long id);

        Task InsertAsync(TAg entity);

        Task<IReadOnlyCollection<TAg>> LoadCollectionAsync(IAggregateSpecification<TAg> spec);

        Task<Maybe<TAg>> LoadSingleAsync(IAggregateSpecification<TAg> spec);

        Task<Maybe<TAg>> LoadSingleAsync(long id);
    }
}