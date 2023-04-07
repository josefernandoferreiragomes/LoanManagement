using LoanManagement.DB.Dao;
using LoanManagement.DB.Data;
using LoanManagement.Interfaces;
using LoanManagement.Platform.Container;
using LoanManagement.Platform.Mapper;
using LoanManagement.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using Unity;

namespace LoanManagement.Repositories
{
    public class LoanManagerRepository:ILoanManagerRepository
    {

        LoanManagement.DB.Interfaces.IDBLoanManagerRepository _repository { get; set; }
        public LoanManagerRepository()
        {
            _repository = ApplicationContainer.GetContainer().Resolve<LoanManagement.DB.Repositories.DBLoanManagerRepository>();
        }

        public LoanManagerRepository(LoanManagement.DB.Interfaces.IDBLoanManagerRepository repository) 
        { 
            _repository= repository;
        }

        //public List<Customer> GetCustomer()
        //{
        //    return _repository.GetCustomers();

        //}
        public IEnumerable<Customer> GetCustomer(string name)
        {
            return _repository.GetCustomers().Where(c => c.CustomerName.Contains(name)).ToList();
            
        }    

        public CustomerLoanInstallmentDBOut GetPageOfCustomerLoanInstallment(CustomerLoaInstallmentDBIn objIn)
        {
            return _repository.GetPageOfCustomerLoanInstallment(objIn);
        }
        List<CustomerItem> ILoanManagerRepository.GetPageOfClassGeneric(int page, int pageSize, string nameFilter)
        {
            List<CustomerItem> customersSV = new List<CustomerItem>();
            List<Customer> customersDB = _repository.GetPageOfClassGeneric(page, page, nameFilter);

            //todo use the integrated list instead of foreach
            foreach (Customer customer in customersDB) 
            {
                CustomerItem customerItem = CustomMapper.Map<Customer, CustomerItem>(customer);
                customersSV.Add(customerItem);
            }
            
            return customersSV;
        }
        public CustomerItem CreateCustomer(CustomerItem customerItem)
        {
            Customer customer = CustomMapper.Map<CustomerItem, Customer>(customerItem);
            _repository.CreateCustomer(customer);
            return customerItem;
        }
        public CustomerItem UpdateCustomer(CustomerItem customerItem)
        {
            Customer customer = CustomMapper.Map<CustomerItem, Customer>(customerItem);
            _repository.UpdateCustomer(customer);
            return customerItem;
        }
    }
}