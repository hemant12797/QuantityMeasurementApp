
using Microsoft.VisualStudio.TestTools.UnitTesting;
using QuantityMeasurementApp.Model;

namespace QuantityMeasurement.Tests
{
    [TestClass]
    public class QuantityLengthTests
    {
        private const double EPS = 1e-6;

        // ---------- Conversion Tests (UC5) ----------

        [TestMethod]
        public void testConversion_FeetToInches()
        {
            double result = QuantityLength.Convert(1.0, LengthUnit.FEET, LengthUnit.INCH);
            Assert.AreEqual(12.0, result, EPS);
        }

        [TestMethod]
        public void testConversion_InchesToFeet()
        {
            double result = QuantityLength.Convert(24.0, LengthUnit.INCH, LengthUnit.FEET);
            Assert.AreEqual(2.0, result, EPS);
        }

        [TestMethod]
        public void testConversion_YardsToInches()
        {
            double result = QuantityLength.Convert(1.0, LengthUnit.YARD, LengthUnit.INCH);
            Assert.AreEqual(36.0, result, EPS);
        }

        [TestMethod]
        public void testConversion_InchesToYards()
        {
            double result = QuantityLength.Convert(72.0, LengthUnit.INCH, LengthUnit.YARD);
            Assert.AreEqual(2.0, result, EPS);
        }

        [TestMethod]
        public void testConversion_CentimetersToInches()
        {
            double result = QuantityLength.Convert(2.54, LengthUnit.CENTIMETER, LengthUnit.INCH);
            Assert.AreEqual(1.0, result, 1e-3); // cm constant is approximate, so use looser tolerance
        }

        [TestMethod]
        public void testConversion_FeetToYard()
        {
            double result = QuantityLength.Convert(6.0, LengthUnit.FEET, LengthUnit.YARD);
            Assert.AreEqual(2.0, result, EPS);
        }

        [TestMethod]
        public void testConversion_ZeroValue()
        {
            double result = QuantityLength.Convert(0.0, LengthUnit.FEET, LengthUnit.INCH);
            Assert.AreEqual(0.0, result, EPS);
        }

        [TestMethod]
        public void testConversion_NegativeValue()
        {
            double result = QuantityLength.Convert(-1.0, LengthUnit.FEET, LengthUnit.INCH);
            Assert.AreEqual(-12.0, result, EPS);
        }

        [TestMethod]
        public void testConversion_SameUnit()
        {
            double result = QuantityLength.Convert(5.0, LengthUnit.FEET, LengthUnit.FEET);
            Assert.AreEqual(5.0, result, EPS);
        }

        [TestMethod]
        public void testConversion_RoundTrip_PreservesValue()
        {
            double v = 7.25;
            double toInch = QuantityLength.Convert(v, LengthUnit.FEET, LengthUnit.INCH);
            double backToFeet = QuantityLength.Convert(toInch, LengthUnit.INCH, LengthUnit.FEET);

            Assert.AreEqual(v, backToFeet, 1e-6);
        }

        [TestMethod]
        public void testConversion_NaN_Throws()
        {
            Assert.ThrowsException<System.ArgumentException>(() =>
                QuantityLength.Convert(double.NaN, LengthUnit.FEET, LengthUnit.INCH));
        }

        [TestMethod]
        public void testConversion_Infinity_Throws()
        {
            Assert.ThrowsException<System.ArgumentException>(() =>
                QuantityLength.Convert(double.PositiveInfinity, LengthUnit.FEET, LengthUnit.INCH));
        }

        // ---------- Equality Tests (UC3/UC4 preserved) ----------

        [TestMethod]
        public void testEquality_FeetToInch_Equivalent()
        {
            var q1 = new QuantityLength(1.0, LengthUnit.FEET);
            var q2 = new QuantityLength(12.0, LengthUnit.INCH);
            Assert.IsTrue(q1.Equals(q2));
        }

        [TestMethod]
        public void testEquality_YardToFeet_Equivalent()
        {
            var q1 = new QuantityLength(1.0, LengthUnit.YARD);
            var q2 = new QuantityLength(3.0, LengthUnit.FEET);
            Assert.IsTrue(q1.Equals(q2));
        }

        [TestMethod]
        public void testEquality_CmToInch_Equivalent()
        {
            var q1 = new QuantityLength(1.0, LengthUnit.CENTIMETER);
            var q2 = new QuantityLength(0.393701, LengthUnit.INCH);
            Assert.IsTrue(q1.Equals(q2));
        }

        [TestMethod]
        public void testEquality_NullComparison()
        {
            var q1 = new QuantityLength(1.0, LengthUnit.FEET);
            Assert.IsFalse(q1.Equals(null));
        }

        [TestMethod]
        public void testEquality_SameReference()
        {
            var q1 = new QuantityLength(1.0, LengthUnit.FEET);
            Assert.IsTrue(q1.Equals(q1));
        }
    }
}