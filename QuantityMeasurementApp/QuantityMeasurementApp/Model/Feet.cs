using System;

namespace QuantityMeasurementApp.Model
{
    public class Feet
    {
        private readonly double value;

        public Feet(double value)
        {
            if (double.IsNaN(value) || double.IsInfinity(value))
                throw new ArgumentException("Invalid numeric value.");

            this.value = value;
        }

        public bool Reference(object obj)
        {
            return this == obj;
        }

        public bool NullOrType(object obj)
        {
            return obj == null || GetType() != obj.GetType();
        }

        public bool Cast(object obj)
        {
            Feet other = obj as Feet;
            return other != null;
        }

        public bool Compare(object obj)
        {
            Feet other = obj as Feet;

            if (other == null)
                return false;

            return this.value.CompareTo(other.value) == 0;
        }

    }
}
