﻿using LoanManagement.WebSite.Data;
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
    public class InstallmentController : Controller
    {
        const int PageSize = 2;
        public ActionResult Index()
        {
            return View();
        }

      

        public async Task<ActionResult> LoanInstallments(int CustomerId=0,int LastPageLastItemId=0)
        {
            CustomerId = 4;
            InstallmentViewModel customerViewModel= await GetCustomerAsync(CustomerId, LastPageLastItemId);
            ViewBag.Message = "Your application description page.";
            return View(customerViewModel);
        }        

        private async Task<InstallmentViewModel> GetCustomerAsync(int CustomerId, int LastPageLastItemId)
        {
            InstallmentViewModel installmentViewModel = new InstallmentViewModel();
            installmentViewModel.InstallmentList = new List<Installment>();            

            List<Management.CustomerLoanInstallmentDBOutItem> response;
            response = await ApiLoanDataWrapperClass.ObtainLoanInstallmentPage(CustomerId, PageSize, LastPageLastItemId);

            foreach (Management.CustomerLoanInstallmentDBOutItem installmentItem in response)
            {
                installmentViewModel.InstallmentList.Add(new Installment { 
                    CustomerName = installmentItem.CustomerName, 
                    LoanDescription = installmentItem.LoanDescription, 
                    InstallmentId = (int)installmentItem.InstallmentId, 
                    InstallmentValue= (decimal)installmentItem.Installment});
            }
            return installmentViewModel;
        }        

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}