using System;

namespace QuantityMeasurementApp.Model
{
    public class QuantityLength
    {
        private readonly double value;
        private readonly LengthUnit unit;

        private const double EPSILON = 1e-6;

        public QuantityLength(double value, LengthUnit unit)
        {
            if (double.IsNaN(value) || double.IsInfinity(value))
                throw new ArgumentException("Value must be finite.");

            this.value = value;
            this.unit = unit;
        }

        public static double Convert(double value, LengthUnit sourceUnit, LengthUnit targetUnit)
        {
            if (double.IsNaN(value) || double.IsInfinity(value))
                throw new ArgumentException("Value must be finite.");

            double inFeet = value * sourceUnit.ToFeetFactor();
            return inFeet / targetUnit.ToFeetFactor();
        }

        public QuantityLength ConvertTo(LengthUnit targetUnit)
        {
            double converted = Convert(this.value, this.unit, targetUnit);
            return new QuantityLength(converted, targetUnit);
        }

        public override bool Equals(object obj)
        {
            if (this == obj)
                return true;

            if (obj == null || GetType() != obj.GetType())
                return false;

            QuantityLength other = (QuantityLength)obj;

            double a = this.value * this.unit.ToFeetFactor();
            double b = other.value * other.unit.ToFeetFactor();

            return Math.Abs(a - b) < EPSILON;
        }

        public override int GetHashCode()
        {
            double baseFeet = this.value * this.unit.ToFeetFactor();
            return baseFeet.GetHashCode();
        }

        public override string ToString()
        {
            return $"Quantity({value}, {unit})";
        }
    }
}