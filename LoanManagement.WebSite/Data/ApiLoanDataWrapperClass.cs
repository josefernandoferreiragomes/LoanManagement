using LoanManagement.WebSite.Factories;
using LoanManagement.WebSite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.WebSockets;

namespace LoanManagement.WebSite.Data
{
    public static class ApiLoanDataWrapperClass
    {

        public static async Task<List<Management.Customer>> ObtainCustomers()
        {

            List<Management.Customer> response = new List<Management.Customer>();
            
            ConcreteAPIClientFactoryGeneric<Management.LoanManagerClient> clientFactory = new ConcreteAPIClientFactoryGeneric<Management.LoanManagerClient>();
            Management.LoanManagerClient client = clientFactory.GetClient();

            try
            {
                response = (List<Management.Customer>)await client.GetAllAsync();
            }
            catch (Management.ApiException ex)
            {
                //TODO Handle exception
                throw ex;
            }
            catch(Exception ex)
            {
                //TODO Handle exception
                throw ex;
            }
            finally
            {
                //any final procedures like dispose object
            }
            return response;
        }
        public static async Task<List<CustomerItem>> SearchCustomers(string searchKeyword,int currentPage, int pageSize)
        {
            List<CustomerItem> output = new List<CustomerItem>();
            List<Management.CustomerItem> response = new List<Management.CustomerItem>();

            ConcreteAPIClientFactoryGeneric<Management.CustomerItemClient> clientFactory = new ConcreteAPIClientFactoryGeneric<Management.CustomerItemClient>();
            Management.CustomerItemClient client = clientFactory.GetClient();

            try
            {
                int totalCount = 0;
                int totalPages = 4;
                response = (List<Management.CustomerItem>)await client.GetAsync(totalCount, pageSize,currentPage, totalPages,false,false,searchKeyword);
                
                foreach (Management.CustomerItem customerItem in response)
                {
                    CustomerItem tempItem = new CustomerItem();
                    tempItem.CustomerName= customerItem.CustomerName;
                    tempItem.CustomerId = customerItem.CustomerId == null ? 0 : (int)customerItem.CustomerId;
                    output.Add(tempItem);
                }

            }
            catch (Management.ApiException ex)
            {
                //TODO Handle exception
                throw ex;
            }
            catch (Exception ex)
            {
                //TODO Handle exception
                throw ex;
            }
            finally
            {
                //any final procedures like dispose object
            }
            return output;
        }

        public static async Task<List<Management.CustomerLoanInstallmentDBOutItem>> ObtainLoanInstallmentPage(int CustomerId, int pageSize, int LastPageLastItemId)
        {

            List<Management.CustomerLoanInstallmentDBOutItem> response = new List<Management.CustomerLoanInstallmentDBOutItem>();

            ConcreteAPIClientFactoryGeneric<Management.LoanInstallmentClient> clientFactory = new ConcreteAPIClientFactoryGeneric<Management.LoanInstallmentClient>();
            Management.LoanInstallmentClient client = clientFactory.GetClient();

            try
            {
                response = (List<Management.CustomerLoanInstallmentDBOutItem>)await client.GetAsync(CustomerId, pageSize, LastPageLastItemId);
            }
            catch (Management.ApiException ex)
            {
                //TODO Handle exception
                throw ex;
            }
            catch (Exception ex)
            {
                //TODO Handle exception
                throw ex;
            }
            finally
            {
                //any final procedures like dispose object
            }
            return response;
        }
    }

    

   
}