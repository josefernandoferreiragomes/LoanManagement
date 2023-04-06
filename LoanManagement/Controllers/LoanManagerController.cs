using LoanManagement.DB.Data;
using LoanManagement.Interfaces;
using LoanManagement.Platform.Container;
using System.Collections.Generic;
using System.Web.Http;
using Unity;

namespace LoanManagement.Controllers
{
    public class LoanManagerController : ApiController, ILoanManagementController
    {
        LoanManagement.Interfaces.ILoanManagerRepository _LoanManagementRepository { get; set; }
        
        public LoanManagerController()
        {
            _LoanManagementRepository = ApplicationContainer.GetContainer().Resolve<LoanManagement.Repositories.LoanManagerRepository>();
        }
        public LoanManagerController(LoanManagement.Interfaces.ILoanManagerRepository repository)
        {
            _LoanManagementRepository = repository;
        }
        
        // GET api/values
        public IEnumerable<Customer> Get()
        {
            IEnumerable<Customer> customers = _LoanManagementRepository.GetCustomer("a");
            return customers;
        }
        //// GET api/values/5
        //public IEnumerable<Customer> Get(string name)
        //{
        //    return _LoanManagementRepository.GetCustomer(name);
        //}
        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
