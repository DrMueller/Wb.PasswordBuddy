namespace Mmu.Wb.PasswordBuddy.CrossCutting.DeepCopying
{
    public static class DeepCopyExtensions
    {
        public static T DeepCopy<T>(this T toCopy)
        {
            return DeepCopyService.DeepCopy(toCopy);
        }

        public static IReadOnlyCollection<T> DeepCopyCollection<T>(this IEnumerable<T> toCopy)
        {
            return toCopy.Select(f => f.DeepCopy()).ToList();
        }
    }
}