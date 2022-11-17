namespace Mmu.Wb.PasswordBuddy.DataAccess.DataModeling.DataModelRepositories.Services.Servants
{
    // ReSharper disable once UnusedTypeParameter
    public interface IDirectoryProxy<T>
    {
        string GetDirectoryPathAndAssureExists();
    }
}