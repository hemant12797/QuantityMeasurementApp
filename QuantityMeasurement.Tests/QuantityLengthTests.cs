using Microsoft.VisualStudio.TestTools.UnitTesting;
using QuantityMeasurementApp.Model;

namespace QuantityMeasurement.Tests
{
    [TestClass]
    public class QuantityLengthTests
    {
        [TestMethod]
        public void testEquality_FeetToFeet_SameValue()
        {
            var q1 = new QuantityLength(1.0, LengthUnit.FEET);
            var q2 = new QuantityLength(1.0, LengthUnit.FEET);

            Assert.IsTrue(q1.Equals(q2));
        }

        [TestMethod]
        public void testEquality_InchToInch_SameValue()
        {
            var q1 = new QuantityLength(1.0, LengthUnit.INCH);
            var q2 = new QuantityLength(1.0, LengthUnit.INCH);

            Assert.IsTrue(q1.Equals(q2));
        }

        [TestMethod]
        public void testEquality_FeetToInch_Equivalent()
        {
            var q1 = new QuantityLength(1.0, LengthUnit.FEET);
            var q2 = new QuantityLength(12.0, LengthUnit.INCH);

            Assert.IsTrue(q1.Equals(q2));
        }

        [TestMethod]
        public void testEquality_InchToFeet_Equivalent()
        {
            var q1 = new QuantityLength(12.0, LengthUnit.INCH);
            var q2 = new QuantityLength(1.0, LengthUnit.FEET);

            Assert.IsTrue(q1.Equals(q2));
        }

        [TestMethod]
        public void testEquality_DifferentValue()
        {
            var q1 = new QuantityLength(1.0, LengthUnit.FEET);
            var q2 = new QuantityLength(2.0, LengthUnit.FEET);

            Assert.IsFalse(q1.Equals(q2));
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