using System;

namespace QuantityMeasurementApp.Model
{
    public class Inches
    {
        private readonly double value;

        public Inches(double value)
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
            Inches other = obj as Inches;
            return other != null;
        }

        
        public bool Compare(object obj)
        {
            Inches other = obj as Inches;

            if (other == null)
                return false;

            return this.value.CompareTo(other.value) == 0;
        }
    }
}
