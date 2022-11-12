namespace Mmu.Wb.PasswordBuddy.CrossCutting.LanguageExtensions.Collections
{
    public static class TaskExtensions
    {
        public static async Task<IReadOnlyCollection<TResult>> SelectAsync<T, TResult>(
            this Task<IReadOnlyCollection<T>> task,
            Func<T, TResult> selector)
        {
            var data = await task;
            return data
                .Select(selector)
                .ToList();
        }
    }
}