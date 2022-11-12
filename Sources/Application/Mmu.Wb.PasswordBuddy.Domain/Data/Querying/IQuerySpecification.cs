using System.Linq.Expressions;
using Mmu.Wb.PasswordBuddy.Domain.Models.Base;

namespace Mmu.Wb.PasswordBuddy.Domain.Data.Querying
{
    public interface IQuerySpecification<T, TResult> : IQuerySpecification<T>
        where T : Entity
    {
        Expression<Func<T, TResult>> Selector { get; }
    }

    public interface IQuerySpecification<T>
        where T : Entity
    {
        IQueryable<T> Apply(IQueryable<T> qry);
    }
}