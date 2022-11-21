namespace Mmu.Wb.PasswordBuddy.Domain.Services
{
    public interface ICredentialsService
    {
        Task DeleteCredentials(string systemId, string credentialsId);
    }
}