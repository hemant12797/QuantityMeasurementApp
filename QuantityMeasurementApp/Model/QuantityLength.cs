using System;

namespace QuantityMeasurementApp.Model
{
    public sealed class QuantityLength
    {
        private readonly Quantity<LengthUnit> inner;

        public double Value => inner.Value;
        public LengthUnit Unit => inner.Unit;

        public QuantityLength(double value, LengthUnit unit)
        {
            inner = new Quantity<LengthUnit>(value, unit);
        }

        private QuantityLength(Quantity<LengthUnit> q)
        {
            inner = q;
        }

        public QuantityLength ConvertTo(LengthUnit targetUnit)
            => new QuantityLength(inner.ConvertTo(targetUnit));

        public static double Convert(double value, LengthUnit source, LengthUnit target)
            => new Quantity<LengthUnit>(value, source).ConvertTo(target).Value;

        public static QuantityLength Add(QuantityLength first, QuantityLength second)
            => new QuantityLength(first.inner.Add(second.inner));

        public static QuantityLength Add(QuantityLength first, QuantityLength second, LengthUnit targetUnit)
            => new QuantityLength(first.inner.Add(second.inner, targetUnit));

        public override bool Equals(object obj) => inner.Equals(obj is QuantityLength ql ? ql.inner : obj);
        public override int GetHashCode() => inner.GetHashCode();
        public override string ToString() => inner.ToString();
    }
}