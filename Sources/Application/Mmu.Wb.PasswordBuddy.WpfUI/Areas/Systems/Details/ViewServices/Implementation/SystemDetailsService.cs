using System.Collections.Generic;
using System.Threading.Tasks;
using Mmu.Mlh.WpfCoreExtensions.Areas.MvvmShell.ViewModels.Services;
using Mmu.Wb.PasswordBuddy.Domain.Data.Repositories;
using Mmu.Wb.PasswordBuddy.Domain.Models;
using Mmu.Wb.PasswordBuddy.WpfUI.Areas.Systems.Details.ViewData;

namespace Mmu.Wb.PasswordBuddy.WpfUI.Areas.Systems.Details.ViewServices.Implementation
{
    public class SystemDetailsService : ISystemDetailsService
    {
        private readonly ISystemRepository _systemRepo;
        private readonly IViewModelFactory _vmFactory;

        public SystemDetailsService(
            IViewModelFactory vmFactory,
            ISystemRepository systemRepo)
        {
            _vmFactory = vmFactory;
            _systemRepo = systemRepo;
        }

        public async Task<SystemDetailsViewData> LoadAsync(string? id)
        {
            var vm = await _vmFactory.CreateAsync<SystemDetailsViewData>();

            if (string.IsNullOrEmpty(id))
            {
                return vm;
            }

            var system = await _systemRepo.LoadAsync(id);

            vm.SystemId = system.Id;
            vm.SystemName = system.Name;
            vm.AdditionalData = system.AdditionalData;

            return vm;
        }

        public async Task SaveAsync(SystemDetailsViewData data)
        {
            var system = new Domain.Models.System(
                data.SystemId,
                data.SystemName,
                new Domain.Models.Credentials(new List<Credential>()),
                data.AdditionalData
            );

            await _systemRepo.SaveAsync(system);
        }
    }
}