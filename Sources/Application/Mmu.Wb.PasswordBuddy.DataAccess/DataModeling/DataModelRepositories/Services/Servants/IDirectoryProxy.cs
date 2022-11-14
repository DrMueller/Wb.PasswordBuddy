namespace Mmu.Wb.PasswordBuddy.DataAccess.DataModeling.DataModelRepositories.Services.Servants
{
    // ReSharper disable once UnusedTypeParameter
    internal interface IDirectoryProxy<T>
    {
        string GetDirectoryPathAndAssureExists();
    }
}