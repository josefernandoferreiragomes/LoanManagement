using LoanManagement.DB.Data;
using LoanManagement.Interfaces;
using LoanManagement.Platform.Container;
using LoanManagement.Web.Models;
using System.Collections.Generic;
using System.Web.Http;
using Unity;

namespace LoanManagement.Controllers
{
    public class CustomerItemController : ApiController, ICustomerItemController
    {
        LoanManagement.Interfaces.ILoanManagerRepository _LoanManagementRepository { get; set; }
        
        public CustomerItemController()
        {
            _LoanManagementRepository = ApplicationContainer.GetContainer().Resolve<LoanManagement.Repositories.LoanManagerRepository>();
        }
        public CustomerItemController(LoanManagement.Interfaces.ILoanManagerRepository repository)
        {
            _LoanManagementRepository = repository;
        }
        
        // GET api/values
        public IEnumerable<CustomerItem> Get(string searchKeyWord)
        
        {
            return _LoanManagementRepository.GetPageOfClassGeneric(3,3, searchKeyWord);
        }
       
    }
}
