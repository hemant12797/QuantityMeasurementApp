using Microsoft.VisualStudio.TestTools.UnitTesting;
using QuantityMeasurementApp.Model;
using System;

namespace QuantityMeasurement.Tests
{
    [TestClass]
    public class QuantityTemperatureTests
    {
        private const double Eps = 1e-6;

        [TestMethod]
        public void Equality_0C_Equals_32F_ShouldBeTrue()
        {
            var c = new Quantity<TemperatureUnit>(0.0, TemperatureUnit.CELSIUS);
            var f = new Quantity<TemperatureUnit>(32.0, TemperatureUnit.FAHRENHEIT);

            Assert.IsTrue(c.Equals(f));
            Assert.IsTrue(f.Equals(c));
        }

        [TestMethod]
        public void Equality_0C_Equals_273_15K_ShouldBeTrue()
        {
            var c = new Quantity<TemperatureUnit>(0.0, TemperatureUnit.CELSIUS);
            var k = new Quantity<TemperatureUnit>(273.15, TemperatureUnit.KELVIN);

            Assert.IsTrue(c.Equals(k));
        }

        [TestMethod]
        public void Convert_100C_To_F_ShouldBe212()
        {
            var c = new Quantity<TemperatureUnit>(100.0, TemperatureUnit.CELSIUS);
            var f = c.ConvertTo(TemperatureUnit.FAHRENHEIT);

            Assert.AreEqual(212.0, f.Value, Eps);
            Assert.AreEqual("FAHRENHEIT", f.Unit.UnitName);
        }

        [TestMethod]
        public void Convert_32F_To_C_ShouldBe0()
        {
            var f = new Quantity<TemperatureUnit>(32.0, TemperatureUnit.FAHRENHEIT);
            var c = f.ConvertTo(TemperatureUnit.CELSIUS);

            Assert.AreEqual(0.0, c.Value, Eps);
        }

        [TestMethod]
        public void Convert_Minus40C_To_F_ShouldBeMinus40()
        {
            var c = new Quantity<TemperatureUnit>(-40.0, TemperatureUnit.CELSIUS);
            var f = c.ConvertTo(TemperatureUnit.FAHRENHEIT);

            Assert.AreEqual(-40.0, f.Value, Eps);
        }

        [TestMethod]
        public void Add_Temperature_ShouldThrowUnsupportedOperation()
        {
            var t1 = new Quantity<TemperatureUnit>(100.0, TemperatureUnit.CELSIUS);
            var t2 = new Quantity<TemperatureUnit>(50.0, TemperatureUnit.CELSIUS);

            Assert.ThrowsException<UnsupportedOperationException>(() => t1.Add(t2));
        }

        [TestMethod]
        public void Subtract_Temperature_ShouldThrowUnsupportedOperation()
        {
            var t1 = new Quantity<TemperatureUnit>(100.0, TemperatureUnit.CELSIUS);
            var t2 = new Quantity<TemperatureUnit>(50.0, TemperatureUnit.CELSIUS);

            Assert.ThrowsException<UnsupportedOperationException>(() => t1.Subtract(t2));
        }

        [TestMethod]
        public void Divide_Temperature_ShouldThrowUnsupportedOperation()
        {
            var t1 = new Quantity<TemperatureUnit>(100.0, TemperatureUnit.CELSIUS);
            var t2 = new Quantity<TemperatureUnit>(50.0, TemperatureUnit.CELSIUS);

            Assert.ThrowsException<UnsupportedOperationException>(() => t1.Divide(t2));
        }

        [TestMethod]
        public void CrossCategory_TemperatureVsLength_EqualsShouldBeFalse()
        {
            // This won't compile directly due to generics (good).
            // So we do runtime test via object.
            object temp = new Quantity<TemperatureUnit>(0.0, TemperatureUnit.CELSIUS);
            object len = new Quantity<LengthUnit>(0.0, LengthUnit.FEET);

            Assert.IsFalse(temp.Equals(len));
        }
    }
}