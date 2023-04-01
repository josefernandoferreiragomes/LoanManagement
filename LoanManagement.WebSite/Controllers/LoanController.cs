using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LoanManagement.WebSite.Controllers
{
    public class LoanController : Controller
    {
        // GET: Loan
        public ActionResult SimulateLoan()
        {
            return View();
        }
    }
}