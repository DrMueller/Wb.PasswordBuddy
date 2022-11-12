using System.Diagnostics.CodeAnalysis;

namespace Mmu.Wb.PasswordBuddy.Domain.Models.Base
{
    [SuppressMessage("Design", "CA1040:Avoid empty interfaces", Justification = "Marker interface")]
    public interface IAggregateRoot
    {
    }
}