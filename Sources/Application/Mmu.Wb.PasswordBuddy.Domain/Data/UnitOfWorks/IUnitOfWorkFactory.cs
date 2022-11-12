namespace Mmu.Wb.PasswordBuddy.Domain.Data.UnitOfWorks
{
    public interface IUnitOfWorkFactory
    {
        IUnitOfWork Create();
    }
}