﻿using LoanManagement.DB.Dao;
using LoanManagement.DB.DaoSqlExecuters;
using LoanManagement.DB.Data;
using LoanManagement.DB.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Metadata.Edm;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanManagement.DB.Repositories
{
    public class LoanManagerRepository : ILoanManagerRepository
    {
        private LoanManagementDBContext _dbContext;
        private LoanManagementDBExecuter _dbExecuter;
        public LoanManagerRepository() 
        { 
            _dbContext = new LoanManagementDBContext();
            _dbExecuter= new LoanManagementDBExecuter();
        }

        public List<Customer> GetCustomers()
        {
            var query = from b in _dbContext.Customers.ToList<Customer>()
                        select b;
            return query.ToList();
        }

        public CustomerLoanInstallmentDBOut GetPageOfCustomerLoanInstallment(CustomerLoaInstallmentDBIn objIn)
        {
            CustomerLoanInstallmentDBOut objOut = new CustomerLoanInstallmentDBOut();


            objOut = _dbExecuter.CustomerInstallmentGetPage(objIn);

            return objOut;
        }
    }
}
