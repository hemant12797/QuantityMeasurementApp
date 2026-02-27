using System;

namespace QuantityMeasurementApp.Model
{
    public class QuantityLength
    {
        private readonly double value;
        private readonly LengthUnit unit;

        private const double TOLERANCE = 0.0001;

        public QuantityLength(double value, LengthUnit unit)
        {
            if (double.IsNaN(value) || double.IsInfinity(value))
                throw new ArgumentException("Invalid numeric value");

            this.value = value;
            this.unit = unit;
        }

        private double ToFeet()
        {
            return value * unit.ToFeetFactor();
        }

        public override bool Equals(object obj)
        {
            if (this == obj)
                return true;

            if (obj == null || GetType() != obj.GetType())
                return false;

            QuantityLength other = (QuantityLength)obj;

            return Math.Abs(this.ToFeet() - other.ToFeet()) < TOLERANCE;
        }

        public override int GetHashCode()
        {
            return ToFeet().GetHashCode();
        }
    }
}