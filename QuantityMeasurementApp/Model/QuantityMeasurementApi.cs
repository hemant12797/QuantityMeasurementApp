using System;

namespace QuantityMeasurementApp.Model
{
    /// <summary>
    /// Simple API/demo wrapper for conversion and equality.
    /// Demonstrates method overloading for conversion use-cases.
    /// </summary>
    public static class QuantityMeasurementApi
    {
        // Overload 1: raw numeric value conversion
        public static void DemonstrateLengthConversion(double value, LengthUnit fromUnit, LengthUnit toUnit)
        {
            double result = QuantityLength.Convert(value, fromUnit, toUnit);
            Console.WriteLine($"convert({value}, {fromUnit}, {toUnit}) -> {result}");
        }

        // Overload 2: existing QuantityLength conversion
        public static void DemonstrateLengthConversion(QuantityLength quantity, LengthUnit toUnit)
        {
            QuantityLength converted = quantity.ConvertTo(toUnit);
            Console.WriteLine($"{quantity} -> {converted}");
        }

        public static void DemonstrateLengthEquality(QuantityLength a, QuantityLength b)
        {
            Console.WriteLine($"{a} == {b} -> {a.Equals(b)}");
        }
    }
}