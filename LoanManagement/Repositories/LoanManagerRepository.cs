using LoanManagement.DB.Dao;
using LoanManagement.DB.Data;
using LoanManagement.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LoanManagement.Repositories
{
    public class LoanManagerRepository:ILoanManagerRepository
    {
        LoanManagement.DB.Interfaces.ILoanManagerRepository _repository;
        public LoanManagerRepository(LoanManagement.DB.Interfaces.ILoanManagerRepository repository) 
        { 
            _repository= repository;
        }

        public List<Customer> GetCustomer(int id)
        {
            return _repository.GetCustomers();
            
        }
    }
}