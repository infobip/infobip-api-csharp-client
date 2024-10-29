using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ApiClient.Tests
{
    [TestClass]
    public class UnitTest
    {

        [TestMethod]
        public void PassingTest()
        {
            // Arrange
            int expectedValue = 10;
            int actualValue = 10;

            // Act & Assert
            Assert.AreEqual(expectedValue, actualValue);
        }
    }
}