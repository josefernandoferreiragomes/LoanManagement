using LoanManagement.Controllers;
using LoanManagement.DB.Data;
using LoanManagement.Interfaces;
using LoanManagement.Platform.Container;
using LoanManagement.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rhino.Mocks;
using System;
using System.Collections.Generic;
using Unity;

namespace LoanManagement.Web.UnitTests
{
    [TestClass]
    public class LoanManagerControllerTest : BaseTest
    {


        private void StartUp()
        {
            BaseStartUp();

            List<Customer> customerListMock = new List<Customer>{
                    new Customer
                    {
                        CustomerName = "Mock John Doe"
                    },
                    new Customer
                    {
                        CustomerName = "Mock Donald Trump"
                    }
                };
            _mockServiceRepository.Stub(r => r.GetCustomers()).Return(customerListMock);
            
            ApplicationContainer.RegisterSingleton<ILoanManagerRepository, LoanManagerRepository>(_mockServiceRepository);
            _mockManagerRepository=ApplicationContainer.Resolve<ILoanManagerRepository>();

            ApplicationContainer.RegisterSingleton<ILoanManagementController, LoanManagerController>(_mockManagerRepository);
            _controller = ApplicationContainer.Resolve<ILoanManagementController>();
            
        }


        [TestMethod]
        public void GetWithMocks()
        {
            StartUp();
            IEnumerable<Customer> customersListOut = _controller.Get();
        }
     
        [TestMethod]
        public void GetWithSimpleMocks()
        {
            #region arrange
            ApplicationContainer.GetContainer().RegisterSingleton<LoanManagement.DB.Interfaces.IDBLoanManagerRepository, LoanManagement.Web.UnitTests.Mocks.DBLoanManagerRepositoryMock>();
            ApplicationContainer.GetContainer().RegisterSingleton<LoanManagement.Interfaces.ILoanManagerRepository, LoanManagement.Repositories.LoanManagerRepository>();
            _controller = new Controllers.LoanManagerController();
            #endregion
            #region act
            IEnumerable<Customer> customerListMock = _controller.Get();
            #endregion
            #region assert
            Assert.IsNotNull(customerListMock);
            #endregion

        }


        //[TestInitialize]
        //private void SetUpTest()
        //{

        //    ApplicationContainer.GetContainer().RegisterSingleton<LoanManagement.DB.Interfaces.IDBLoanManagerRepository, LoanManagement.Web.UnitTests.Mocks.DBLoanManagerRepositoryMock>();
        //    ApplicationContainer.GetContainer().RegisterSingleton<LoanManagement.Interfaces.IDBLoanManagerRepository, LoanManagement.Repositories.DBLoanManagerRepository>();
        //    _controller = new Controllers.LoanManagerController();

        //}

        //[TestCleanup]
        //private void EndTest()
        //{
        //    ApplicationContainer.GetContainer().Dispose();
        //}

    }
}
