using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanManagement.DB.Data
{
    public class Loan
    {
        public int LoanId { get; set; } 
        public string LoanDescription { get; set;}
        public decimal LoanValue { get; set; }  
        public int CustomerId { get; set; }
    }
}
