using JetBrains.Annotations;
using Lamar;
using Mmu.Wb.PasswordBuddy.DataAccess.DataModeling.DataModelAdapters;
using Mmu.Wb.PasswordBuddy.DataAccess.DataModeling.DataModelRepositories.Services;
using Mmu.Wb.PasswordBuddy.DataAccess.DataModeling.DataModelRepositories.Services.Implementation;
using Mmu.Wb.PasswordBuddy.DataAccess.DataModeling.DataModelRepositories.Services.Servants;
using Mmu.Wb.PasswordBuddy.DataAccess.DataModeling.DataModelRepositories.Services.Servants.Implementation;
using System.IO.Abstractions;

namespace Mmu.Wb.PasswordBuddy.DataAccess
{
    [UsedImplicitly]
    public class RegistryCollection : ServiceRegistry
    {
        public RegistryCollection()
        {
            Scan(
                scanner =>
                {
                    scanner.AssemblyContainingType<RegistryCollection>();
                    scanner.AddAllTypesOf(typeof(IDataModelAdapter<,>));
                    scanner.WithDefaultConventions();
                });

            For(typeof(IDataModelRepository<>)).Use(typeof(DataModelRepository<>));
            For(typeof(IDataModelFileAdapter<>)).Use(typeof(DataModelFileAdapter<>));
            For(typeof(IDirectoryProxy<>)).Use(typeof(DirectoryProxy<>));
            For(typeof(IFileSystemProxy<>)).Use(typeof(FileSystemProxy<>));

            For<IFileSystem>().Use<FileSystem>().Singleton();
        }
    }
}