using LoanManagement.DB.Data;
using LoanManagement.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanManagement.Web.UnitTests.Mocks
{
    internal class DBLoanManagerRepositoryMock : LoanManagement.DB.Interfaces.IDBLoanManagerRepository
    {       
        public DBLoanManagerRepositoryMock() { }

        public List<Customer> GetCustomers()
        {
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


            return customerListMock;
        }

        public IEnumerable<Customer> GetPageOfClassGeneric(int page, int pageSize, string nameFilter)
        {
            throw new NotImplementedException();
        }

        public CustomerLoanInstallmentDBOut GetPageOfCustomerLoanInstallment(CustomerLoaInstallmentDBIn objIn)
        {
            throw new NotImplementedException();
        }
    }
}
