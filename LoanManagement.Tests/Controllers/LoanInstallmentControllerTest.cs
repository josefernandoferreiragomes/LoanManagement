using LoanManagement;
using LoanManagement.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Web.Mvc;

namespace LoanManagement.Tests.Controllers
{
    [TestClass]
    public class LoanInstallmentControllerTest : BaseTest
    {
        [TestMethod]
        public void Get()
        {
            // Arrange
            LoanInstallmentController controller = new LoanInstallmentController();
            int CustomerId, PageSize, LastPage;

            CustomerId = 4;
            PageSize = 2;
            LastPage = 0;
            // Act
            IEnumerable<LoanManagement.DB.Data.CustomerLoanInstallmentDBOutItem> ListOfItems = controller.Get(CustomerId, PageSize, LastPage);

            // Assert
            Assert.IsNotNull(ListOfItems);
            
        }
    }
}
