using System.Collections.Generic;
using System.Linq;

namespace GiftBagOfBases.Models
{
    public abstract class ValueObject<T> where T : ValueObject<T>
    {
        public override bool Equals(object obj)
        {
            var valueObject = obj as T;
            return !(valueObject is null);
        }

        public override int GetHashCode()
        {
            return GetHashCodeCore()
                     .Select(x => x?.GetHashCode() ?? 0)
                     .Aggregate((x, y) => x ^ y);
        }

        protected abstract IEnumerable<object> GetHashCodeCore();

        public static bool operator ==(ValueObject<T> a, ValueObject<T> b)
        {
            if (a is null && b is null)
                return true;

            if (a is null || b is null)
                return false;

            return a.Equals(b);
        }

        public static bool operator !=(ValueObject<T> a, ValueObject<T> b)
        {
            return !(a == b);
        }
    }
}