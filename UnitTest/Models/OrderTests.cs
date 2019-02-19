using ITYardService.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;

namespace UnitTest.Models
{
    [TestClass]
    public class OrderTests
    {
        private MockRepository mockRepository;

        private Mock<List<Guid>> mockList;

        [TestInitialize]
        public void TestInitialize()
        {
            this.mockRepository = new MockRepository(MockBehavior.Strict);

            this.mockList = this.mockRepository.Create<List<Guid>>();
        }

        [TestCleanup]
        public void TestCleanup()
        {
            this.mockRepository.VerifyAll();
        }

        private Order CreateOrder()
        {
            return new Order(
                TODO,
                TODO,
                TODO,
                this.mockList.Object);
        }

        [TestMethod]
        public void DisplayEntityInfo_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var unitUnderTest = this.CreateOrder();

            // Act
            unitUnderTest.DisplayEntityInfo();

            // Assert
            Assert.Fail();
        }

        [TestMethod]
        public void Validate_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var unitUnderTest = this.CreateOrder();

            // Act
            var result = unitUnderTest.Validate();

            // Assert
            Assert.Fail();
        }
    }
}
