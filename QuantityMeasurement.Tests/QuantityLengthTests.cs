using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using QuantityMeasurementApp.Model;

namespace QuantityMeasurement.Tests
{
    [TestClass]
    public class QuantityLengthTests
    {
        private const double EPSILON = 1e-6;

        // =========================================
        // UC3 / UC4 - EQUALITY TESTS
        // =========================================

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

        [TestMethod]
        public void testEquality_FeetToFeet_SameValue()
        {
            var a = new QuantityLength(1.0, LengthUnit.FEET);
            var b = new QuantityLength(1.0, LengthUnit.FEET);
            Assert.IsTrue(a.Equals(b));
        }

        [TestMethod]
        public void testEquality_FeetToInches_Equivalent()
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
        public void testEquality_CentimeterToInch_Equivalent()
        {
            var a = new QuantityLength(2.54, LengthUnit.CENTIMETER);
            var b = new QuantityLength(1.0, LengthUnit.INCH);
            Assert.IsTrue(a.Equals(b));
        }

        [TestMethod]
        public void testEquality_DifferentValues()
        {
            var a = new QuantityLength(1.0, LengthUnit.FEET);
            var b = new QuantityLength(2.0, LengthUnit.FEET);
            Assert.IsFalse(a.Equals(b));
        }

        // =========================================
        // UC5 - CONVERSION TESTS
        // =========================================

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

        [TestMethod]
        public void testConversion_SameUnit()
        {
            double result = QuantityLength.Convert(5.0, LengthUnit.FEET, LengthUnit.FEET);
            Assert.AreEqual(5.0, result, EPSILON);
        }

        // =========================================
        // UC6 - ADDITION (Default First Unit)
        // =========================================

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
        public void testAddition_Commutativity_Default()
        {
            var a = new QuantityLength(1.0, LengthUnit.FEET);
            var b = new QuantityLength(12.0, LengthUnit.INCH);

            var result1 = QuantityLength.Add(a, b);
            var result2 = QuantityLength.Add(b, a);

            Assert.IsTrue(result1.Equals(result2));
        }

        [TestMethod]
        public void testAddition_WithZero_Default()
        {
            var a = new QuantityLength(5.0, LengthUnit.FEET);
            var b = new QuantityLength(0.0, LengthUnit.INCH);

            var result = QuantityLength.Add(a, b);

            Assert.AreEqual(5.0, result.Value, EPSILON);
        }

        [TestMethod]
        public void testAddition_Negative_Default()
        {
            var a = new QuantityLength(5.0, LengthUnit.FEET);
            var b = new QuantityLength(-2.0, LengthUnit.FEET);

            var result = QuantityLength.Add(a, b);

            Assert.AreEqual(3.0, result.Value, EPSILON);
        }

        // =========================================
        // UC7 - ADDITION (Explicit Target Unit)
        // =========================================

        [TestMethod]
        public void testAddition_ExplicitTargetUnit_Feet()
        {
            var a = new QuantityLength(1.0, LengthUnit.FEET);
            var b = new QuantityLength(12.0, LengthUnit.INCH);

            var result = QuantityLength.Add(a, b, LengthUnit.FEET);

            Assert.AreEqual(2.0, result.Value, EPSILON);
            Assert.AreEqual(LengthUnit.FEET, result.Unit);
        }

        [TestMethod]
        public void testAddition_ExplicitTargetUnit_Inches()
        {
            var a = new QuantityLength(1.0, LengthUnit.FEET);
            var b = new QuantityLength(12.0, LengthUnit.INCH);

            var result = QuantityLength.Add(a, b, LengthUnit.INCH);

            Assert.AreEqual(24.0, result.Value, EPSILON);
            Assert.AreEqual(LengthUnit.INCH, result.Unit);
        }

        [TestMethod]
        public void testAddition_ExplicitTargetUnit_Yards()
        {
            var a = new QuantityLength(1.0, LengthUnit.FEET);
            var b = new QuantityLength(12.0, LengthUnit.INCH);

            var result = QuantityLength.Add(a, b, LengthUnit.YARD);

            Assert.AreEqual(0.6667, result.Value, 1e-3);
            Assert.AreEqual(LengthUnit.YARD, result.Unit);
        }

        [TestMethod]
        public void testAddition_ExplicitTargetUnit_Commutativity()
        {
            var a = new QuantityLength(1.0, LengthUnit.FEET);
            var b = new QuantityLength(12.0, LengthUnit.INCH);

            var result1 = QuantityLength.Add(a, b, LengthUnit.YARD);
            var result2 = QuantityLength.Add(b, a, LengthUnit.YARD);

            Assert.IsTrue(result1.Equals(result2));
        }

        [TestMethod]
        public void testAddition_ExplicitTargetUnit_WithZero()
        {
            var a = new QuantityLength(5.0, LengthUnit.FEET);
            var b = new QuantityLength(0.0, LengthUnit.INCH);

            var result = QuantityLength.Add(a, b, LengthUnit.YARD);

            Assert.AreEqual(1.6667, result.Value, 1e-3);
        }

        [TestMethod]
        public void testAddition_ExplicitTargetUnit_NullTarget_Throws()
        {
            var a = new QuantityLength(1.0, LengthUnit.FEET);
            var b = new QuantityLength(12.0, LengthUnit.INCH);

            Assert.ThrowsException<ArgumentException>(() =>
                QuantityLength.Add(a, b, (LengthUnit)100));
        }
    }
}