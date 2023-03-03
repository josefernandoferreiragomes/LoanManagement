using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanManagement.DB.Data
{
    public class Customer
    {
        public int CustomerId { get; set; }  
        public string CustomerName { get; set; } 
        public List<Loan> LoanList { get; set; }
    }
}
