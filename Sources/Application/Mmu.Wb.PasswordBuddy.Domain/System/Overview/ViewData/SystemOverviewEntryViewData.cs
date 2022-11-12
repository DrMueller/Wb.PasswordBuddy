using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mmu.Mlh.LanguageExtensions.Areas.Invariance;

namespace Mmu.Wb.PasswordBuddy.WpfUI.Areas.System.Overview.ViewData
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
