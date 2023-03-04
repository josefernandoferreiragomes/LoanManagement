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

        //public ActionResult About()
        //{

        //    ViewBag.Message = "Your application description page.";
        //    return View();
        //}

        public async Task<ActionResult> About()
        {
            await GetCustomerAsync();
            ViewBag.Message = "Your application description page.";
            return View();
        }

        public async Task<List<Management.Customer>> GetCustomerAsync()
        {

            ViewBag.Message = "Your application description page.";
            HttpClient httpclient = new HttpClient();
            httpclient.BaseAddress = new Uri(@"http://localhost:51852/Api/LoanManager/");
            Management.LoanManagerClient client = new Management.LoanManagerClient(httpclient);

            List<Management.Customer> customer = new List<Management.Customer>();
            
            List<Management.Customer> response = (List<Management.Customer>)await client.GetAllAsync();            

            return customer;
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}