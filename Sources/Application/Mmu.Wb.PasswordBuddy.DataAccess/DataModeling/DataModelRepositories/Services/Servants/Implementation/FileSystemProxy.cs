using System.IO.Abstractions;
using Mmu.Wb.PasswordBuddy.DataAccess.DataModeling.DataModels.Base;
using File = Mmu.Wb.PasswordBuddy.DataAccess.DataModeling.DataModelRepositories.Models.File;

namespace Mmu.Wb.PasswordBuddy.DataAccess.DataModeling.DataModelRepositories.Services.Servants.Implementation
{
    public class FileSystemProxy<T> : IFileSystemProxy<T>
        where T : AggregateRootDataModel
    {
        private const string FileExtension = ".json";
        private readonly IDirectoryProxy<T> _directoryProxy;
        private readonly IFileSystem _fileSystem;

        public FileSystemProxy(IFileSystem fileSystem, IDirectoryProxy<T> directoryProxy)
        {
            _fileSystem = fileSystem;
            _directoryProxy = directoryProxy;
        }

        public void DeleteFile(string id)
        {
            var filePath = CreateFilePath(id);
            _fileSystem.File.Delete(filePath);
        }

        public IReadOnlyCollection<File> LoadAllFiles()
        {
            var files = EnumerateFilesInDefinedPath().Select(
                filePath =>
                {
                    var fileName = _fileSystem.Path.GetFileName(filePath);
                    var fileContent = _fileSystem.File.ReadAllText(filePath);

                    return new File(fileName, fileContent);
                });

            return files.ToList();
        }

        public void SaveFile(File file)
        {
            var filePath = CreateFilePath(file.FileName);

            if (!_fileSystem.File.Exists(filePath))
            {
                _fileSystem.File.Create(filePath).Dispose();
            }

            _fileSystem.File.WriteAllText(filePath, file.Content);
        }

        private string CreateFilePath(string fileName)
        {
            var directoryPath = _directoryProxy.GetDirectoryPathAndAssureExists();
            var filePath = _fileSystem.Path.Combine(directoryPath, fileName);
            filePath = _fileSystem.Path.ChangeExtension(filePath, FileExtension);

            return filePath;
        }

        private IEnumerable<string> EnumerateFilesInDefinedPath()
        {
            var directoryPath = _directoryProxy.GetDirectoryPathAndAssureExists();

            return _fileSystem.Directory.EnumerateFiles(directoryPath);
        }
    }
}