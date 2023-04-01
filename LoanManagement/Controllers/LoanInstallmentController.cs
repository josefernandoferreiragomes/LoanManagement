using LoanManagement.DB.Data;
using LoanManagement.Platform.Container;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Unity;

namespace LoanManagement.Controllers
{
    public class LoanInstallmentController : ApiController
    {
        LoanManagement.Interfaces.ILoanManagerRepository _LoanManagementRepository { get; set; }
      
        public LoanInstallmentController()
        {
            _LoanManagementRepository = ApplicationContainer.GetContainer().Resolve<LoanManagement.Repositories.LoanManagerRepository>();
        }
        // GET api/values
        public IEnumerable<LoanManagement.DB.Data.CustomerLoanInstallmentDBOutItem> Get(int customerId, int pageSize, int lastId)
        {
            CustomerLoaInstallmentDBIn objIn = new CustomerLoaInstallmentDBIn();
            objIn.CustomerId = customerId;
            objIn.PageSize = pageSize;
            objIn.LastPageLastInstallmentId = lastId;
            return _LoanManagementRepository.GetPageOfCustomerLoanInstallment(objIn).ListOfItems;
        }
    }
}
