using LoanManagement.DB.Dao;
using LoanManagement.DB.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

namespace LoanManagement.DB.Tests
{
    [TestClass]
    public class LoanManagementTest
    {
        [TestMethod]
        public void TestDbContext()
        {
            using (var db = new LoanManagementDBContext())
            {
                // Create and save a new Customer
                
                var name = "Jack";

                var customer = new Customer { CustomerName = name };
                db.Customers.Add(customer);
                db.SaveChanges();

                //// Display all customers from the database
                var query = from b in db.Customers.ToList<Customer>()                            
                            select b;

                Console.WriteLine("All customers in the database:");
                foreach (var item in query)
                {
                    Console.WriteLine(item.CustomerName);
                }
            }
        }
    }
}
