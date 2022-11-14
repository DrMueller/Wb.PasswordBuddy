using Mmu.Mlh.DataAccess.Areas.DataModeling.Models;

namespace Mmu.Wb.PasswordBuddy.DataAccess.DataModeling.DataModelRepositories.Services.Servants
{
    // ReSharper disable once UnusedTypeParameter
    public interface IFileSystemProxy<T>
        where T : AggregateRootDataModel
    {
        void DeleteFile(string id);

        IReadOnlyCollection<Models.File> LoadAllFiles();

        void SaveFile(Models.File file);
    }
}