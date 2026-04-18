using Microsoft.VisualStudio.TestTools.UnitTesting;
using QuantityMeasurementApp.Model;

namespace QuantityMeasurement.Tests
{
    [TestClass]
    public class QuantityTests
    {
        [TestMethod]
        public void Feet_Compare_Equal()
        {
            Feet f1 = new Feet(1.0);
            Feet f2 = new Feet(1.0);
            Assert.IsTrue(f1.Compare(f2));
        }

        [TestMethod]
        public void Inches_Compare_Equal()
        {
            Inches i1 = new Inches(5.0);
            Inches i2 = new Inches(5.0);
            Assert.IsTrue(i1.Compare(i2));
        }

        [TestMethod]
        public void Feet_NullComparison()
        {
            Feet f1 = new Feet(1.0);
            Assert.IsTrue(f1.NullOrType(null));
        }

        [TestMethod]
        public void InvalidInput_ShouldThrow()
        {
            Assert.ThrowsException<System.ArgumentException>(() => new Feet(double.NaN));
        }
    }
}
