using Mmu.Wb.PasswordBuddy.DataAccess.DataModeling.DataModels.Base;
using Mmu.Wb.PasswordBuddy.Domain.Models.Base;

namespace Mmu.Wb.PasswordBuddy.DataAccess.DataModeling.DataModelAdapters.Implementation
{
    public abstract class DataModelAdapterBase<TDataModel, TAggregateRoot> : IDataModelAdapter<TDataModel, TAggregateRoot>
        where TDataModel : AggregateRootDataModel
        where TAggregateRoot : AggregateRoot
    {
        public abstract TAggregateRoot Adapt(TDataModel dataModel);

        public abstract TDataModel Adapt(TAggregateRoot aggregateRoot);
    }
}