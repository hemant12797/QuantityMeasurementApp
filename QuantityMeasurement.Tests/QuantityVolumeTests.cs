using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using QuantityMeasurementApp.Model;

namespace QuantityMeasurement.Tests
{
    [TestClass]
    public class QuantityVolumeTests
    {
        private const double EPS = 0.01;

        // -------------------------
        // Equality
        // -------------------------

        [TestMethod]
        public void testEquality_LitreToLitre_SameValue()
        {
            var v1 = new Quantity<VolumeUnit>(1.0, VolumeUnit.LITRE);
            var v2 = new Quantity<VolumeUnit>(1.0, VolumeUnit.LITRE);

            Assert.IsTrue(v1.Equals(v2));
        }

        [TestMethod]
        public void testEquality_LitreToMillilitre_EquivalentValue()
        {
            var v1 = new Quantity<VolumeUnit>(1.0, VolumeUnit.LITRE);
            var v2 = new Quantity<VolumeUnit>(1000.0, VolumeUnit.MILLILITRE);

            Assert.IsTrue(v1.Equals(v2));
            Assert.IsTrue(v2.Equals(v1)); // symmetry
        }

        [TestMethod]
        public void testEquality_GallonToLitre_EquivalentValue()
        {
            // 1 gallon == 3.78541 litres
            var v1 = new Quantity<VolumeUnit>(1.0, VolumeUnit.GALLON);
            var v2 = new Quantity<VolumeUnit>(3.78541, VolumeUnit.LITRE);

            Assert.IsTrue(v1.Equals(v2));
            Assert.IsTrue(v2.Equals(v1));
        }

        [TestMethod]
        public void testEquality_DifferentValue_ReturnsFalse()
        {
            var v1 = new Quantity<VolumeUnit>(1.0, VolumeUnit.LITRE);
            var v2 = new Quantity<VolumeUnit>(2.0, VolumeUnit.LITRE);

            Assert.IsFalse(v1.Equals(v2));
        }

        [TestMethod]
        public void testEquality_NullComparison_ReturnsFalse()
        {
            var v1 = new Quantity<VolumeUnit>(1.0, VolumeUnit.LITRE);

            Assert.IsFalse(v1.Equals(null));
        }

        // Cross-category type safety (volume vs length/weight must be false)
        [TestMethod]
        public void testEquality_VolumeVsLength_Incompatible_ReturnsFalse()
        {
            var volume = new Quantity<VolumeUnit>(1.0, VolumeUnit.LITRE);
            var length = new Quantity<LengthUnit>(1.0, LengthUnit.FEET);

            Assert.IsFalse(volume.Equals(length));
        }

        [TestMethod]
        public void testEquality_VolumeVsWeight_Incompatible_ReturnsFalse()
        {
            var volume = new Quantity<VolumeUnit>(1.0, VolumeUnit.LITRE);
            var weight = new Quantity<WeightUnit>(1.0, WeightUnit.KILOGRAM);

            Assert.IsFalse(volume.Equals(weight));
        }

        // -------------------------
        // Conversion
        // -------------------------

        [TestMethod]
        public void testConversion_LitreToMillilitre()
        {
            var v = new Quantity<VolumeUnit>(1.0, VolumeUnit.LITRE);
            var r = v.ConvertTo(VolumeUnit.MILLILITRE);

            Assert.AreEqual(1000.0, r.Value, EPS);
            Assert.AreEqual(VolumeUnit.MILLILITRE, r.Unit);
        }

        [TestMethod]
        public void testConversion_MillilitreToLitre()
        {
            var v = new Quantity<VolumeUnit>(1000.0, VolumeUnit.MILLILITRE);
            var r = v.ConvertTo(VolumeUnit.LITRE);

            Assert.AreEqual(1.0, r.Value, EPS);
            Assert.AreEqual(VolumeUnit.LITRE, r.Unit);
        }

        [TestMethod]
        public void testConversion_GallonToLitre()
        {
            var v = new Quantity<VolumeUnit>(2.0, VolumeUnit.GALLON);
            var r = v.ConvertTo(VolumeUnit.LITRE);

            Assert.AreEqual(7.57082, r.Value, EPS);
            Assert.AreEqual(VolumeUnit.LITRE, r.Unit);
        }

        [TestMethod]
        public void testConversion_LitreToGallon()
        {
            // 1 litre ≈ 0.264172 gallons
            var v = new Quantity<VolumeUnit>(1.0, VolumeUnit.LITRE);
            var r = v.ConvertTo(VolumeUnit.GALLON);

            Assert.AreEqual(0.264172, r.Value, EPS);
            Assert.AreEqual(VolumeUnit.GALLON, r.Unit);
        }

        // -------------------------
        // Addition (implicit + explicit target)
        // -------------------------

        [TestMethod]
        public void testAddition_ImplicitTarget_LitrePlusMillilitre()
        {
            var v1 = new Quantity<VolumeUnit>(1.0, VolumeUnit.LITRE);
            var v2 = new Quantity<VolumeUnit>(1000.0, VolumeUnit.MILLILITRE);

            var sum = v1.Add(v2); // implicit target = v1.Unit (LITRE)

            Assert.AreEqual(2.0, sum.Value, EPS);
            Assert.AreEqual(VolumeUnit.LITRE, sum.Unit);
        }

        [TestMethod]
        public void testAddition_ImplicitTarget_MillilitrePlusLitre()
        {
            var v1 = new Quantity<VolumeUnit>(1000.0, VolumeUnit.MILLILITRE);
            var v2 = new Quantity<VolumeUnit>(1.0, VolumeUnit.LITRE);

            var sum = v1.Add(v2); // implicit target = MILLILITRE

            Assert.AreEqual(2000.0, sum.Value, EPS);
            Assert.AreEqual(VolumeUnit.MILLILITRE, sum.Unit);
        }

        [TestMethod]
        public void testAddition_ExplicitTarget_Millilitre()
        {
            var v1 = new Quantity<VolumeUnit>(1.0, VolumeUnit.LITRE);
            var v2 = new Quantity<VolumeUnit>(1.0, VolumeUnit.GALLON);

            // 1 L + 1 gal (3.78541 L) = 4.78541 L = 4785.41 mL
            var sum = v1.Add(v2, VolumeUnit.MILLILITRE);

            Assert.AreEqual(4785.41, sum.Value, EPS);
            Assert.AreEqual(VolumeUnit.MILLILITRE, sum.Unit);
        }

        [TestMethod]
        public void testAddition_WithZero()
        {
            var v1 = new Quantity<VolumeUnit>(5.0, VolumeUnit.LITRE);
            var v2 = new Quantity<VolumeUnit>(0.0, VolumeUnit.MILLILITRE);

            var sum = v1.Add(v2);

            Assert.AreEqual(5.0, sum.Value, EPS);
            Assert.AreEqual(VolumeUnit.LITRE, sum.Unit);
        }

        // -------------------------
        // Constructor validation
        // -------------------------

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void testConstructor_NullUnit_Throws()
        {
            _ = new Quantity<VolumeUnit>(1.0, null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void testConstructor_NaN_Throws()
        {
            _ = new Quantity<VolumeUnit>(double.NaN, VolumeUnit.LITRE);
        }
    }
}