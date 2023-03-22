using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;

namespace LoanManagement.WebSite.Factories
{
    public abstract class APIClientFactoryGeneric<T>
    {

        public abstract T GetClient();

    }
}