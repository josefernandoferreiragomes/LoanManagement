using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanManagement.DB.Data
{
    public  class Installment
    {
        [Key]
        public int InstallmentId { get; set; }  
        public Loan Loan { get; set; }

        public decimal InstallmentValue { get; set; }
    }
}
