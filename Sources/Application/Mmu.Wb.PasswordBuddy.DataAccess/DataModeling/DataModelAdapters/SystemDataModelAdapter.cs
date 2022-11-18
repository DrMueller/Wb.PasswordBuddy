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

        private Credentials AdaptCredentials(CredentialsDataModel creds)
        {
            var cred = creds.Values.Select(AdaptCredential).ToList();
            return new Credentials(cred);

        }

        private Credential AdaptCredential(CredentialDataModel cred)
        {
            return new Credential(
                cred.Name,
                AdaptCredentialChanges(cred.Changes));
        }

        private CredentialChanges AdaptCredentialChanges(CredentialChangesDataModel credChanges)
        {
            return new CredentialChanges(credChanges.Values.Select(AdaptCredentialChange).ToList());
        }

        private CredentialChange AdaptCredentialChange(CredentialChangeDataModel credChange)
        {
            return new CredentialChange(credChange.UserName,
                credChange.Password,
                credChange.Changed);
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
                        Changes = new CredentialChangesDataModel
                        {
                            Values = f.Changes.Values.Select(c => new CredentialChangeDataModel
                            {
                                Changed = c.Changed,
                                Password = c.Password,
                                UserName = c.UserName
                            }).ToList()
                        }
                    }).ToList()
                },
                Id = aggregateRoot.Id,
                Name = aggregateRoot.Name
            };
        }
    }
}