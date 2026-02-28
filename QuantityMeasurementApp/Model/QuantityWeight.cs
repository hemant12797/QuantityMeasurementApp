using System;

namespace QuantityMeasurementApp.Model
{
    public class QuantityWeight
    {
        private readonly double value;
        private readonly WeightUnit unit;

        private const double EPSILON = 1e-4;

        public double Value => value;
        public WeightUnit Unit => unit;

        public QuantityWeight(double value, WeightUnit unit)
        {
            if (unit == null)
                throw new ArgumentException("Unit cannot be null.");

            if (double.IsNaN(value) || double.IsInfinity(value))
                throw new ArgumentException("Value must be finite.");

            this.value = value;
            this.unit = unit;
        }

        // ===============================
        // Conversion
        // ===============================

        public QuantityWeight ConvertTo(WeightUnit targetUnit)
        {
            if (targetUnit == null)
                throw new ArgumentException("Target unit cannot be null.");

            double baseValue = unit.ConvertToBaseUnit(value);
            double converted = targetUnit.ConvertFromBaseUnit(baseValue);

            return new QuantityWeight(converted, targetUnit);
        }

        // ===============================
        // Addition (Implicit Target)
        // ===============================

        public static QuantityWeight Add(QuantityWeight first, QuantityWeight second)
        {
            return Add(first, second, first.unit);
        }

        // ===============================
        // Addition (Explicit Target)
        // ===============================

        public static QuantityWeight Add(QuantityWeight first,
                                         QuantityWeight second,
                                         WeightUnit targetUnit)
        {
            if (first == null || second == null)
                throw new ArgumentException("Operands cannot be null.");

            if (targetUnit == null)
                throw new ArgumentException("Target unit cannot be null.");

            double firstBase = first.unit.ConvertToBaseUnit(first.value);
            double secondBase = second.unit.ConvertToBaseUnit(second.value);

            double sumBase = firstBase + secondBase;

            double resultValue = targetUnit.ConvertFromBaseUnit(sumBase);

            return new QuantityWeight(resultValue, targetUnit);
        }

        // ===============================
        // Equality
        // ===============================

        public override bool Equals(object obj)
        {
            if (this == obj)
                return true;

            if (obj == null || GetType() != obj.GetType())
                return false;

            QuantityWeight other = (QuantityWeight)obj;

            double a = this.unit.ConvertToBaseUnit(this.value);
            double b = other.unit.ConvertToBaseUnit(other.value);

            return Math.Abs(a - b) < EPSILON;
        }

        public override int GetHashCode()
        {
            double baseValue = unit.ConvertToBaseUnit(value);
            return baseValue.GetHashCode();
        }

        public override string ToString()
        {
            return $"Quantity({value}, {unit})";
        }
    }
}