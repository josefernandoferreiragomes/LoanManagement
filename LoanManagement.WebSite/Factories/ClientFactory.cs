using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;

namespace LoanManagement.WebSite.Factories
{
    public class ClientFactory<T>
    {
        private HttpClient _httpclient;
        public ClientFactory()
        {
            _httpclient = new HttpClient();
        }

        public T data;
        public T GetClient()
        {

            switch (typeof(T).Name)
            {
                case "LoanManagerClient":
                    _httpclient.BaseAddress = new Uri(@"http://localhost:51852/Api/LoanManager/");
                    data = (T)Activator.CreateInstance(typeof(T), _httpclient);
                    break;

            }
            return data;
        }

    }
}