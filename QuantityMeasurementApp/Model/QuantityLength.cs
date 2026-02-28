using System;

namespace QuantityMeasurementApp.Model
{
    public class QuantityLength
    {
        private readonly double value;
        private readonly LengthUnit unit;

        private const double EPSILON = 1e-6;

        public double Value => value;
        public LengthUnit Unit => unit;

        public QuantityLength(double value, LengthUnit unit)
        {
            if (double.IsNaN(value) || double.IsInfinity(value))
                throw new ArgumentException("Value must be finite.");

            this.value = value;
            this.unit = unit;
        }

        // =========================
        // UC5 - Conversion
        // =========================

        public static double Convert(double value, LengthUnit source, LengthUnit target)
        {
            double baseValue = source.ConvertToBaseUnit(value);
            return target.ConvertFromBaseUnit(baseValue);
        }

        public QuantityLength ConvertTo(LengthUnit targetUnit)
        {
            double baseValue = unit.ConvertToBaseUnit(value);
            double converted = targetUnit.ConvertFromBaseUnit(baseValue);
            return new QuantityLength(converted, targetUnit);
        }

        // =========================
        // UC6 - Addition (default)
        // =========================

        public static QuantityLength Add(QuantityLength first, QuantityLength second)
        {
            return Add(first, second, first.unit);
        }

        // =========================
        // UC7 - Addition (explicit target)
        // =========================

        public static QuantityLength Add(QuantityLength first,
                                         QuantityLength second,
                                         LengthUnit targetUnit)
        {
            if (first == null || second == null)
                throw new ArgumentException("Operands cannot be null.");

            double firstBase = first.unit.ConvertToBaseUnit(first.value);
            double secondBase = second.unit.ConvertToBaseUnit(second.value);

            double sumBase = firstBase + secondBase;

            double resultValue = targetUnit.ConvertFromBaseUnit(sumBase);

            return new QuantityLength(resultValue, targetUnit);
        }

        // =========================
        // Equality
        // =========================

        public override bool Equals(object obj)
        {
            if (this == obj)
                return true;

            if (obj == null || GetType() != obj.GetType())
                return false;

            QuantityLength other = (QuantityLength)obj;

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