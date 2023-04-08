using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Configuration;

namespace LoanManagement.WebSite.Factories
{
    public class ConcreteAPIClientFactoryGeneric<T> : APIClientFactoryGeneric<T>
    {
        private HttpClient _httpclient;
        public ConcreteAPIClientFactoryGeneric()
        {
            _httpclient = new HttpClient();
        }

        public T data;
        public override T GetClient()
        {

            switch (typeof(T).Name)
            {
                case "LoanManagerClient":
                    _httpclient.BaseAddress = new Uri(System.Configuration.ConfigurationManager.AppSettings["CustomerApiClient"]);
                    //_httpclient.BaseAddress = new Uri(@"http://localhost:51852/Api/LoanManager/");
                    data = (T)Activator.CreateInstance(typeof(T), _httpclient);
                    break;
                case "LoanInstallmentClient":
                    _httpclient.BaseAddress = new Uri(System.Configuration.ConfigurationManager.AppSettings["LoanApiClient"]);
                    //_httpclient.BaseAddress = new Uri(@"http://localhost:51852/Api/LoanInstallment/");
                    data = (T)Activator.CreateInstance(typeof(T), _httpclient);
                    break;
                case "CustomerItemClient":
                    _httpclient.BaseAddress = new Uri(System.Configuration.ConfigurationManager.AppSettings["CustomerItemClient"]);
                    //_httpclient.BaseAddress = new Uri(@"http://localhost:51852/Api/CustomerItem/");
                    data = (T)Activator.CreateInstance(typeof(T), _httpclient);
                    break;

            }
            return data;
        }

    }
}