using System;
namespace QuantityMeasurementApp.Model
{
    public enum LengthUnit
    {
        FEET,
        INCH
    }

    public static class LengthUnitExtensions
    {
        public static double ToFeetFactor(this LengthUnit unit)
        {
            return unit switch
            {
                LengthUnit.FEET => 1.0,
                LengthUnit.INCH => 1.0 / 12.0,
                _ => throw new ArgumentException("Invalid unit")
            };
        }
    }
}