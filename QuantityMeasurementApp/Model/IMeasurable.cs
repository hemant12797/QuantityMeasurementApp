using System;

namespace QuantityMeasurementApp.Model
{
    public interface IMeasurable
    {
        string UnitName { get; }
        string Category { get; }          // "Length", "Weight", etc.
        double ToBase(double value);      // convert to base unit (feet/kg)
        double FromBase(double baseValue);// convert from base unit
    }
}