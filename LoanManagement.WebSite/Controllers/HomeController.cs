using LoanManagement.WebSite.Data;
using LoanManagement.WebSite.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace LoanManagement.WebSite.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {

            ViewBag.Message = "Your Customers.";
            return View();
        }

        public async Task<ActionResult> Customers()
        {
            CustomerViewModel customerViewModel= await GetCustomerAsync();
            ViewBag.Message = "Your application description page.";
            return View(customerViewModel);
        }

        private async Task<CustomerViewModel> GetCustomerAsync()
        {
            CustomerViewModel customerViewModel = new CustomerViewModel();
            customerViewModel.CustomerList = new List<Customer>();            

            List<Management.Customer> response;
            response = await ApiLoanDataWrapperClass.ObtainCustomers();

            foreach (Management.Customer customerItem in response)
            {
                customerViewModel.CustomerList.Add(new Customer { CustomerName = customerItem.CustomerName, Id = (int)customerItem.CustomerId });
            }
            return customerViewModel;
        }        

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}