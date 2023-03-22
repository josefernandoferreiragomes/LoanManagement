using LoanManagement.DB.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LoanManagement.Interfaces
{
    public interface ILoanManagerRepository
    {
        //List<Customer> GetCustomer();
        List<Customer> GetCustomer(string name);
        CustomerLoanInstallmentDBOut GetPageOfCustomerLoanInstallment(CustomerLoaInstallmentDBIn objIn);
    }
}