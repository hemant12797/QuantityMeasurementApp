using System;

namespace QuantityMeasurementApp.Model
{
    public enum LengthUnit
    {
        FEET,
        INCH,
        YARD,
        CENTIMETER
    }

    public static class LengthUnitExtensions
    {
        private const double EPSILON = 1e-6;

        // Base unit = FEET

        public static double ConvertToBaseUnit(this LengthUnit unit, double value)
        {
            if (double.IsNaN(value) || double.IsInfinity(value))
                throw new ArgumentException("Value must be finite.");

            return unit switch
            {
                LengthUnit.FEET => value,
                LengthUnit.INCH => value / 12.0,
                LengthUnit.YARD => value * 3.0,
                LengthUnit.CENTIMETER => value / 30.48,
                _ => throw new ArgumentException("Invalid unit")
            };
        }

        public static double ConvertFromBaseUnit(this LengthUnit unit, double baseValue)
        {
            return unit switch
            {
                LengthUnit.FEET => baseValue,
                LengthUnit.INCH => baseValue * 12.0,
                LengthUnit.YARD => baseValue / 3.0,
                LengthUnit.CENTIMETER => baseValue * 30.48,
                _ => throw new ArgumentException("Invalid unit")
            };
        }
    }
}