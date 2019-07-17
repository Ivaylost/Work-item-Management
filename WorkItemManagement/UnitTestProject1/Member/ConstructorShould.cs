using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using WorkItemManagement.Models;

namespace UnitTestProject1
{
    [TestClass]
    public class ConstructorShould
    {
        [TestMethod]
        public void ThrowWhenMemberNameIsSmallerThanMinValue()
        {
            // Arrange

            Assert.ThrowsException<ArgumentException>(() => new Member("Pe"));

            // Act

            // Assert
        }

        [TestMethod]
        public void ThrowWhenMemberNameIsLargerThanMaxValue()
        {
            // Arrange


            Assert.ThrowsException<ArgumentException>(() => new Member("Pesho Peshev Peshev"));

            // Act

            // Assert

        }
    }
}
