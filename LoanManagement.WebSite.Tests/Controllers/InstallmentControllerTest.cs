using LoanManagement.WebSite;
using LoanManagement.WebSite.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace LoanManagement.WebSite.Tests.Controllers
{
    [TestClass]
    public class InstallmentControllerTest
    {
        [TestMethod]
        public void Index()
        {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            ViewResult result = controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public async void LoanInstallments()
        {
            // Arrange
            InstallmentController controller = new InstallmentController();

            int CustomerId, PageSize, LastPage;

            CustomerId = 4;
            PageSize = 2;
            LastPage = 0;

            // Act
            ViewResult result = (ViewResult)await controller.LoanInstallments(CustomerId, LastPage);
            //ActionResult result = controller.About();

            // Assert
            //to be corrected. obtain viewbag instead
            Assert.AreEqual("Your application description page.", result.ViewBag);
        }

        [TestMethod]
        public void Contact()
        {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            ViewResult result = controller.Contact() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }
    }
}
