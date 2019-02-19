using ITYardService.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace UnitTest.Models
{
    [TestClass]
    public class AddressTests
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

        private Address CreateAddress()
        {
            return new Address();
        }

        [TestMethod]
        public void DisplayEntityInfo_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var unitUnderTest = this.CreateAddress();

            // Act
            unitUnderTest.DisplayEntityInfo();

            // Assert
            Assert.Fail();
        }

        [TestMethod]
        public void Validate_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var unitUnderTest = this.CreateAddress();

            // Act
            var result = unitUnderTest.Validate();

            // Assert
            Assert.Fail();
        }
    }
}
