using LoanManagement.Controllers;
using LoanManagement.DB.Data;
using LoanManagement.DB.Interfaces;
using LoanManagement.DB.Repositories;
using LoanManagement.Interfaces;
using LoanManagement.Platform.Container;
using LoanManagement.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rhino.Mocks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;

namespace LoanManagement.Web.UnitTests
{
    [TestClass]
    public class BaseTest
    {
        public static IDBLoanManagerRepository _mockServiceRepository = MockRepository.GenerateStub<IDBLoanManagerRepository>();
        public static ILoanManagerRepository _mockManagerRepository;
        public static ILoanManagementController _controller;
        

        public void BaseStartUp()
        {
            ApplicationContainer.RegisterSingleton<IDBLoanManagerRepository, DBLoanManagerRepository>();
            ApplicationContainer.RegisterSingleton<ILoanManagerRepository, LoanManagerRepository>();
        }

    }

  
}
