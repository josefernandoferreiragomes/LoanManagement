using MathNet.Numerics;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanManagement.DB.Data
{
    public class Loan
    {
        [Key]
        public int LoanId { get; set; } 
        public string LoanDescription { get; set;}

        
        public decimal LoanValue { get; set; }

       
        public Customer Customer { get; set; }
    }
}
