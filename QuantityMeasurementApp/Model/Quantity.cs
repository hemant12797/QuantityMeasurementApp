using System;

namespace QuantityMeasurementApp.Model
{
    public class Quantity<U> where U : IMeasurable
    {
        private readonly double value;
        private readonly U unit;
        private const double EPSILON = 0.0001;

        public Quantity(double value, U unit)
        {
            if (unit == null)
                throw new ArgumentException("Unit cannot be null.");

            if (double.IsNaN(value) || double.IsInfinity(value))
                throw new ArgumentException("Invalid numeric value.");

            this.value = value;
            this.unit = unit;
        }

        public double Value => value;
        public U Unit => unit;

        private double ToBase() => unit.ToBase(value);

        private static double Round(double val) =>
            Math.Round(val, 2);

        private void ValidateOperand(Quantity<U> other)
        {
            if (other == null)
                throw new ArgumentException("Quantity cannot be null.");

            if (this.unit.GetType() != other.unit.GetType())
                throw new ArgumentException("Cross-category operation not allowed.");
        }

        // ================= ADD =================
        public Quantity<U> Add(Quantity<U> other)
        {
            return Add(other, this.unit);
        }

        public Quantity<U> Add(Quantity<U> other, U targetUnit)
        {
            ValidateOperand(other);

            if (targetUnit == null)
                throw new ArgumentException("Target unit cannot be null.");

            double resultBase = this.ToBase() + other.ToBase();
            double converted = targetUnit.FromBase(resultBase);

            return new Quantity<U>(Round(converted), targetUnit);
        }

        // ================= SUBTRACT =================
        public Quantity<U> Subtract(Quantity<U> other)
        {
            return Subtract(other, this.unit);
        }

        public Quantity<U> Subtract(Quantity<U> other, U targetUnit)
        {
            ValidateOperand(other);

            if (targetUnit == null)
                throw new ArgumentException("Target unit cannot be null.");

            double resultBase = this.ToBase() - other.ToBase();
            double converted = targetUnit.FromBase(resultBase);

            return new Quantity<U>(Round(converted), targetUnit);
        }

        // ================= DIVIDE =================
        public double Divide(Quantity<U> other)
        {
            ValidateOperand(other);

            double divisor = other.ToBase();

            if (Math.Abs(divisor) < EPSILON)
                throw new ArithmeticException("Division by zero.");

            return this.ToBase() / divisor;
        }

        // ================= CONVERT =================
        public Quantity<U> ConvertTo(U targetUnit)
        {
            if (targetUnit == null)
                throw new ArgumentException("Target unit cannot be null.");

            double baseValue = this.ToBase();
            double converted = targetUnit.FromBase(baseValue);

            return new Quantity<U>(Round(converted), targetUnit);
        }

        // ================= EQUALS =================
        public override bool Equals(object obj)
        {
            if (obj == null || !(obj is Quantity<U> other))
                return false;

            if (this.unit.GetType() != other.unit.GetType())
                return false;

            return Math.Abs(this.ToBase() - other.ToBase()) < EPSILON;
        }

        public override int GetHashCode()
        {
            return ToBase().GetHashCode();
        }

        public override string ToString()
        {
            return $"Quantity({value}, {unit.UnitName})";
        }
    }
}