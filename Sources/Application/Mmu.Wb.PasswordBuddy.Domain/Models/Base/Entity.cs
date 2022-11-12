using JetBrains.Annotations;

namespace Mmu.Wb.PasswordBuddy.Domain.Models.Base
{
    [PublicAPI]
    public abstract class Entity
    {
        public string Id { get; protected set; }

        public override bool Equals(object? obj)
        {
            if (obj is not Entity compareTo)
            {
                return false;
            }

            if (ReferenceEquals(this, compareTo))
            {
                return true;
            }

            if (GetType() != compareTo.GetType())
            {
                return false;
            }

            return Id.Equals(compareTo.Id);
        }

        public override int GetHashCode()
        {
            return (GetType() + Id.ToString()).GetHashCode(StringComparison.InvariantCulture);
        }

        public static bool operator ==(Entity? a, Entity? b)
        {
            if (ReferenceEquals(a, null) && ReferenceEquals(b, null))
            {
                return true;
            }

            if (ReferenceEquals(a, null) || ReferenceEquals(b, null))
            {
                return false;
            }

            return a.Equals(b);
        }

        public static bool operator !=(Entity a, Entity b)
        {
            return !(a == b);
        }
    }
}