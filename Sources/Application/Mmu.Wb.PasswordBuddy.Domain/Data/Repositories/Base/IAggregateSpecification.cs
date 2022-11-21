using System.Linq.Expressions;
using Mmu.Wb.PasswordBuddy.Domain.Models.Base;

namespace Mmu.Wb.PasswordBuddy.Domain.Data.Repositories.Base
{
    public interface IAggregateSpecification<TAg>
        where TAg : IAggregateRoot
    {
        public Expression<Func<TAg, bool>> Filter { get; }
    }
}