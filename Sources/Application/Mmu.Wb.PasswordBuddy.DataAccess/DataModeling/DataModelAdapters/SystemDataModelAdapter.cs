using Mmu.Wb.PasswordBuddy.DataAccess.DataModeling.DataModelAdapters.Implementation;
using Mmu.Wb.PasswordBuddy.DataAccess.DataModeling.DataModels;
using Mmu.Wb.PasswordBuddy.Domain.Models;

namespace Mmu.Wb.PasswordBuddy.DataAccess.DataModeling.DataModelAdapters
{
    public class SystemDataModelAdapter : DataModelAdapterBase<SystemDataModel, Domain.Models.System>
    {
        public override Domain.Models.System Adapt(SystemDataModel dataModel)
        {
            return new Domain.Models.System(
                dataModel.Id,
                dataModel.Name,
                AdaptCredentials(dataModel.Credentials),
                dataModel.AdditionalData);
        }

        public override SystemDataModel Adapt(Domain.Models.System aggregateRoot)
        {
            return new SystemDataModel
            {
                AdditionalData = aggregateRoot.AdditionalData,
                Credentials = new CredentialsDataModel
                {
                    Values = aggregateRoot.Credentials.Values.Select(f => new CredentialDataModel
                    {
                        Id = f.Id,
                        LastChanged = f.LastChanged,
                        Name = f.Name,
                        Password = f.Password,
                        UserName = f.UserName
                    }).ToList()
                },
                Id = aggregateRoot.Id,
                Name = aggregateRoot.Name
            };
        }

        private static Credential AdaptCredential(CredentialDataModel cred)
        {
            return new Credential(
                cred.Id,
                cred.Name,
                cred.UserName,
                cred.Password,
                cred.LastChanged);
        }

        private Credentials AdaptCredentials(CredentialsDataModel creds)
        {
            var cred = creds.Values.Select(AdaptCredential).ToList();

            return new Credentials(cred);
        }
    }
}