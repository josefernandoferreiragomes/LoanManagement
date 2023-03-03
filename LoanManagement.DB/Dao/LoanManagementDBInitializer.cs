using LoanManagement.DB.Data;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanManagement.DB.Dao
{
    public class LoanManagementDBInitializer : DropCreateDatabaseIfModelChanges<LoanManagementDBContext>
    {
        protected override void Seed(LoanManagementDBContext context)
        {
            
            List<Customer> customers = new List<Customer>();
            customers.Add(new Customer() { CustomerName="Richard"});
            customers.Add(new Customer() { CustomerName = "Paul" });

            context.Customers.AddRange(customers);

            context.SaveChanges();
            base.Seed(context);

        }

    }
}
