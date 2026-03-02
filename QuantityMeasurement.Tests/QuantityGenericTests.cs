using Microsoft.VisualStudio.TestTools.UnitTesting;
using QuantityMeasurementApp.Model;
using System;

namespace QuantityMeasurement.Tests
{
    [TestClass]
    public class QuantityGenericTests
    {
        private const double EPSILON = 1e-4;

        [TestMethod]
        public void testGenericQuantity_LengthEquality()
        {
            var a = new Quantity<LengthUnit>(1.0, LengthUnit.FEET);
            var b = new Quantity<LengthUnit>(12.0, LengthUnit.INCH);

            Assert.IsTrue(a.Equals(b));
        }

        [TestMethod]
        public void testGenericQuantity_WeightEquality()
        {
            var a = new Quantity<WeightUnit>(1.0, WeightUnit.KILOGRAM);
            var b = new Quantity<WeightUnit>(1000.0, WeightUnit.GRAM);

            Assert.IsTrue(a.Equals(b));
        }

        [TestMethod]
        public void testGenericQuantity_LengthConversion()
        {
            var q = new Quantity<LengthUnit>(1.0, LengthUnit.FEET);
            var converted = q.ConvertTo(LengthUnit.INCH);

            Assert.AreEqual(12.0, converted.Value, EPSILON);
        }

        [TestMethod]
        public void testGenericQuantity_WeightConversion()
        {
            var q = new Quantity<WeightUnit>(1.0, WeightUnit.KILOGRAM);
            var converted = q.ConvertTo(WeightUnit.GRAM);

            Assert.AreEqual(1000.0, converted.Value, EPSILON);
        }

        [TestMethod]
        public void testGenericQuantity_Addition()
        {
            var a = new Quantity<LengthUnit>(1.0, LengthUnit.FEET);
            var b = new Quantity<LengthUnit>(12.0, LengthUnit.INCH);

            var result = a.Add(b, LengthUnit.FEET);

            Assert.AreEqual(2.0, result.Value, EPSILON);
        }

        [TestMethod]
        public void testGenericQuantity_CrossCategoryPrevention()
        {
            var length = new Quantity<LengthUnit>(1.0, LengthUnit.FEET);
            var weight = new Quantity<WeightUnit>(1.0, WeightUnit.KILOGRAM);

            Assert.IsFalse(length.Equals(weight));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void testGenericQuantity_NullUnit()
        {
            new Quantity<LengthUnit>(1.0, null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void testGenericQuantity_InvalidValue()
        {
            new Quantity<LengthUnit>(double.NaN, LengthUnit.FEET);
        }
    }
}