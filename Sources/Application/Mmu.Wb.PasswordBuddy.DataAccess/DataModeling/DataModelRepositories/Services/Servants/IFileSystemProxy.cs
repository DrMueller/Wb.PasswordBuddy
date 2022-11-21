using Mmu.Wb.PasswordBuddy.DataAccess.DataModeling.DataModels.Base;
using File = Mmu.Wb.PasswordBuddy.DataAccess.DataModeling.DataModelRepositories.Models.File;

namespace Mmu.Wb.PasswordBuddy.DataAccess.DataModeling.DataModelRepositories.Services.Servants
{
    // ReSharper disable once UnusedTypeParameter
    public interface IFileSystemProxy<T>
        where T : AggregateRootDataModel
    {
        void DeleteFile(string id);

        IReadOnlyCollection<File> LoadAllFiles();

        void SaveFile(File file);
    }
}