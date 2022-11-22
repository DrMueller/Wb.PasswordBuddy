using Mmu.Mlh.LanguageExtensions.Areas.Functional;
using Mmu.Mlh.LanguageExtensions.Areas.Tasks;
using Mmu.Wb.PasswordBuddy.CrossCutting.LanguageExtensions.Collections;
using Mmu.Wb.PasswordBuddy.DataAccess.DataModeling.DataModelAdapters.Base;
using Mmu.Wb.PasswordBuddy.DataAccess.DataModeling.DataModelRepositories.Services;
using Mmu.Wb.PasswordBuddy.DataAccess.DataModeling.DataModels.Base;
using Mmu.Wb.PasswordBuddy.Domain.Models.Base;

namespace Mmu.Wb.PasswordBuddy.DataAccess.Repositories.Base
{
    public abstract class RepositoryBase<TAggregateRoot, TDataModel>
        where TAggregateRoot : AggregateRoot
        where TDataModel : AggregateRootDataModel
    {
        private readonly IDataModelAdapter<TDataModel, TAggregateRoot> _dataModelAdapter;
        private readonly IDataModelRepository<TDataModel> _dataModelRepository;

        protected RepositoryBase(
            IDataModelRepository<TDataModel> dataModelRepository,
            IDataModelAdapter<TDataModel, TAggregateRoot> dataModelAdapter)
        {
            _dataModelRepository = dataModelRepository;
            _dataModelAdapter = dataModelAdapter;
        }

        public async Task DeleteAsync(string id)
        {
            await _dataModelRepository.DeleteAsync(id);
        }

        public async Task<IReadOnlyCollection<TAggregateRoot>> LoadAllAsync()
        {
            return await
                _dataModelRepository.LoadAllAsync()
                    .SelectAsync(md => _dataModelAdapter.Adapt(md));
        }

        public async Task<TAggregateRoot> LoadAsync(string id)
        {
            var dmMaybe = await
                _dataModelRepository.LoadAsync(id).Select2Async(f => f);

            return dmMaybe.Map(dm => _dataModelAdapter.Adapt(dm));
        }

        public async Task SaveAsync(TAggregateRoot ag)
        {
            var dm = _dataModelAdapter.Adapt(ag);
            await _dataModelRepository.SaveAsync(dm);
        }
    }
}