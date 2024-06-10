using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;
using AvansDevOps_11.Users;

namespace AvansDevOps_11.tests.CRUDTests
{
    public class UserTests
    {
        [Fact]
        public void Assert_Developer_Is_Created()
        {
            // Arrange

            // Act
            var developer = new Developer("John Doe", "JohnDoe");

            //Assert
            Assert.NotNull(developer);
        }

        [Fact]
        public void Assert_Tester_Is_Created()
        {
            // Arrange

            // Act
            var tester = new Tester("Jane Doe", "JaneDoe");

            //Assert
            Assert.NotNull(tester);
        }

        [Fact]
        public void Assert_ScrumMaster_Is_Created()
        {
            // Arrange

            // Act
            var scrumMaster = new ScrumMaster("Scrum Master", "ScrumMaster");

            //Assert
            Assert.NotNull(scrumMaster);
        }

        [Fact]
        public void Assert_ProductOwner_Is_Created()
        {
            // Arrange

            // Act
            var productOwner = new ProductOwner("Product Owner", "ProductOwner");

            //Assert
            Assert.NotNull(productOwner);
        }

    }
}