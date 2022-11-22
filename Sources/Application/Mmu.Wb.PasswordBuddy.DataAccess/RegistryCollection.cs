using System.IO.Abstractions;
using JetBrains.Annotations;
using Lamar;
using Microsoft.Extensions.DependencyInjection;
using Mmu.Wb.PasswordBuddy.DataAccess.DataModeling.DataModelAdapters.Base;
using Mmu.Wb.PasswordBuddy.DataAccess.DataModeling.DataModelRepositories.Services;
using Mmu.Wb.PasswordBuddy.DataAccess.DataModeling.DataModelRepositories.Services.Implementation;
using Mmu.Wb.PasswordBuddy.DataAccess.DataModeling.DataModelRepositories.Services.Servants;
using Mmu.Wb.PasswordBuddy.DataAccess.DataModeling.DataModelRepositories.Services.Servants.Implementation;

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
                    scanner.WithDefaultConventions(ServiceLifetime.Singleton);
                });

            For(typeof(IDataModelRepository<>)).Use(typeof(DataModelRepository<>));
            For(typeof(IDataModelFileAdapter<>)).Use(typeof(DataModelFileAdapter<>));
            For(typeof(IDirectoryProxy<>)).Use(typeof(DirectoryProxy<>));
            For(typeof(IFileSystemProxy<>)).Use(typeof(FileSystemProxy<>));

            For<IFileSystem>().Use<FileSystem>().Singleton();
        }
    }
}