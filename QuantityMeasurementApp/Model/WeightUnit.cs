using System;

namespace QuantityMeasurementApp.Model
{
    public enum WeightUnit
    {
        KILOGRAM,
        GRAM,
        POUND
    }

    public static class WeightUnitExtensions
    {
        private const double EPSILON = 1e-6;

        // Base Unit = KILOGRAM

        public static double ConvertToBaseUnit(this WeightUnit unit, double value)
        {
            if (double.IsNaN(value) || double.IsInfinity(value))
                throw new ArgumentException("Value must be finite.");

            return unit switch
            {
                WeightUnit.KILOGRAM => value,
                WeightUnit.GRAM => value * 0.001,          // 1 g = 0.001 kg
                WeightUnit.POUND => value * 0.453592,     // 1 lb = 0.453592 kg
                _ => throw new ArgumentException("Invalid Weight Unit")
            };
        }

        public static double ConvertFromBaseUnit(this WeightUnit unit, double baseValue)
        {
            return unit switch
            {
                WeightUnit.KILOGRAM => baseValue,
                WeightUnit.GRAM => baseValue / 0.001,
                WeightUnit.POUND => baseValue / 0.453592,
                _ => throw new ArgumentException("Invalid Weight Unit")
            };
        }
    }
}