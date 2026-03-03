using System;

namespace QuantityMeasurementApp.Model
{
    public class Quantity<U> where U : IMeasurable
    {
        public double Value { get; }
        public U Unit { get; }

        private const double EPSILON = 0.0001;

        public Quantity(double value, U unit)
        {
            if (unit == null)
                throw new ArgumentException("Unit cannot be null.");

            if (double.IsNaN(value) || double.IsInfinity(value))
                throw new ArgumentException("Value must be a finite number.");

            Value = value;
            Unit = unit;
        }

        // ===============================
        // EQUALITY
        // ===============================

        public override bool Equals(object obj)
        {
            if (obj == null || !(obj is Quantity<U> other))
                return false;

            if (this.Unit.GetType() != other.Unit.GetType())
                return false;

            double thisBase = Unit.ToBase(Value);
            double otherBase = other.Unit.ToBase(other.Value);

            return Math.Abs(thisBase - otherBase) < EPSILON;
        }

        public override int GetHashCode()
        {
            return Unit.ToBase(Value).GetHashCode();
        }

        // ===============================
        // CONVERSION
        // ===============================

        public Quantity<U> ConvertTo(U targetUnit)
        {
            if (targetUnit == null)
                throw new ArgumentException("Target unit cannot be null.");

            double baseValue = Unit.ToBase(Value);
            double converted = targetUnit.FromBase(baseValue);

            return new Quantity<U>(RoundToTwoDecimals(converted), targetUnit);
        }

        // ===============================
        // UC13 REFACTORED ARITHMETIC
        // ===============================

        private enum ArithmeticOperation
        {
            ADD,
            SUBTRACT,
            DIVIDE
        }

        private void ValidateArithmeticOperands(
            Quantity<U> other,
            U targetUnit,
            bool targetUnitRequired)
        {
            if (other == null)
                throw new ArgumentException("Operand cannot be null.");

            if (this.Unit.GetType() != other.Unit.GetType())
                throw new ArgumentException("Cross-category arithmetic is not allowed.");

            if (double.IsNaN(this.Value) || double.IsInfinity(this.Value) ||
                double.IsNaN(other.Value) || double.IsInfinity(other.Value))
                throw new ArgumentException("Values must be finite numbers.");

            if (targetUnitRequired && targetUnit == null)
                throw new ArgumentException("Target unit cannot be null.");
        }

        private double PerformBaseArithmetic(
            Quantity<U> other,
            ArithmeticOperation operation)
        {
            double base1 = Unit.ToBase(Value);
            double base2 = other.Unit.ToBase(other.Value);

            switch (operation)
            {
                case ArithmeticOperation.ADD:
                    return base1 + base2;

                case ArithmeticOperation.SUBTRACT:
                    return base1 - base2;

                case ArithmeticOperation.DIVIDE:
                    if (Math.Abs(base2) < EPSILON)
                        throw new ArithmeticException("Division by zero.");
                    return base1 / base2;

                default:
                    throw new InvalidOperationException("Invalid arithmetic operation.");
            }
        }

        // ===============================
        // ADD
        // ===============================

        public Quantity<U> Add(Quantity<U> other)
        {
            return Add(other, this.Unit);
        }

        public Quantity<U> Add(Quantity<U> other, U targetUnit)
        {
            ValidateArithmeticOperands(other, targetUnit, true);

            double baseResult = PerformBaseArithmetic(other, ArithmeticOperation.ADD);
            double converted = targetUnit.FromBase(baseResult);

            return new Quantity<U>(RoundToTwoDecimals(converted), targetUnit);
        }

        // ===============================
        // SUBTRACT
        // ===============================

        public Quantity<U> Subtract(Quantity<U> other)
        {
            return Subtract(other, this.Unit);
        }

        public Quantity<U> Subtract(Quantity<U> other, U targetUnit)
        {
            ValidateArithmeticOperands(other, targetUnit, true);

            double baseResult = PerformBaseArithmetic(other, ArithmeticOperation.SUBTRACT);
            double converted = targetUnit.FromBase(baseResult);

            return new Quantity<U>(RoundToTwoDecimals(converted), targetUnit);
        }

        // ===============================
        // DIVIDE
        // ===============================

        public double Divide(Quantity<U> other)
        {
            ValidateArithmeticOperands(other, default(U), false);

            return PerformBaseArithmetic(other, ArithmeticOperation.DIVIDE);
        }

        // ===============================
        // HELPER
        // ===============================

        private double RoundToTwoDecimals(double value)
        {
            return Math.Round(value, 2);
        }

        public override string ToString()
        {
            return $"{Value} {Unit.UnitName}";
        }
    }
}