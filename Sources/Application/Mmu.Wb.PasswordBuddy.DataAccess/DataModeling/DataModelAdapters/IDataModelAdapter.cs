using Mmu.Wb.PasswordBuddy.DataAccess.DataModeling.DataModels.Base;
using Mmu.Wb.PasswordBuddy.Domain.Models.Base;

namespace Mmu.Wb.PasswordBuddy.DataAccess.DataModeling.DataModelAdapters
{
    public interface IDataModelAdapter<TDataModel, TAggregateRoot>
        where TDataModel : AggregateRootDataModel
        where TAggregateRoot : AggregateRoot
    {
        TAggregateRoot Adapt(TDataModel dataModel);

        TDataModel Adapt(TAggregateRoot aggregateRoot);
    }
}