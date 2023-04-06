using LoanManagement.DB.Dao;
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
    public class DBLoanManagerRepository : IDBLoanManagerRepository
    {
        LoanManagementDBContext _dbContext { get; set; }
        LoanManagementDBExecuter _dbExecuter { get; set; }
        public DBLoanManagerRepository() 
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

        public List<Customer> GetPageOfClassGeneric(int page, int pageSize, string nameFilter)
        {
            var query = _dbContext.Customers
                        .OrderBy(on=>on.CustomerName)
                        .Where(c => c.CustomerName.Contains(nameFilter))
                        .Skip((page-1)*pageSize)
                        .Take(pageSize);
            List<Customer> customers = query.ToList();
            List<Customer> customersOut = new List<Customer>();
            foreach (Customer custItem in customers)
            {
                Customer tempCustomer = custItem;
                tempCustomer.LoanList = new List<Loan>();
                customersOut.Add(tempCustomer);
            }
            return customersOut;
        }

        public CustomerLoanInstallmentDBOut GetPageOfCustomerLoanInstallment(CustomerLoaInstallmentDBIn objIn)
        {
            CustomerLoanInstallmentDBOut objOut = new CustomerLoanInstallmentDBOut();


            objOut = _dbExecuter.CustomerInstallmentGetPage(objIn);

            return objOut;
        }
    }
}
