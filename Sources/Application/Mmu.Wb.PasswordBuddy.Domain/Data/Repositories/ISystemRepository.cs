namespace Mmu.Wb.PasswordBuddy.Domain.Data.Repositories
{
    public interface ISystemRepository
    {
        Task DeleteAsync(string systemId);
        Task<IReadOnlyCollection<Models.System>> LoadAllAsync();

        Task<Models.System> LoadAsync(string id);

        Task SaveAsync(Models.System system);
    }
}