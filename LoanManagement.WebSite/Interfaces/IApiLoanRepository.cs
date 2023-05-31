using LoanManagement.WebSite.Factories;
using LoanManagement.WebSite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.WebSockets;

namespace LoanManagement.WebSite.Interfaces
{
    public interface IApiLoanRepository
    {

        Task<List<Management.Customer>> ObtainCustomers();

        Task<List<CustomerItem>> SearchCustomers(string searchKeyword, int currentPage, int pageSize);

        Task<List<Management.CustomerLoanInstallmentDBOutItem>> ObtainLoanInstallmentPage(int CustomerId, int pageSize, int LastPageLastItemId);
        
    }

    

   
}