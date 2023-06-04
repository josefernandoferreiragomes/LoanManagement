using LoanManagement.DB.Data;
using LoanManagement.Interfaces;
using LoanManagement.Models;
using LoanManagement.Platform.Container;
using LoanManagement.Web.Models;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.WebSockets;
using Unity;

namespace LoanManagement.Controllers
{
    public class CustomerItemController : ApiController, ICustomerItemController
    {
        LoanManagement.Interfaces.ILoanManagerRepository _LoanManagementRepository { get; set; }
        
        public CustomerItemController()
        {
            _LoanManagementRepository = ApplicationContainer.GetContainer().Resolve<LoanManagement.Interfaces.ILoanManagerRepository>();
        }
        public CustomerItemController(LoanManagement.Interfaces.ILoanManagerRepository repository)
        {
            _LoanManagementRepository = repository;
        }
        
        // GET api/values
        public IEnumerable<CustomerItem> Get([FromUri] GenericPageParameters parameters)
        
        {
            return _LoanManagementRepository.GetPageOfClassGeneric(parameters.CurrentPage,parameters.PageSize, parameters.SearchKeyword);
        }

        // POST api/values
        public CustomerItem Post([FromBody] CustomerItem customer)
        {
            _LoanManagementRepository.CreateCustomer(customer);
            CustomerItem customerItem = customer;
            if(customerItem == null) 
            { 
            }
            return customerItem;
        }

        // PUT api/values/5
        public CustomerItem Put(int id, [FromBody] CustomerItem customer)
        {

            _LoanManagementRepository.UpdateCustomer(customer);
            CustomerItem customerItem = customer;
            if (customerItem == null)
            {
            }
            return customerItem;
        }
    }
}
