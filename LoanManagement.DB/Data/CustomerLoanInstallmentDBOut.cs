using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanManagement.DB.Data
{
    public class CustomerLoanInstallmentDBOut
    {
       public List<CustomerLoanInstallmentDBOutItem> ListOfItems { get; set; }
    }

    public class CustomerLoanInstallmentDBOutItem
    {
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string LoanDescription { get; set; }
        public decimal InstallmentValue { get; set; }
        public int InstallmentId { get; set; }
    }
}
