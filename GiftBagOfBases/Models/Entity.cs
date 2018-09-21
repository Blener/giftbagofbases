using System;

namespace GiftBagOfBases.Models
{
    public abstract class Entity
    {
        public int IncrementId { get; protected set; }

        public Guid Id { get; protected set; }

        public override bool Equals(object obj)
        {
            var compareTo = obj as Entity;

            if (ReferenceEquals(this, compareTo)) return true;
            if (compareTo is null) return false;

            return IncrementId.Equals(compareTo.IncrementId);
        }

        public static bool operator ==(Entity a, Entity b)
        {
            if (a is null && b is null)
                return true;

            if (a is null || b is null)
                return false;

            return a.Equals(b);
        }

        public static bool operator !=(Entity a, Entity b)
        {
            return !(a == b);
        }

        public override int GetHashCode()
        {
            return (GetType().GetHashCode() * 834) + IncrementId.GetHashCode();
        }

        public override string ToString()
        {
            return GetType().Name + " [Id=" + IncrementId + "]";
        }
    }
}