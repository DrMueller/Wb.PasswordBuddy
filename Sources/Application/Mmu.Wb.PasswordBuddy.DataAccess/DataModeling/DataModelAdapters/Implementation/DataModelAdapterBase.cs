using Mmu.Mlh.DataAccess.Areas.DataModeling.Models;
using Mmu.Wb.PasswordBuddy.Domain.Models.Base;

namespace Mmu.Mlh.DataAccess.Areas.DataModeling.Services.Implementation
{
    public abstract class DataModelAdapterBase<TDataModel, TAggregateRoot> : IDataModelAdapter<TDataModel, TAggregateRoot>
        where TDataModel : AggregateRootDataModel
        where TAggregateRoot : AggregateRoot
    {
        public abstract TAggregateRoot Adapt(TDataModel dataModel);

        public abstract TDataModel Adapt(TAggregateRoot aggregateRoot);
    }
}