using LoanManagement.DB.Interfaces;
using LoanManagement.DB.Repositories;
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

        private IUnityContainer myContainer;

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            IUnityContainer myContainer = new UnityContainer();

            myContainer.RegisterSingleton<LoanManagement.Interfaces.ILoanManagerRepository, LoanManagement.Repositories.LoanManagerRepository >();
            myContainer.RegisterSingleton<LoanManagement.DB.Interfaces.ILoanManagerRepository, LoanManagement.DB.Repositories.LoanManagerRepository>();

            
        }

        public IUnityContainer GetContainer()
        {

            return myContainer;
        }
    }
}
