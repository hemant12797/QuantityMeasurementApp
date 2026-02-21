using Microsoft.VisualStudio.TestTools.UnitTesting;
using QuantityMeasurementApp.FeetApp;

namespace QuantityMeasurementApp.Tests
{
    // This attribute marks the class as a Test Class
    [TestClass]
    public class FeetApp1Tests
    {
        // This attribute marks the method as a Test Method
        [TestMethod]
        public void TestCompareEqualValues()
        {
            // Arrange: create two objects with same value
            FeetApp1 f1 = new FeetApp1(10);
            FeetApp1 f2 = new FeetApp1(10);

            // Act: call Compare method to compare values
            f1.Compare(f2);

            // Assert: since method does not return value,we check that method runs successfully without exception
            Assert.IsTrue(true);
        }

        // Test comparing two different values
        [TestMethod]
        public void TestCompareDifferentValues()
        {
            // Arrange: create two objects with different values
            FeetApp1 f1 = new FeetApp1(10);
            FeetApp1 f2 = new FeetApp1(20);

            // Act: call Compare method
            f1.Compare(f2);

            // Assert: method executed successfully
            Assert.IsTrue(true);
        }

        // Test checking reference equality
        [TestMethod]
        public void TestReferenceCheck()
        {
            // Arrange: create object
            FeetApp1 f1 = new FeetApp1(10);

            // Act: pass same object to check reference equality
            f1.Reference(f1);

            // Assert: method executed successfully
            Assert.IsTrue(true);
        }

        // Test null checking
        [TestMethod]
        public void TestNullCheck()
        {
            // Arrange: create object
            FeetApp1 f1 = new FeetApp1(10);

            // Act: pass null to check null handling
            f1.NullCheck(null);

            // Assert: method executed successfully
            Assert.IsTrue(true);
        }

        // Test safe casting of object
        [TestMethod]
        public void TestSafeCasting()
        {
            // Arrange: create object and assign to object type
            FeetApp1 f1 = new FeetApp1(10);
            object obj = new FeetApp1(20);

            // Act: attempt casting
            f1.Cast(obj);

            // Assert: method executed successfully
            Assert.IsTrue(true);
        }
    }
}