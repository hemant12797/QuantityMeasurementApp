using System;

namespace QuantityMeasurementApp.Model
{
    public class QuantityLength
    {
        private readonly double value;
        private readonly LengthUnit unit;

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

            return this.ToFeet().CompareTo(other.ToFeet()) == 0;
        }

        public override int GetHashCode()
        {
            return ToFeet().GetHashCode();
        }
    }
}