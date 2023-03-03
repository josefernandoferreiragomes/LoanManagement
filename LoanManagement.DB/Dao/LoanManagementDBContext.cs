using LoanManagement.DB.Data;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanManagement.DB.Dao
{
    public class LoanManagementDBContext: DbContext
    {
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Loan> Loans { get; set; }


    }
}
