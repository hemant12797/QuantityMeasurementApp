using System;

namespace QuantityMeasurementApp.Model
{
    public sealed class QuantityWeight
    {
        private readonly Quantity<WeightUnit> inner;

        public double Value => inner.Value;
        public WeightUnit Unit => inner.Unit;

        public QuantityWeight(double value, WeightUnit unit)
        {
            inner = new Quantity<WeightUnit>(value, unit);
        }

        private QuantityWeight(Quantity<WeightUnit> q)
        {
            inner = q;
        }

        public QuantityWeight ConvertTo(WeightUnit targetUnit)
            => new QuantityWeight(inner.ConvertTo(targetUnit));

        public static QuantityWeight Add(QuantityWeight first, QuantityWeight second)
            => new QuantityWeight(first.inner.Add(second.inner));

        public static QuantityWeight Add(QuantityWeight first, QuantityWeight second, WeightUnit targetUnit)
            => new QuantityWeight(first.inner.Add(second.inner, targetUnit));

        public override bool Equals(object obj) => inner.Equals(obj is QuantityWeight qw ? qw.inner : obj);
        public override int GetHashCode() => inner.GetHashCode();
        public override string ToString() => inner.ToString();
    }
}