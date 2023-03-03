using LoanManagement.DB.Data;
using LoanManagement.Platform.Container;
using System.Collections.Generic;
using System.Web.Http;
using Unity;

namespace LoanManagement.Controllers
{
    public class LoanManagementController : ApiController
    {
        LoanManagement.Interfaces.ILoanManagerRepository _LoanManagementRepository { get; set; }
        //public LoanManagementController() { }
        //public LoanManagementController(LoanManagement.Interfaces.ILoanManagerRepository repository) 
        //{
        //    _LoanManagementRepository = repository;
        //}
        public LoanManagementController()
        {
            _LoanManagementRepository = ApplicationContainer.GetContainer().Resolve<LoanManagement.Interfaces.ILoanManagerRepository>();
        }
        // GET api/values
        public IEnumerable<Customer> Get()
        {
            return _LoanManagementRepository.GetCustomer(1);
        }

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
