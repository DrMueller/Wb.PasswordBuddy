using Mmu.Mlh.LanguageExtensions.Areas.Invariance;

namespace Mmu.Wb.PasswordBuddy.WpfUI.Areas.Overview.ViewData
{
    public class SystemOverviewEntryViewData
    {
        public string SystemName { get; }
        public string SystemId { get; }

        public SystemOverviewEntryViewData(string systemId, string systemName)
        {
            Guard.StringNotNullOrEmpty(() => systemName);
            Guard.StringNotNullOrEmpty(() => systemId);
            SystemName = systemName;
            SystemId = systemId;
        }
    }
}
