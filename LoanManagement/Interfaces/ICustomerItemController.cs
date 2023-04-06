using LoanManagement.DB.Data;
using LoanManagement.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LoanManagement.Interfaces
{
    public interface ICustomerItemController
    {
        IEnumerable<CustomerItem> Get(string searchKeyWord);
    }
}