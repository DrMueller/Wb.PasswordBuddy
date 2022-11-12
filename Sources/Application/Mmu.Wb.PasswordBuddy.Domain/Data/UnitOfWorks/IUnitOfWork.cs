using Mmu.Wb.PasswordBuddy.Domain.Data.Repositories.Base;

namespace Mmu.Wb.PasswordBuddy.Domain.Data.UnitOfWorks
{
    public interface IUnitOfWork : IDisposable
    {
        TRepo GetRepository<TRepo>()
            where TRepo : IRepository;

        Task SaveAsync();
    }
}