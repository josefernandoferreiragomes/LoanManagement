using LoanManagement;
using LoanManagement.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Web.Mvc;

namespace LoanManagement.Tests.Controllers
{
    [TestClass]
    public class LoanManagementControllerTest : BaseTest
    {
        [TestMethod]
        public void Get()
        {
            // Arrange
            LoanManagerController controller = new LoanManagerController();

            // Act
            var result = controller.Get();

            // Assert
            Assert.IsNotNull(result);
            
        }
    }
}
