using JetBrains.Annotations;

namespace Mmu.Wb.PasswordBuddy.DataAccess.DataModeling.DataModels.Base
{
    [PublicAPI]
    public abstract class EntityDataModel
    {
        public string DataModelTypeName => GetType().FullName!;
        public string Id { get; set; } = "";

        public static bool operator ==(EntityDataModel? a, EntityDataModel? b)
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

        public static bool operator !=(EntityDataModel a, EntityDataModel b)
        {
            return !(a == b);
        }

        public override bool Equals(object? obj)
        {
            if (obj is not EntityDataModel compareTo)
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
            // ReSharper disable once NonReadonlyMemberInGetHashCode
            return (GetType() + Id).GetHashCode();
        }
    }
}