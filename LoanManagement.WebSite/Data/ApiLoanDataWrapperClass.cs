﻿using LoanManagement.WebSite.Factories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;

namespace LoanManagement.WebSite.Data
{
    public static class ApiLoanDataWrapperClass
    {

        public static async Task<List<Management.Customer>> ObtainCustomers()
        {

            List<Management.Customer> response = new List<Management.Customer>();
            
            ClientFactory<Management.LoanManagerClient> clientFactory = new ClientFactory<Management.LoanManagerClient>();
            Management.LoanManagerClient client = clientFactory.GetClient();

            try
            {
                response = (List<Management.Customer>)await client.GetAllAsync();
            }
            catch (Management.ApiException ex)
            {
                throw ex;
            }
            catch(Exception ex)
            {
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