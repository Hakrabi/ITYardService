using ITYardService.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace UnitTest.Models
{
    [TestClass]
    public class CustomerTests
    {
        private MockRepository mockRepository;



        [TestInitialize]
        public void TestInitialize()
        {
            this.mockRepository = new MockRepository(MockBehavior.Strict);


        }

        [TestCleanup]
        public void TestCleanup()
        {
            this.mockRepository.VerifyAll();
        }

        private Customer CreateCustomer()
        {
            return new Customer();
        }

        [TestMethod]
        public void DisplayEntityInfo_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var unitUnderTest = this.CreateCustomer();

            // Act
            unitUnderTest.DisplayEntityInfo();

            // Assert
            Assert.Fail();
        }

        [TestMethod]
        public void Validate_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var unitUnderTest = this.CreateCustomer();

            // Act
            var result = unitUnderTest.Validate();

            // Assert
            Assert.Fail();
        }
    }
}
