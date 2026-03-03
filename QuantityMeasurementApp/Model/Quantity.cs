#nullable enable
using System;

namespace QuantityMeasurementApp.Model
{
    public sealed class Quantity<U> where U : IMeasurable
    {
        private const double Epsilon = 1e-6;

        public double Value { get; }
        public U Unit { get; }

        public Quantity(double value, U unit)
        {
            if (unit is null)
                throw new ArgumentException("Unit cannot be null.");

            if (double.IsNaN(value) || double.IsInfinity(value))
                throw new ArgumentException("Value must be a finite number.");

            Value = value;
            Unit = unit;
        }

        public override string ToString()
            => $"Quantity({Value}, {Unit.UnitName})";

        // ====================================================
        // EQUALITY (Works for all categories including Temperature)
        // ====================================================
        public override bool Equals(object? obj)
        {
            if (ReferenceEquals(this, obj))
                return true;

            if (obj is not Quantity<U> other)
                return false;

            if (!string.Equals(Unit.Category, other.Unit.Category, StringComparison.Ordinal))
                return false;

            double thisBase = Unit.ToBase(Value);
            double otherBase = other.Unit.ToBase(other.Value);

            return Math.Abs(thisBase - otherBase) <= Epsilon;
        }

        public override int GetHashCode()
        {
            double baseValue = Unit.ToBase(Value);
            return HashCode.Combine(Unit.Category, Math.Round(baseValue, 6));
        }

        // ====================================================
        // CONVERSION (Works for Temperature and Linear Units)
        // ====================================================
        public Quantity<U> ConvertTo(U targetUnit)
        {
            if (targetUnit is null)
                throw new ArgumentException("Target unit cannot be null.");

            if (!string.Equals(Unit.Category, targetUnit.Category, StringComparison.Ordinal))
                throw new ArgumentException("Cannot convert between different measurement categories.");

            double baseValue = Unit.ToBase(Value);
            double converted = targetUnit.FromBase(baseValue);

            return new Quantity<U>(RoundToTwoDecimals(converted), targetUnit);
        }

        // ====================================================
        // UC13: Arithmetic Operation Enum
        // ====================================================
        private enum ArithmeticOperation
        {
            ADD,
            SUBTRACT,
            DIVIDE
        }

        // ====================================================
        // UC13: Centralized Validation
        // ====================================================
        private void ValidateArithmeticOperands(
            Quantity<U>? other,
            ArithmeticOperation operation,
            U? targetUnit = default,
            bool targetUnitRequired = false)
        {
            if (other is null)
                throw new ArgumentException("Other quantity cannot be null.");

            // UC14: Validate operation support (Temperature blocks here)
            Unit.ValidateOperationSupport(operation.ToString());

            if (!string.Equals(Unit.Category, other.Unit.Category, StringComparison.Ordinal))
                throw new ArgumentException("Cannot operate on different measurement categories.");

            if (double.IsNaN(Value) || double.IsInfinity(Value) ||
                double.IsNaN(other.Value) || double.IsInfinity(other.Value))
                throw new ArgumentException("Values must be finite numbers.");

            if (targetUnitRequired && targetUnit is null)
                throw new ArgumentException("Target unit cannot be null.");

            if (targetUnit is not null &&
                !string.Equals(Unit.Category, targetUnit.Category, StringComparison.Ordinal))
                throw new ArgumentException("Target unit must be in the same measurement category.");
        }

        // ====================================================
        // UC13: Centralized Base Arithmetic
        // ====================================================
        private double PerformBaseArithmetic(Quantity<U> other, ArithmeticOperation operation)
        {
            double baseA = Unit.ToBase(Value);
            double baseB = other.Unit.ToBase(other.Value);

            return operation switch
            {
                ArithmeticOperation.ADD => baseA + baseB,
                ArithmeticOperation.SUBTRACT => baseA - baseB,
                ArithmeticOperation.DIVIDE => baseB == 0
                    ? throw new ArithmeticException("Division by zero is not allowed.")
                    : baseA / baseB,
                _ => throw new ArgumentException("Invalid arithmetic operation.")
            };
        }

        // ====================================================
        // ADD
        // ====================================================
        public Quantity<U> Add(Quantity<U>? other)
            => Add(other, Unit);

        public Quantity<U> Add(Quantity<U>? other, U targetUnit)
        {
            ValidateArithmeticOperands(other, ArithmeticOperation.ADD, targetUnit, true);

            double baseResult = PerformBaseArithmetic(other!, ArithmeticOperation.ADD);
            double converted = targetUnit.FromBase(baseResult);

            return new Quantity<U>(RoundToTwoDecimals(converted), targetUnit);
        }

        // ====================================================
        // SUBTRACT
        // ====================================================
        public Quantity<U> Subtract(Quantity<U>? other)
            => Subtract(other, Unit);

        public Quantity<U> Subtract(Quantity<U>? other, U targetUnit)
        {
            ValidateArithmeticOperands(other, ArithmeticOperation.SUBTRACT, targetUnit, true);

            double baseResult = PerformBaseArithmetic(other!, ArithmeticOperation.SUBTRACT);
            double converted = targetUnit.FromBase(baseResult);

            return new Quantity<U>(RoundToTwoDecimals(converted), targetUnit);
        }

        // ====================================================
        // DIVIDE
        // ====================================================
        public double Divide(Quantity<U>? other)
        {
            ValidateArithmeticOperands(other, ArithmeticOperation.DIVIDE);

            return PerformBaseArithmetic(other!, ArithmeticOperation.DIVIDE);
        }

        // ====================================================
        // Helper
        // ====================================================
        private static double RoundToTwoDecimals(double value)
            => Math.Round(value, 2);
    }
}