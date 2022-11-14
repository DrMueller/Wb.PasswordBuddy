﻿using Mmu.Mlh.LanguageExtensions.Areas.Assemblies.Extensions;
using System.IO.Abstractions;

namespace Mmu.Wb.PasswordBuddy.DataAccess.DataModeling.DataModelRepositories.Services.Servants.Implementation
{
    internal class DirectoryProxy<T> : IDirectoryProxy<T>
    {
        private readonly IFileSystem _fileSystem;

        public DirectoryProxy(
            IFileSystem fileSystem)
        {
            _fileSystem = fileSystem;
        }

        public string GetDirectoryPathAndAssureExists()
        {
            var basePath = typeof(DirectoryProxy<>).Assembly.GetBasePath();
            var subPath = _fileSystem.Path.Combine(basePath, typeof(T).Name);

            if (!_fileSystem.Directory.Exists(subPath))
            {
                _fileSystem.Directory.CreateDirectory(subPath);
            }

            return subPath;
        }
    }
}