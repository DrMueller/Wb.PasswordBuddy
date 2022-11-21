using Mmu.Mlh.LanguageExtensions.Areas.Invariance;

namespace Mmu.Wb.PasswordBuddy.WpfUI.Areas.Overview.ViewData
{
    public class SystemOverviewEntryViewData
    {
        public SystemOverviewEntryViewData(string systemId, string systemName)
        {
            Guard.StringNotNullOrEmpty(() => systemName);
            Guard.StringNotNullOrEmpty(() => systemId);
            SystemName = systemName;
            SystemId = systemId;
        }

        public string SystemId { get; }
        public string SystemName { get; }
    }
}