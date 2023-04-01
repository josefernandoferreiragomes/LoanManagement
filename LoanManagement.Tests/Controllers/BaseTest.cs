using LoanManagement.Platform.Container;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;

namespace LoanManagement.Tests.Controllers
{
    public class BaseTest
    {
        public BaseTest()
        {
            ApplicationContainer.GetContainer().RegisterSingleton<LoanManagement.Interfaces.ILoanManagerRepository, LoanManagement.Repositories.LoanManagerRepository>();
            ApplicationContainer.GetContainer().RegisterSingleton<LoanManagement.DB.Interfaces.IDBLoanManagerRepository, LoanManagement.DB.Repositories.DBLoanManagerRepository>();

        }
    }
}
