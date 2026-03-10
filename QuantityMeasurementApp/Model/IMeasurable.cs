#nullable enable
using System;

namespace QuantityMeasurementApp.Model
{
    public interface IMeasurable
    {
        string UnitName { get; }
        string Category { get; }

        // Required for linear units
        double ConversionFactor { get; }

        double ToBase(double value);
        double FromBase(double baseValue);

        // UC14 default arithmetic support (allowed by default)
        bool SupportsArithmetic() => true;

        void ValidateOperationSupport(string operation)
        {
            // Default: do nothing (arithmetic allowed)
        }
    }
}