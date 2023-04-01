using LoanManagement.DB.Interfaces;
using LoanManagement.DB.Repositories;
using LoanManagement.Platform.Container;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Unity;

namespace LoanManagement
{
    public class WebApiApplication : System.Web.HttpApplication
    {

        

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);



            ApplicationContainer.GetContainer().RegisterSingleton<LoanManagement.Interfaces.ILoanManagerRepository, LoanManagement.Repositories.LoanManagerRepository >();
            ApplicationContainer.GetContainer().RegisterSingleton<LoanManagement.DB.Interfaces.IDBLoanManagerRepository, LoanManagement.DB.Repositories.DBLoanManagerRepository>();

            
        }

        
    }
}
