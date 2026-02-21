using System;

namespace QuantityMeasurementApp.FeetApp
{
    public class FeetApp1
    {
        private readonly double Feet;

        public FeetApp1(double value)
        {
            this.Feet = value;
        }

        // Check reference equality
        public void Reference(object obj)
        {
            if (this == obj)
                Console.WriteLine("Same reference");
            else
                Console.WriteLine("Different reference");
        }

        // Check null and type
        public void NullCheck(object obj)
        {
            if (obj == null)
            {
                Console.WriteLine("Object is null");
                return;
            }

            if (this.GetType() != obj.GetType())
            {
                Console.WriteLine("Different type");
                return;
            }

            Console.WriteLine("Object is valid and same type");
        }

        // Safe casting
        public void Cast(object obj)
        {
            FeetApp1? other = obj as FeetApp1;

            if (other != null)
                Console.WriteLine("Object casted successfully");
            else
                Console.WriteLine("Casting failed");
        }

        // Compare values
        public void Compare(object obj)
        {
            FeetApp1? other = obj as FeetApp1;

            if (other == null)
            {
                Console.WriteLine("Invalid object");
                return;
            }

            if (this.Feet.CompareTo(other.Feet) == 0)
                Console.WriteLine("Values are equal");
            else
                Console.WriteLine("Values are NOT equal");
        }
    }
}