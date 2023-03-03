using LoanManagement.DB.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanManagement.DB.Interfaces
{
    public interface ILoanManagerRepository
    {
        List<Customer> GetCustomers();
    }
}
