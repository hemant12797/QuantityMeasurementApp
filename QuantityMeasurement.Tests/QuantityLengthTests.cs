using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using QuantityMeasurementApp.Model;
namespace QuantityMeasurement.Tests
{
    [TestClass]
    public class QuantityLengthTests
    {
        private const double EPSILON = 0.01;

        // =========================
        // UC1 – Equality Tests
        // =========================

        [TestMethod]
        public void testEquality_SameFeet_ReturnsTrue()
        {
            var q1 = new Quantity<LengthUnit>(1.0, LengthUnit.FEET);
            var q2 = new Quantity<LengthUnit>(1.0, LengthUnit.FEET);

            Assert.IsTrue(q1.Equals(q2));
        }

        [TestMethod]
        public void testEquality_FeetToInch_ReturnsTrue()
        {
            var q1 = new Quantity<LengthUnit>(1.0, LengthUnit.FEET);
            var q2 = new Quantity<LengthUnit>(12.0, LengthUnit.INCH);

            Assert.IsTrue(q1.Equals(q2));
        }

        [TestMethod]
        public void testEquality_DifferentValues_ReturnsFalse()
        {
            var q1 = new Quantity<LengthUnit>(1.0, LengthUnit.FEET);
            var q2 = new Quantity<LengthUnit>(2.0, LengthUnit.FEET);

            Assert.IsFalse(q1.Equals(q2));
        }

        [TestMethod]
        public void testEquality_NullComparison_ReturnsFalse()
        {
            var q1 = new Quantity<LengthUnit>(1.0, LengthUnit.FEET);

            Assert.IsFalse(q1.Equals(null));
        }

        // =========================
        // UC5 – Conversion Tests
        // =========================

        [TestMethod]
        public void testConversion_FeetToInches()
        {
            var q = new Quantity<LengthUnit>(1.0, LengthUnit.FEET);
            var result = q.ConvertTo(LengthUnit.INCH);

            Assert.AreEqual(12.0, result.Value, EPSILON);
        }

        [TestMethod]
        public void testConversion_InchToFeet()
        {
            var q = new Quantity<LengthUnit>(12.0, LengthUnit.INCH);
            var result = q.ConvertTo(LengthUnit.FEET);

            Assert.AreEqual(1.0, result.Value, EPSILON);
        }

        [TestMethod]
        public void testConversion_YardToFeet()
        {
            var q = new Quantity<LengthUnit>(1.0, LengthUnit.YARD);
            var result = q.ConvertTo(LengthUnit.FEET);

            Assert.AreEqual(3.0, result.Value, EPSILON);
        }

        [TestMethod]
        public void testConversion_CentimeterToFeet()
        {
            var q = new Quantity<LengthUnit>(30.48, LengthUnit.CENTIMETER);
            var result = q.ConvertTo(LengthUnit.FEET);

            Assert.AreEqual(1.0, result.Value, EPSILON);
        }

        // =========================
        // UC6 – Addition (Implicit Target Unit)
        // =========================

        [TestMethod]
        public void testAddition_SameUnit()
        {
            var q1 = new Quantity<LengthUnit>(1.0, LengthUnit.FEET);
            var q2 = new Quantity<LengthUnit>(2.0, LengthUnit.FEET);

            var result = q1.Add(q2);

            Assert.AreEqual(3.0, result.Value, EPSILON);
            Assert.AreEqual(LengthUnit.FEET, result.Unit);
        }

        [TestMethod]
        public void testAddition_CrossUnit_FeetPlusInch()
        {
            var q1 = new Quantity<LengthUnit>(1.0, LengthUnit.FEET);
            var q2 = new Quantity<LengthUnit>(12.0, LengthUnit.INCH);

            var result = q1.Add(q2);

            Assert.AreEqual(2.0, result.Value, EPSILON);
            Assert.AreEqual(LengthUnit.FEET, result.Unit);
        }

        // =========================
        // UC7 – Addition (Explicit Target Unit)
        // =========================

        [TestMethod]
        public void testAddition_WithExplicitTargetUnit_Inches()
        {
            var q1 = new Quantity<LengthUnit>(1.0, LengthUnit.FEET);
            var q2 = new Quantity<LengthUnit>(12.0, LengthUnit.INCH);

            var result = q1.Add(q2, LengthUnit.INCH);

            Assert.AreEqual(24.0, result.Value, EPSILON);
            Assert.AreEqual(LengthUnit.INCH, result.Unit);
        }

        [TestMethod]
        public void testAddition_WithExplicitTargetUnit_Yards()
        {
            var q1 = new Quantity<LengthUnit>(1.0, LengthUnit.FEET);
            var q2 = new Quantity<LengthUnit>(12.0, LengthUnit.INCH);

            var result = q1.Add(q2, LengthUnit.YARD);

            Assert.AreEqual(0.67, result.Value, EPSILON);
            Assert.AreEqual(LengthUnit.YARD, result.Unit);
        }

        // =========================
        // Constructor Validation
        // =========================

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void testConstructor_NullUnit_ThrowsException()
        {
            var q = new Quantity<LengthUnit>(1.0, null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void testConstructor_InvalidValue_ThrowsException()
        {
            var q = new Quantity<LengthUnit>(double.NaN, LengthUnit.FEET);
        }
    }
}