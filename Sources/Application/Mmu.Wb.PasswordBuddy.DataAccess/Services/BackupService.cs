using System.IO.Abstractions;
using Mmu.Mlh.LanguageExtensions.Areas.Assemblies.Extensions;
using Mmu.Wb.PasswordBuddy.DataAccess.DataModeling.DataModelRepositories.Services.Servants.Implementation;
using Mmu.Wb.PasswordBuddy.DataAccess.DataModeling.DataModels;
using Mmu.Wb.PasswordBuddy.Domain.Services;

namespace Mmu.Wb.PasswordBuddy.DataAccess.Services
{
    public class BackupService : IBackupService
    {
        private readonly IFileSystem _fileSystem;

        public BackupService(IFileSystem fileSystem)
        {
            _fileSystem = fileSystem;
        }

        public Task<string> BackupAsync()
        {
            var basePath = typeof(DirectoryProxy<>).Assembly.GetBasePath();
            var systemPath = _fileSystem.Path.Combine(basePath, nameof(SystemDataModel));
            var backupPath = _fileSystem.Path.Combine(basePath, "Backup", $"{DateTime.Now:yyyy-MM-dd_HH-mm-ss}");

            Copy(systemPath, backupPath);

            return Task.FromResult(backupPath);
        }

        private void Copy(string sourceDir, string targetDir)
        {
            _fileSystem.Directory.CreateDirectory(targetDir);

            foreach (var file in Directory.GetFiles(sourceDir))
            {
                File.Copy(file, Path.Combine(targetDir, Path.GetFileName(file)));
            }

            foreach (var directory in Directory.GetDirectories(sourceDir))
            {
                Copy(directory, Path.Combine(targetDir, Path.GetFileName(directory)));
            }
        }
    }
}