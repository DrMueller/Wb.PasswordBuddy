using Mmu.Wb.PasswordBuddy.DataAccess.DataModeling.DataModelAdapters;
using Mmu.Wb.PasswordBuddy.DataAccess.DataModeling.DataModelRepositories.Services;
using Mmu.Wb.PasswordBuddy.DataAccess.DataModeling.DataModels;
using Mmu.Wb.PasswordBuddy.DataAccess.Repositories.Base;
using Mmu.Wb.PasswordBuddy.Domain.Data.Repositories;
using Mmu.Wb.PasswordBuddy.Domain.Models;

namespace Mmu.Wb.PasswordBuddy.DataAccess.Repositories
{
    public class SystemRepository : RepositoryBase<Domain.Models.System, SystemDataModel>, ISystemRepository
    {
        public SystemRepository(IDataModelRepository<SystemDataModel> dataModelRepository, IDataModelAdapter<SystemDataModel, Domain.Models.System> dataModelAdapter) : base(dataModelRepository, dataModelAdapter)
        {
        }
    }
}