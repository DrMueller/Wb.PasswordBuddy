using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Mmu.Mlh.LanguageExtensions.Areas.Tasks;
using Mmu.Wb.PasswordBuddy.Domain.Data.Repositories;
using Mmu.Wb.PasswordBuddy.WpfUI.Areas.Systems.Overview.ViewData;

namespace Mmu.Wb.PasswordBuddy.WpfUI.Areas.Systems.Overview.ViewServices.Implementation
{
    public class SystemOverviewService : ISystemOverviewService
    {
        private readonly ISystemRepository _systemRepo;

        public SystemOverviewService(ISystemRepository systemRepo)
        {
            _systemRepo = systemRepo;
        }

        public async Task<ObservableCollection<SystemOverviewEntryViewData>> LoadOverviewAsync()
        {
            var entries = await _systemRepo
                .LoadAllAsync()
                .SelectAsync(f => new SystemOverviewEntryViewData(f.Id, f.Name));

            return new ObservableCollection<SystemOverviewEntryViewData>(entries);
        }
    }
}