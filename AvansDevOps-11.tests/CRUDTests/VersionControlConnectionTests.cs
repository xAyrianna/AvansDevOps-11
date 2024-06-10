using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;
using AvansDevOps_11;

namespace AvansDevOps_11.tests.CRUDTests
{
    public class VersionControlConnectionTests
    {
        [Fact]
        public void Assert_VersionControlConnection_Is_Created()
        {
            // Arrange
            var versionControlConnection = new VersionControlConnection("link", VersionControlConcept.COMMIT);

            // Act

            //Assert
            Assert.NotNull(versionControlConnection);
        }
    }
}