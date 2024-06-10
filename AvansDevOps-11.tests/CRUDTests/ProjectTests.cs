using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace AvansDevOps_11.tests.CRUDTests
{
    public class ProjectTests
    {
        [Fact]
        public void Assert_Project_Is_Created()
        {
            //Arrange
            var productOwner = new ProductOwner("Product Owner");

            //Act
            var project = new Project("Project", productOwner);

            //Assert
            Assert.NotNull(project);
        }

        [Fact]
        public void Assert_Project_Cannot_Be_Created_Without_ProductOwner()
        {
            //Arrange

            //Act
            var project = new Project("Project", null);

            //Assert
            Assert.Null(project);
        }
    }
}