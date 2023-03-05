using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LoanManagement.WebSite.Models
{
    public class AddCustomerViewmodel
    {
        public string Message { get; set;}
        public Customer customer { get; set; }
        
        public List<CustomerType> customerType { get; set; }  

        public List<SelectListItem> selecLoanItems { get; set; }
    }
}