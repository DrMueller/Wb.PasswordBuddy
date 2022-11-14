using Mmu.Mlh.DataAccess.Areas.DataModeling.Models;
using Mmu.Wb.PasswordBuddy.Domain.Models.Base;

namespace Mmu.Mlh.DataAccess.Areas.DataModeling.Services
{
    public interface IDataModelAdapter<TDataModel, TAggregateRoot>
        where TDataModel : AggregateRootDataModel
        where TAggregateRoot : AggregateRoot
    {
        TAggregateRoot Adapt(TDataModel dataModel);

        TDataModel Adapt(TAggregateRoot aggregateRoot);
    }
}