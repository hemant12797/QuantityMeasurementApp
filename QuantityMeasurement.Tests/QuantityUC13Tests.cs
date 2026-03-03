using Microsoft.VisualStudio.TestTools.UnitTesting;
using QuantityMeasurementApp.Model;
using System;

namespace QuantityMeasurement.Tests
{
    [TestClass]
    public class QuantityUC13Tests
    {
        // ===============================
        // BEHAVIOR PRESERVATION TESTS
        // ===============================

        [TestMethod]
        public void UC13_Add_ShouldStillWork()
        {
            var q1 = new Quantity<LengthUnit>(1, LengthUnit.FEET);
            var q2 = new Quantity<LengthUnit>(12, LengthUnit.INCH);

            var result = q1.Add(q2);

            Assert.AreEqual(2.0, result.Value);
        }

        [TestMethod]
        public void UC13_Subtract_ShouldStillWork()
        {
            var q1 = new Quantity<LengthUnit>(10, LengthUnit.FEET);
            var q2 = new Quantity<LengthUnit>(6, LengthUnit.INCH);

            var result = q1.Subtract(q2);

            Assert.AreEqual(9.5, result.Value);
        }

        [TestMethod]
        public void UC13_Divide_ShouldStillWork()
        {
            var q1 = new Quantity<LengthUnit>(10, LengthUnit.FEET);
            var q2 = new Quantity<LengthUnit>(2, LengthUnit.FEET);

            var result = q1.Divide(q2);

            Assert.AreEqual(5.0, result);
        }

        // ===============================
        // VALIDATION CONSISTENCY TESTS
        // ===============================

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void UC13_Add_NullOperand_ShouldThrow()
        {
            var q = new Quantity<LengthUnit>(1, LengthUnit.FEET);
            q.Add(null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void UC13_Subtract_NullOperand_ShouldThrow()
        {
            var q = new Quantity<LengthUnit>(1, LengthUnit.FEET);
            q.Subtract(null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void UC13_Divide_NullOperand_ShouldThrow()
        {
            var q = new Quantity<LengthUnit>(1, LengthUnit.FEET);
            q.Divide(null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArithmeticException))]
        public void UC13_Divide_ByZero_ShouldThrow()
        {
            var q1 = new Quantity<LengthUnit>(10, LengthUnit.FEET);
            var q2 = new Quantity<LengthUnit>(0, LengthUnit.FEET);

            q1.Divide(q2);
        }

        // ===============================
        // IMMUTABILITY TEST
        // ===============================

        [TestMethod]
        public void UC13_Add_ShouldNotModifyOriginalObjects()
        {
            var q1 = new Quantity<LengthUnit>(1, LengthUnit.FEET);
            var q2 = new Quantity<LengthUnit>(12, LengthUnit.INCH);

            var result = q1.Add(q2);

            Assert.AreEqual(1, q1.Value);
            Assert.AreEqual(12, q2.Value);
        }

        // ===============================
        // ROUNDING TEST
        // ===============================

        [TestMethod]
        public void UC13_Subtract_ShouldRoundToTwoDecimals()
        {
            var q1 = new Quantity<LengthUnit>(1.005, LengthUnit.FEET);
            var q2 = new Quantity<LengthUnit>(0.001, LengthUnit.FEET);

            var result = q1.Subtract(q2);

            Assert.AreEqual(Math.Round(result.Value, 2), result.Value);
        }
    }
}