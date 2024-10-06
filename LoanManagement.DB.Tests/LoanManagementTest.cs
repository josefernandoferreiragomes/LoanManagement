using LoanManagement.DB.Dao;
using LoanManagement.DB.Data;
using LoanManagement.DB.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;

namespace LoanManagement.DB.Tests
{
    [TestClass]
    public class LoanManagementTest
    {
        private readonly string ConnectionString;

        public LoanManagementTest()
        {
            this.ConnectionString = ConfigurationManager.ConnectionStrings["LoanManagement.DB.Dao.LoanManagementDBContext"].ConnectionString;
        }


        [TestMethod]
        public void TestDbContextDbSeed()
        {
            using (var context = new LoanManagementDBContext(this.ConnectionString))
            {
                List<Customer> customers = new List<Customer>();
                Customer customerA = new Customer() { CustomerName = "Jack Ma" };
                Customer customerB = new Customer() { CustomerName = "Jack Dorsey" };

                customers.Add(customerA);
                customers.Add(customerB);
                customers.Add(new Customer() { CustomerName = "John Doe" });
                customers.Add(new Customer() { CustomerName = "Satya Nadella" });
                customers.Add(new Customer() { CustomerName = "Elon Musk" });
                customers.Add(new Customer() { CustomerName = "Elizabeth Holmes" });
                customers.Add(new Customer() { CustomerName = "Sundar Pichai" });

                context.Customers.AddRange(customers);

                List<Loan> loans = new List<Loan>();
                Loan loanA = new Loan() { Customer = customerA, LoanDescription = "Mortgage loan", LoanValue = 100000 };
                Loan loanB = new Loan() { Customer = customerB, LoanDescription = "Leasing loan", LoanValue = 50000 };
                loans.Add(loanA);
                loans.Add(loanB);

                context.Loans.AddRange(loans);

                List<Installment> installments = new List<Installment>();
                installments.Add(new Installment() { Loan = loanA, InstallmentValue = loanA.LoanValue / 36 });
                installments.Add(new Installment() { Loan = loanB, InstallmentValue = loanB.LoanValue / 36 });

                context.Installments.AddRange(installments);

                context.SaveChanges();
            }
        }
        [TestMethod]
        public void TestDbContext()
        {
            using (var db = new LoanManagementDBContext(this.ConnectionString))
            {
                // Create and save a new Customer

                var name = "Paul";

                var customer = new Customer { CustomerName = name };
                db.Customers.Add(customer);

                //var loan = new Loan { Customer= customer, LoanDescription="new loan 4", LoanValue=100 };
                //db.Loans.Add(loan);
                //db.SaveChanges();

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

        [TestMethod]
        public void TestPagination()
        {

            //arrange
            var db = new DBLoanManagerRepository();


            //act
            IEnumerable<Customer> filteredCustomers = db.GetPageOfClassGeneric(5, 3, "1");

            //assert
            Assert.IsNotNull(filteredCustomers);

        }
    }
}
