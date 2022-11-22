using JetBrains.Annotations;

namespace Mmu.Wb.PasswordBuddy.Domain.Models.Base
{
    [PublicAPI]
    public abstract class Entity
    {
        public string Id { get; protected set; } = "";

        public static bool operator ==(Entity? a, Entity? b)
        {
            if (a is null && b is null)
            {
                return true;
            }

            if (a is null || b is null)
            {
                return false;
            }

            return a.Equals(b);
        }

        public static bool operator !=(Entity? a, Entity? b)
        {
            return !(a == b);
        }

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
            return (GetType() + Id).GetHashCode(StringComparison.InvariantCulture);
        }
    }
}