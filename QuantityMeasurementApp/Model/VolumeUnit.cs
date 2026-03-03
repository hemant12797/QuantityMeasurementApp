using System;

namespace QuantityMeasurementApp.Model
{
    public sealed class VolumeUnit : IMeasurable
    {
        private readonly string _unitName;
        private readonly string _category;
        private readonly double _factorToLitre;

        private VolumeUnit(string name, double factor)
        {
            _unitName = name;
            _category = "Volume";
            _factorToLitre = factor;
        }

        // Base Unit
        public static readonly VolumeUnit LITRE = new VolumeUnit("LITRE", 1.0);

        // 1 mL = 0.001 L
        public static readonly VolumeUnit MILLILITRE = new VolumeUnit("MILLILITRE", 0.001);

        // 1 gallon ≈ 3.78541 L
        public static readonly VolumeUnit GALLON = new VolumeUnit("GALLON", 3.78541);

        // ===== IMeasurable Implementation =====

        public string UnitName => _unitName;

        public string Category => _category;

        public double ToBase(double value)
        {
            // Convert this unit -> LITRE
            return value * _factorToLitre;
        }

        public double FromBase(double baseValue)
        {
            // Convert LITRE -> this unit
            return baseValue / _factorToLitre;
        }

        public override string ToString() => _unitName;

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(this, obj)) return true;
            if (obj is not VolumeUnit other) return false;
            return _unitName == other._unitName &&
                   _factorToLitre.Equals(other._factorToLitre);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(_unitName, _factorToLitre);
        }
    }
}