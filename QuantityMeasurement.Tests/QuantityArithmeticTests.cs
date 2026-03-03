using Microsoft.VisualStudio.TestTools.UnitTesting;
using QuantityMeasurementApp.Model;
using System;

namespace QuantityMeasurement.Tests
{
    [TestClass]
    public class QuantityArithmeticTests
    {
        [TestMethod]
        public void TestSubtraction_FeetMinusFeet()
        {
            var q1 = new Quantity<LengthUnit>(10, LengthUnit.FEET);
            var q2 = new Quantity<LengthUnit>(5, LengthUnit.FEET);

            var result = q1.Subtract(q2);

            Assert.AreEqual(5, result.Value);
        }

        [TestMethod]
        public void TestDivision_SameUnit()
        {
            var q1 = new Quantity<LengthUnit>(10, LengthUnit.FEET);
            var q2 = new Quantity<LengthUnit>(2, LengthUnit.FEET);

            var result = q1.Divide(q2);

            Assert.AreEqual(5, result);
        }

        [TestMethod]
        [ExpectedException(typeof(ArithmeticException))]
        public void TestDivision_ByZero()
        {
            var q1 = new Quantity<LengthUnit>(10, LengthUnit.FEET);
            var q2 = new Quantity<LengthUnit>(0, LengthUnit.FEET);

            q1.Divide(q2);
        }
    }
}