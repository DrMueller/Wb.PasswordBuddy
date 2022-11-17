using Mmu.Wb.PasswordBuddy.DataAccess.DataModeling.DataModelAdapters.Implementation;
using Mmu.Wb.PasswordBuddy.DataAccess.DataModeling.DataModels;
using Mmu.Wb.PasswordBuddy.Domain.Models;

namespace Mmu.Wb.PasswordBuddy.DataAccess.DataModeling.DataModelAdapters
{
    public class SystemDataModelAdapter : DataModelAdapterBase<SystemDataModel, Domain.Models.System>
    {
        public override Domain.Models.System Adapt(SystemDataModel dataModel)
        {
            var credChanges = dataModel.CredentialChanges.Changes
                .Select(f => new CredentialChange(f.Password, f.UserName)).ToList();
            return new Domain.Models.System(
                dataModel.Id,
                dataModel.Name,
                new CredentialChanges(credChanges),
                dataModel.AdditionalData);
        }

        public override SystemDataModel Adapt(Domain.Models.System aggregateRoot)
        {
            return new SystemDataModel
            {
                AdditionalData = aggregateRoot.AdditionalData,
                CredentialChanges = new CredentialChangesDataModel
                {
                    Changes = aggregateRoot.CredentialChanges.Changes.Select(f => new CredentialChangeDataModel
                    {
                        Password = f.Password, UserName = f.UserName
                    }).ToList()
                },
                Id = aggregateRoot.Id,
                Name = aggregateRoot.Name
            };
        }
    }
}