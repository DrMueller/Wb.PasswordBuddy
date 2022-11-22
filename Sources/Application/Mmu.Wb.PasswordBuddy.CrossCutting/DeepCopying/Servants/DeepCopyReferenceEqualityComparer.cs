namespace Mmu.Wb.PasswordBuddy.CrossCutting.DeepCopying.Servants
{
    internal class DeepCopyReferenceEqualityComparer : EqualityComparer<object>
    {
        public override bool Equals(object? x, object? y)
        {
            return ReferenceEquals(x, y);
        }

        public override int GetHashCode(object obj)
        {
            return obj.GetHashCode();
        }
    }
}