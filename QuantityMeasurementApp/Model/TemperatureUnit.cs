#nullable enable
using System;

namespace QuantityMeasurementApp.Model
{
    // Base unit: CELSIUS
    public sealed class TemperatureUnit : IMeasurable
    {
        private readonly Func<double, double> _toBase;     // -> Celsius
        private readonly Func<double, double> _fromBase;   // Celsius -> unit

        private TemperatureUnit(
            string unitName,
            Func<double, double> toBase,
            Func<double, double> fromBase)
        {
            UnitName = unitName;
            Category = "TEMPERATURE";
            ConversionFactor = 1.0; // not meaningful for temperature (non-linear)
            _toBase = toBase;
            _fromBase = fromBase;
        }

        public string UnitName { get; }
        public string Category { get; }
        public double ConversionFactor { get; }

        // ✅ Lambda conversion functions
        public double ToBase(double value) => _toBase(value);
        public double FromBase(double baseValue) => _fromBase(baseValue);

        // UC14: temperature does NOT support arithmetic
        public bool SupportsArithmetic() => false;

        public void ValidateOperationSupport(string operation)
        {
            // Block add/subtract/divide for temperature category (as per UC14 description)
            throw new UnsupportedOperationException(
                $"Temperature does not support arithmetic operation '{operation}'. " +
                "Only equality and conversion are supported.");
        }

        // ========= Units =========
        // Celsius is base (identity)
        public static readonly TemperatureUnit CELSIUS =
            new TemperatureUnit(
                "CELSIUS",
                c => c,
                c => c);

        // Fahrenheit <-> Celsius
        public static readonly TemperatureUnit FAHRENHEIT =
            new TemperatureUnit(
                "FAHRENHEIT",
                f => (f - 32.0) * (5.0 / 9.0),
                c => (c * (9.0 / 5.0)) + 32.0);

        // Kelvin <-> Celsius
        public static readonly TemperatureUnit KELVIN =
            new TemperatureUnit(
                "KELVIN",
                k => k - 273.15,
                c => c + 273.15);

        public override string ToString() => UnitName;
    }

    // Use .NET standard exception name (C# does not have Java's UnsupportedOperationException)
    public sealed class UnsupportedOperationException : InvalidOperationException
    {
        public UnsupportedOperationException(string message) : base(message) { }
    }
}