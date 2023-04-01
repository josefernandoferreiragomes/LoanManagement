using LoanManagement.DB.Data;
using LoanManagement.DB.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace LoanManagement.DB.Tests
{
    [TestClass]
    public class LoanManagementDBExecuterTest
    {
        [TestMethod]
        public void Given_CustomerId_When_ThereIsLoanInstallmentDataOrNot_Then_LoanInstallmentIsReturned()
        {
            //Arrange
            DBLoanManagerRepository repository = new DBLoanManagerRepository();
            CustomerLoaInstallmentDBIn objIn = new CustomerLoaInstallmentDBIn();

            objIn.CustomerId = 4;
            objIn.PageSize = 2;
            objIn.LastPageLastInstallmentId = 0;

            //Act
            CustomerLoanInstallmentDBOut objOut = repository.GetPageOfCustomerLoanInstallment(objIn);
            
            //Assert

            Assert.IsTrue(objOut != null);
            Assert.IsTrue(objOut.ListOfItems!=null);
            Assert.IsTrue(objOut.ListOfItems.Count > 0);
            Console.WriteLine(String.Format("RowCount:{0}",objOut.ListOfItems.Count));
        }
    }
}
