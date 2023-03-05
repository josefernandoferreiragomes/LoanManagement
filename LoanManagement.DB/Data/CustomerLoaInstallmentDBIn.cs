using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanManagement.DB.Data
{
    public class CustomerLoaInstallmentDBIn
    {
        public int CustomerId { get; set; } 
        public int PageSize { get; set; }
        public int LastPageLastInstallmentId { get; set; }
    }
}
