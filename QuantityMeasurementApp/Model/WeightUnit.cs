using System;

namespace QuantityMeasurementApp.Model
{
    public sealed class WeightUnit : IMeasurable
    {
        // base: KILOGRAM
        private readonly double toKgFactor;

        public string UnitName { get; }
        public string Category => "Weight";

        private WeightUnit(string name, double toKgFactor)
        {
            UnitName = name;
            this.toKgFactor = toKgFactor;
        }

        public double ToBase(double value)
        {
            if (double.IsNaN(value) || double.IsInfinity(value))
                throw new ArgumentException("Value must be finite.");
            return value * toKgFactor;
        }

        public double FromBase(double baseValue)
        {
            if (double.IsNaN(baseValue) || double.IsInfinity(baseValue))
                throw new ArgumentException("Value must be finite.");
            return baseValue / toKgFactor;
        }

        public override string ToString() => UnitName;

        // Static instances
        public static readonly WeightUnit KILOGRAM = new WeightUnit("KILOGRAM", 1.0);
        public static readonly WeightUnit GRAM = new WeightUnit("GRAM", 0.001);       // 1 g = 0.001 kg
        public static readonly WeightUnit POUND = new WeightUnit("POUND", 0.453592);  // 1 lb = 0.453592 kg
    }
}