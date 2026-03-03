using System;

namespace QuantityMeasurementApp.Model
{
    public sealed class LengthUnit : IMeasurable
    {
        private LengthUnit(string name, double factor)
        {
            UnitName = name;
            ConversionFactor = factor;
        }

        public string UnitName { get; }
        public string Category => "LENGTH";
        public double ConversionFactor { get; }

        public double ToBase(double value) => value * ConversionFactor;

        public double FromBase(double baseValue) => baseValue / ConversionFactor;

        public static readonly LengthUnit FEET = new LengthUnit("FEET", 1.0);
        public static readonly LengthUnit INCH = new LengthUnit("INCH", 1.0 / 12.0);
        public static readonly LengthUnit YARD = new LengthUnit("YARD", 3.0);
        public static readonly LengthUnit CENTIMETER = new LengthUnit("CENTIMETER", 0.0328084);

        public override string ToString() => UnitName;
    }
}