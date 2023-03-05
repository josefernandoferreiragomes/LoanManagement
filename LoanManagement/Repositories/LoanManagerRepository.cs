using LoanManagement.DB.Dao;
using LoanManagement.DB.Data;
using LoanManagement.Interfaces;
using LoanManagement.Platform.Container;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Unity;

namespace LoanManagement.Repositories
{
    public class LoanManagerRepository:ILoanManagerRepository
    {
        LoanManagement.DB.Interfaces.ILoanManagerRepository _repository;
        public LoanManagerRepository(LoanManagement.DB.Interfaces.ILoanManagerRepository repository) 
        { 
            _repository= ApplicationContainer.GetContainer().Resolve<LoanManagement.DB.Interfaces.ILoanManagerRepository>();
        }

        public List<Customer> GetCustomer(int id)
        {
            return _repository.GetCustomers();
            
        }

        public CustomerLoanInstallmentDBOut GetPageOfCustomerLoanInstallment(CustomerLoaInstallmentDBIn objIn)
        {
            return _repository.GetPageOfCustomerLoanInstallment(objIn);
        }
    }
}