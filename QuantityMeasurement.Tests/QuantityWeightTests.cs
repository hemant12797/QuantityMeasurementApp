using Microsoft.VisualStudio.TestTools.UnitTesting;
using QuantityMeasurementApp.Model;
using System;

namespace QuantityMeasurement.Tests
{
    [TestClass]
    public class QuantityWeightTests
    {
        private const double EPSILON = 1e-6;

        // ============================
        // Equality Tests
        // ============================

        [TestMethod]
        public void testEquality_KilogramToKilogram_SameValue()
        {
            var a = new QuantityWeight(1.0, WeightUnit.KILOGRAM);
            var b = new QuantityWeight(1.0, WeightUnit.KILOGRAM);

            Assert.IsTrue(a.Equals(b));
        }

        [TestMethod]
        public void testEquality_KilogramToGram_EquivalentValue()
        {
            var a = new QuantityWeight(1.0, WeightUnit.KILOGRAM);
            var b = new QuantityWeight(1000.0, WeightUnit.GRAM);

            Assert.IsTrue(a.Equals(b));
        }

        [TestMethod]
        public void testEquality_KilogramToPound_EquivalentValue()
        {
            var a = new QuantityWeight(1.0, WeightUnit.KILOGRAM);
            var b = new QuantityWeight(2.20462, WeightUnit.POUND);

            Assert.IsTrue(a.Equals(b));
        }

        [TestMethod]
        public void testEquality_NullComparison()
        {
            var a = new QuantityWeight(1.0, WeightUnit.KILOGRAM);

            Assert.IsFalse(a.Equals(null));
        }

        [TestMethod]
        public void testEquality_WeightVsLength_Incompatible()
        {
            var weight = new QuantityWeight(1.0, WeightUnit.KILOGRAM);
            var length = new QuantityLength(1.0, LengthUnit.FEET);

            Assert.IsFalse(weight.Equals(length));
        }

        // ============================
        // Conversion Tests
        // ============================

        [TestMethod]
        public void testConversion_KilogramToGram()
        {
            var kg = new QuantityWeight(1.0, WeightUnit.KILOGRAM);
            var grams = kg.ConvertTo(WeightUnit.GRAM);

            Assert.AreEqual(1000.0, grams.Value, EPSILON);
        }

        [TestMethod]
        public void testConversion_PoundToKilogram()
        {
            var pound = new QuantityWeight(2.20462, WeightUnit.POUND);
            var kg = pound.ConvertTo(WeightUnit.KILOGRAM);

            Assert.AreEqual(1.0, kg.Value, 1e-4);
        }

        [TestMethod]
        public void testConversion_RoundTrip()
        {
            var original = new QuantityWeight(1.5, WeightUnit.KILOGRAM);
            var converted = original
                                .ConvertTo(WeightUnit.GRAM)
                                .ConvertTo(WeightUnit.KILOGRAM);

            Assert.AreEqual(original.Value, converted.Value, EPSILON);
        }

        // ============================
        // Addition Tests
        // ============================

        [TestMethod]
        public void testAddition_SameUnit_KilogramPlusKilogram()
        {
            var a = new QuantityWeight(1.0, WeightUnit.KILOGRAM);
            var b = new QuantityWeight(2.0, WeightUnit.KILOGRAM);

            var result = QuantityWeight.Add(a, b);

            Assert.AreEqual(3.0, result.Value, EPSILON);
            Assert.AreEqual(WeightUnit.KILOGRAM, result.Unit);
        }

        [TestMethod]
        public void testAddition_CrossUnit_KilogramPlusGram()
        {
            var a = new QuantityWeight(1.0, WeightUnit.KILOGRAM);
            var b = new QuantityWeight(1000.0, WeightUnit.GRAM);

            var result = QuantityWeight.Add(a, b);

            Assert.AreEqual(2.0, result.Value, EPSILON);
        }

        [TestMethod]
        public void testAddition_ExplicitTargetUnit()
        {
            var a = new QuantityWeight(1.0, WeightUnit.KILOGRAM);
            var b = new QuantityWeight(1000.0, WeightUnit.GRAM);

            var result = QuantityWeight.Add(a, b, WeightUnit.GRAM);

            Assert.AreEqual(2000.0, result.Value, EPSILON);
            Assert.AreEqual(WeightUnit.GRAM, result.Unit);
        }

        [TestMethod]
        public void testAddition_Commutativity()
        {
            var a = new QuantityWeight(1.0, WeightUnit.KILOGRAM);
            var b = new QuantityWeight(1000.0, WeightUnit.GRAM);

            var result1 = QuantityWeight.Add(a, b, WeightUnit.KILOGRAM);
            var result2 = QuantityWeight.Add(b, a, WeightUnit.KILOGRAM);

            Assert.AreEqual(result1.Value, result2.Value, EPSILON);
        }

        [TestMethod]
        public void testAddition_WithZero()
        {
            var a = new QuantityWeight(5.0, WeightUnit.KILOGRAM);
            var b = new QuantityWeight(0.0, WeightUnit.GRAM);

            var result = QuantityWeight.Add(a, b);

            Assert.AreEqual(5.0, result.Value, EPSILON);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void testConstructor_InvalidValue()
        {
            new QuantityWeight(double.NaN, WeightUnit.KILOGRAM);
        }
    }
}