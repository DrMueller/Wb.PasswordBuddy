namespace Mmu.Wb.PasswordBuddy.Domain.Services
{
    public interface IBackupService
    {
        Task<string> BackupAsync();
    }
}