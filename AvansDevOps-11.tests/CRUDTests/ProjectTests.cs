using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;
using AvansDevOps_11;
using AvansDevOps_11.Users;

namespace AvansDevOps_11.tests.CRUDTests
{
    public class ProjectTests
    {
        [Fact]
        public void Assert_Project_Is_Created()
        {
            //Arrange
            var productOwner = new ProductOwner("Product Owner", "ProductOwner");

            //Act
            var project = new Project("Project", productOwner);

            //Assert
            Assert.NotNull(project);
        }

    }
}