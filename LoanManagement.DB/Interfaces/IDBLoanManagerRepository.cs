using LoanManagement.DB.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanManagement.DB.Interfaces
{
    public interface IDBLoanManagerRepository
    {
        List<Customer> GetCustomers();
        List<Customer> GetPageOfClassGeneric(int page, int pageSize, string nameFilter);
        Customer CreateCustomer(Customer customer);
        Customer UpdateCustomer(Customer customer);
        CustomerLoanInstallmentDBOut GetPageOfCustomerLoanInstallment(CustomerLoaInstallmentDBIn objIn);
       
    }
}
