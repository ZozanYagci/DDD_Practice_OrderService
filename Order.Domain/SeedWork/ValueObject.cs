using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Order.Domain.SeedWork
{
    // ValueObject kimlik içermez.
    // Immutable
    public abstract class ValueObject
    {
        // değer karşılaştırması
        protected static bool EqualOperator(ValueObject left, ValueObject right)
        {
            if (ReferenceEquals(left, null) ^ ReferenceEquals(right, null))
            {
                return false;
            }
            return ReferenceEquals(left, null) || left.Equals(right);
        }

        protected static bool NotEqualOperator(ValueObject left, ValueObject right)
        {
            return !EqualOperator(left, right);
        }

        protected abstract IEnumerable<object> GetEqualityComponents();

        public override bool Equals(object obj)
        {
            if (obj == null || obj.GetType() != GetType())
            {
                return false;
            }

            var other = (ValueObject)obj;
            return GetEqualityComponents().SequenceEqual(other.GetEqualityComponents());
        }

        // hash code'unun generate edilip edilmediğini kontrol eden metot
        public override int GetHashCode()
        {
            return GetEqualityComponents()
                 .Select(x => x != null ? x.GetHashCode() : 0)
                 .Aggregate((x, y) => x ^ y);
        }

        // value object'in bir kopyası oluşturulacaksa
        public ValueObject GetCopy()
        {
            return MemberwiseClone() as ValueObject;
        }

    }
}
