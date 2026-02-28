using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using QuantityMeasurementApp.Model;

namespace QuantityMeasurement.Tests
{
    [TestClass]
    public class QuantityLengthTests
    {
        private const double EPSILON = 1e-6;

        // =========================
        // UC5 - CONVERSION TESTS
        // =========================

        [TestMethod]
        public void testConversion_FeetToInches()
        {
            double result = QuantityLength.Convert(1.0, LengthUnit.FEET, LengthUnit.INCH);
            Assert.AreEqual(12.0, result, EPSILON);
        }

        [TestMethod]
        public void testConversion_InchesToFeet()
        {
            double result = QuantityLength.Convert(24.0, LengthUnit.INCH, LengthUnit.FEET);
            Assert.AreEqual(2.0, result, EPSILON);
        }

        [TestMethod]
        public void testConversion_YardsToFeet()
        {
            double result = QuantityLength.Convert(1.0, LengthUnit.YARD, LengthUnit.FEET);
            Assert.AreEqual(3.0, result, EPSILON);
        }

        [TestMethod]
        public void testConversion_CentimeterToInch()
        {
            double result = QuantityLength.Convert(2.54, LengthUnit.CENTIMETER, LengthUnit.INCH);
            Assert.AreEqual(1.0, result, 1e-4);
        }

        // =========================
        // UC3/UC4 - EQUALITY TESTS
        // =========================

        [TestMethod]
        public void testEquality_FeetToInch_Equivalent()
        {
            var a = new QuantityLength(1.0, LengthUnit.FEET);
            var b = new QuantityLength(12.0, LengthUnit.INCH);

            Assert.IsTrue(a.Equals(b));
        }

        [TestMethod]
        public void testEquality_YardToFeet_Equivalent()
        {
            var a = new QuantityLength(1.0, LengthUnit.YARD);
            var b = new QuantityLength(3.0, LengthUnit.FEET);

            Assert.IsTrue(a.Equals(b));
        }

        [TestMethod]
        public void testEquality_SameReference()
        {
            var a = new QuantityLength(1.0, LengthUnit.FEET);
            Assert.IsTrue(a.Equals(a));
        }

        [TestMethod]
        public void testEquality_NullComparison()
        {
            var a = new QuantityLength(1.0, LengthUnit.FEET);
            Assert.IsFalse(a.Equals(null));
        }

        // =========================
        // UC6 - ADDITION TESTS
        // =========================

        [TestMethod]
        public void testAddition_SameUnit_FeetPlusFeet()
        {
            var a = new QuantityLength(1.0, LengthUnit.FEET);
            var b = new QuantityLength(2.0, LengthUnit.FEET);

            var result = QuantityLength.Add(a, b);

            Assert.AreEqual(3.0, result.Value, EPSILON);
        }

        [TestMethod]
        public void testAddition_CrossUnit_FeetPlusInches()
        {
            var a = new QuantityLength(1.0, LengthUnit.FEET);
            var b = new QuantityLength(12.0, LengthUnit.INCH);

            var result = QuantityLength.Add(a, b);

            Assert.AreEqual(2.0, result.Value, EPSILON);
        }

        [TestMethod]
        public void testAddition_CrossUnit_InchPlusFeet()
        {
            var a = new QuantityLength(12.0, LengthUnit.INCH);
            var b = new QuantityLength(1.0, LengthUnit.FEET);

            var result = QuantityLength.Add(a, b);

            Assert.AreEqual(24.0, result.Value, EPSILON);
        }

        [TestMethod]
        public void testAddition_YardPlusFeet()
        {
            var a = new QuantityLength(1.0, LengthUnit.YARD);
            var b = new QuantityLength(3.0, LengthUnit.FEET);

            var result = QuantityLength.Add(a, b);

            Assert.AreEqual(2.0, result.Value, EPSILON);
        }

        [TestMethod]
        public void testAddition_Commutativity()
        {
            var a = new QuantityLength(1.0, LengthUnit.FEET);
            var b = new QuantityLength(12.0, LengthUnit.INCH);

            var result1 = QuantityLength.Add(a, b);
            var result2 = QuantityLength.Add(b, a);

            Assert.IsTrue(result1.Equals(result2));
        }

        [TestMethod]
        public void testAddition_WithZero()
        {
            var a = new QuantityLength(5.0, LengthUnit.FEET);
            var b = new QuantityLength(0.0, LengthUnit.INCH);

            var result = QuantityLength.Add(a, b);

            Assert.AreEqual(5.0, result.Value, EPSILON);
        }

        [TestMethod]
        public void testAddition_NegativeValues()
        {
            var a = new QuantityLength(5.0, LengthUnit.FEET);
            var b = new QuantityLength(-2.0, LengthUnit.FEET);

            var result = QuantityLength.Add(a, b);

            Assert.AreEqual(3.0, result.Value, EPSILON);
        }

        [TestMethod]
        public void testAddition_NullSecondOperand()
        {
            var a = new QuantityLength(1.0, LengthUnit.FEET);

            Assert.ThrowsException<ArgumentException>(() =>
                QuantityLength.Add(a, null));
        }
    }
}