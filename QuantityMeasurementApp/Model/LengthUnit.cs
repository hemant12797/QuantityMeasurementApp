using System;

namespace QuantityMeasurementApp.Model
{
    public sealed class LengthUnit : IMeasurable
    {
        // base: FEET
        private readonly double toFeetFactor;

        public string UnitName { get; }
        public string Category => "Length";

        private LengthUnit(string name, double toFeetFactor)
        {
            UnitName = name;
            this.toFeetFactor = toFeetFactor;
        }

        public double ToBase(double value)
        {
            if (double.IsNaN(value) || double.IsInfinity(value))
                throw new ArgumentException("Value must be finite.");
            return value * toFeetFactor;
        }

        public double FromBase(double baseValue)
        {
            if (double.IsNaN(baseValue) || double.IsInfinity(baseValue))
                throw new ArgumentException("Value must be finite.");
            return baseValue / toFeetFactor;
        }

        public override string ToString() => UnitName;

        // Static instances (like enum constants)
        public static readonly LengthUnit FEET = new LengthUnit("FEET", 1.0);
        public static readonly LengthUnit INCH = new LengthUnit("INCH", 1.0 / 12.0);
        public static readonly LengthUnit YARD = new LengthUnit("YARD", 3.0);
        public static readonly LengthUnit CENTIMETER = new LengthUnit("CENTIMETER", 1.0 / 30.48);
    }
}