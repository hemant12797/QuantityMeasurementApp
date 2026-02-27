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
        public static double ToFeetFactor(this LengthUnit unit)
        {
            return unit switch
            {
                LengthUnit.FEET => 1.0,

                // 1 inch = 1/12 feet
                LengthUnit.INCH => 1.0 / 12.0,

                // 1 yard = 3 feet
                LengthUnit.YARD => 3.0,

                // 1 cm = 0.393701 inch
                // Convert inch to feet => divide by 12
                LengthUnit.CENTIMETER => 0.393701 / 12.0,

                _ => throw new ArgumentException("Invalid unit")
            };
        }
    }
}