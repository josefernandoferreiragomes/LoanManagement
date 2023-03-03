using LoanManagement.DB.Dao;
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
        public LoanManagerRepository() 
        { 
            _dbContext = new LoanManagementDBContext();
        }

        public List<Customer> GetCustomers()
        {
            var query = from b in _dbContext.Customers.ToList<Customer>()
                        select b;
            return query.ToList();
        }
    }
}
