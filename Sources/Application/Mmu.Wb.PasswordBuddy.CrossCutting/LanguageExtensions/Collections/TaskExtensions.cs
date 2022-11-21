namespace Mmu.Wb.PasswordBuddy.CrossCutting.LanguageExtensions.Collections
{
    public static class TaskExtensions
    {
        public static async Task<TResult> Select2Async<T, TResult>(
            this Task<T> task,
            Func<T, TResult> selector)
        {
            var data = await task;

            return selector(data);
        }
    }
}