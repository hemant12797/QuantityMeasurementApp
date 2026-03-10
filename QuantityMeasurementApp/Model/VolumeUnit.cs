using System;

namespace QuantityMeasurementApp.Model
{
    public sealed class VolumeUnit : IMeasurable
    {
        private VolumeUnit(string name, double factor)
        {
            UnitName = name;
            ConversionFactor = factor;
        }

        public string UnitName { get; }
        public string Category => "VOLUME";
        public double ConversionFactor { get; }

        public double ToBase(double value) => value * ConversionFactor;

        public double FromBase(double baseValue) => baseValue / ConversionFactor;

        public static readonly VolumeUnit LITRE = new VolumeUnit("LITRE", 1.0);
        public static readonly VolumeUnit MILLILITRE = new VolumeUnit("MILLILITRE", 0.001);
        public static readonly VolumeUnit GALLON = new VolumeUnit("GALLON", 3.78541);

        public override string ToString() => UnitName;
    }
}