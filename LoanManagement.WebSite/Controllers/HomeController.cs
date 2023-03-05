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

        public ActionResult AddCustomer()
        {
            AddCustomerViewmodel addCustomerViewmodel = FillAddCustomerViewModel();
            return View(addCustomerViewmodel);
        }

        private static AddCustomerViewmodel FillAddCustomerViewModel(int selected=0)
        {
            AddCustomerViewmodel addCustomerViewmodel = new AddCustomerViewmodel();
            //MOCK
            List<CustomerType> customerTypes = new List<CustomerType>
            {
                new CustomerType
                {
                    CustomerTypeDescription = "Retail",
                    CustomerTypeID = 1
                },
                new CustomerType
                {
                    CustomerTypeDescription = "Corporate",
                    CustomerTypeID = 2
                }
            };
            //MOCK

            addCustomerViewmodel.selecLoanItems = new List<SelectListItem>();
            foreach (CustomerType customerType in customerTypes)
            {
                addCustomerViewmodel.selecLoanItems.Add(new SelectListItem
                {
                    Value = customerType.CustomerTypeID.ToString(),
                    Text = customerType.CustomerTypeDescription,
                    Selected=customerType.CustomerTypeID == selected
                });
            }

            return addCustomerViewmodel;
        }

        [HttpPost]
        public ActionResult AddCustomer(Customer customer)
        {
            
            AddCustomerViewmodel addCustomerViewmodel = FillAddCustomerViewModel(customer.CustomerTypeId);
            addCustomerViewmodel.customer = new Customer();
            addCustomerViewmodel.customer.CustomerName= customer.CustomerName;
            addCustomerViewmodel.customer.CustomerTypeId= customer.CustomerTypeId;
            addCustomerViewmodel.Message = "Customer successfully added";
            
            return View(addCustomerViewmodel);
        }
        [HttpPost]
        public ActionResult AddCustomerAjax(Customer customer)
        {

            string message = "SUCCESS adding customer from Ajax";
            return Json(new
            {
                Message = message,
                JsonRequestBehavior.AllowGet
            });
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