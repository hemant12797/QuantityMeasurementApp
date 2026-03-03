using System;

namespace QuantityMeasurementApp.Model
{
    public sealed class WeightUnit : IMeasurable
    {
        private WeightUnit(string name, double factor)
        {
            UnitName = name;
            ConversionFactor = factor;
        }

        public string UnitName { get; }
        public string Category => "WEIGHT";
        public double ConversionFactor { get; }

        public double ToBase(double value) => value * ConversionFactor;

        public double FromBase(double baseValue) => baseValue / ConversionFactor;

        public static readonly WeightUnit KILOGRAM = new WeightUnit("KILOGRAM", 1.0);
        public static readonly WeightUnit GRAM = new WeightUnit("GRAM", 0.001);
        public static readonly WeightUnit POUND = new WeightUnit("POUND", 0.453592);

        public override string ToString() => UnitName;
    }
}