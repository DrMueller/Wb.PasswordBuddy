using System.Linq.Expressions;
using Mmu.Wb.PasswordBuddy.DataAccess.DataModeling.DataModelRepositories.Services.Servants;
using Mmu.Wb.PasswordBuddy.DataAccess.DataModeling.DataModels.Base;

namespace Mmu.Wb.PasswordBuddy.DataAccess.DataModeling.DataModelRepositories.Services.Implementation
{
    public class DataModelRepository<T> : IDataModelRepository<T>
        where T : AggregateRootDataModel
    {
        private readonly IDataModelFileAdapter<T> _dataModelFileAdapter;
        private readonly IFileSystemProxy<T> _fileProxy;
        private readonly IIdSetter _idSetter;

        public DataModelRepository(
            IFileSystemProxy<T> fileSystemProxy,
            IDataModelFileAdapter<T> dataModelFileAdapter,
            IIdSetter idSetter)
        {
            _fileProxy = fileSystemProxy;
            _dataModelFileAdapter = dataModelFileAdapter;
            _idSetter = idSetter;
        }

        public Task DeleteAsync(string id)
        {
            _fileProxy.DeleteFile(id);

            return Task.CompletedTask;
        }

        public async Task<IReadOnlyCollection<T>> LoadAllAsync()
        {
            return await LoadAsync(f => true);
        }

        public async Task<T> LoadAsync(string id)
        {
            var items = await LoadAsync(f => f.Id == id);

            return items.Single();
        }

        public Task<T> SaveAsync(T aggregateRootDataModel)
        {
            _idSetter.SetIds(aggregateRootDataModel);
            var file = _dataModelFileAdapter.AdaptToFile(aggregateRootDataModel);
            _fileProxy.SaveFile(file);

            return Task.FromResult(aggregateRootDataModel);
        }

        private Task<IReadOnlyCollection<T>> LoadAsync(Expression<Func<T, bool>> predicate)
        {
            var compiledPredicate = predicate.Compile();

            var files = _fileProxy.LoadAllFiles();
            var dataModels = files
                .Select(file => _dataModelFileAdapter.AdaptToDataModel(file))
                .Where(compiledPredicate)
                .ToList();

            return Task.FromResult<IReadOnlyCollection<T>>(dataModels);
        }
    }
}