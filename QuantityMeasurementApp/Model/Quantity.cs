using System;

namespace QuantityMeasurementApp.Model
{
    public sealed class Quantity<U> where U : class, IMeasurable
    {
        private readonly double value;
        private readonly U unit;

        // Use slightly looser epsilon to survive rounded factors (like pound conversions)
        private const double EPSILON = 1e-4;

        public double Value => value;
        public U Unit => unit;

        public Quantity(double value, U unit)
        {
            if (unit == null)
                throw new ArgumentException("Unit cannot be null.");

            if (double.IsNaN(value) || double.IsInfinity(value))
                throw new ArgumentException("Value must be finite.");

            this.value = value;
            this.unit = unit;
        }

        // UC5 Conversion
        public Quantity<U> ConvertTo(U targetUnit)
        {
            if (targetUnit == null)
                throw new ArgumentException("Target unit cannot be null.");

            if (targetUnit.Category != unit.Category)
                throw new ArgumentException("Cannot convert between different categories.");

            double baseValue = unit.ToBase(value);
            double converted = targetUnit.FromBase(baseValue);

            return new Quantity<U>(converted, targetUnit);
        }

        // UC6 Add (implicit: first unit)
        public Quantity<U> Add(Quantity<U> other)
        {
            return Add(other, this.unit);
        }

        // UC7 Add (explicit target)
        public Quantity<U> Add(Quantity<U> other, U targetUnit)
        {
            if (other == null)
                throw new ArgumentException("Other quantity cannot be null.");

            if (targetUnit == null)
                throw new ArgumentException("Target unit cannot be null.");

            if (other.unit.Category != unit.Category || targetUnit.Category != unit.Category)
                throw new ArgumentException("Cannot add different categories.");

            double aBase = unit.ToBase(value);
            double bBase = other.unit.ToBase(other.value);
            double sumBase = aBase + bBase;

            double result = targetUnit.FromBase(sumBase);
            return new Quantity<U>(result, targetUnit);
        }

        public override bool Equals(object obj)
        {
            if (this == obj)
                return true;

            if (obj == null || obj.GetType() != GetType())
                return false;

            var other = (Quantity<U>)obj;

            // Category safety (extra runtime defense)
            if (this.unit.Category != other.unit.Category)
                return false;

            double aBase = this.unit.ToBase(this.value);
            double bBase = other.unit.ToBase(other.value);

            return Math.Abs(aBase - bBase) < EPSILON;
        }

        public override int GetHashCode()
        {
            double baseValue = unit.ToBase(value);
            return HashCode.Combine(unit.Category, baseValue);
        }

        public override string ToString()
        {
            return $"Quantity({value}, {unit.UnitName})";
        }
    }
}