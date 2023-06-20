using LoanManagement.DB.Dao;
using LoanManagement.DB.DaoSqlExecuters;
using LoanManagement.DB.Data;
using LoanManagement.DB.Interfaces;

using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Metadata.Edm;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LoanManagement.Platform.Serializer;
using LoanManagement.Platform.Logger;
namespace LoanManagement.DB.Repositories
{
    public class DBLoanManagerRepository : IDBLoanManagerRepository
    {
         
        LoanManagementDBContext _dbContext { get; set; }
        LoanManagementDBExecuter _dbExecuter { get; set; }
        public DBLoanManagerRepository() 
        { 
            _dbContext = new LoanManagementDBContext();
            _dbExecuter= new LoanManagementDBExecuter();
            SetupLog();


        }
        private void SetupLog()
        {
            ////TO BE MOVED TO A CUSTOM LOGGER CLASS
            ////LOG
            //var config = new NLog.Config.LoggingConfiguration();

            //// Targets where to log to: File and Console
            //var logfile = new NLog.Targets.FileTarget("logfile") { FileName = @"C:\Users\josef\source\repos\josefernandoferreiragomes\LoanManagement\LogFiles\logfile2.txt" };
            //var logconsole = new NLog.Targets.ConsoleTarget("logconsole");

            //// Rules for mapping loggers to targets            
            //config.AddRule(LogLevel.Info, LogLevel.Fatal, logconsole);
            //config.AddRule(LogLevel.Debug, LogLevel.Fatal, logfile);

            //// Apply config           
            //NLog.LogManager.Configuration = config;
        }

        public List<Customer> GetCustomers()
        {
            LoggerHelper.GetLogger().Info(string.Format("{0}{1}", this.GetType(), System.Reflection.MethodInfo.GetCurrentMethod()));
            var query = from b in _dbContext.Customers.ToList<Customer>()
                        select b;
            return query.ToList();
        }

        public List<Customer> GetPageOfClassGeneric(int page, int pageSize, string nameFilter)
        {
            List<Customer> customersOut = new List<Customer>();
            
            LoggerHelper.GetLogger().Info(string.Format("Before DB Call {0}{1}", this.GetType(), System.Reflection.MethodInfo.GetCurrentMethod()));
            var query = _dbContext.Customers
                        .OrderBy(on => on.CustomerName)
                        .Where(c => c.CustomerName.Contains(nameFilter))
                        .Skip((page - 1) * pageSize)
                        .Take(pageSize);
            try
            {
                List<Customer> customers = query.ToList();                
                LoggerHelper.GetLogger().Info(string.Format("After DB Call {0}{1}{2}", customers.GetType(), System.Reflection.MethodInfo.GetCurrentMethod(), JsonSerializerHelper.SerializeToJson<List<Customer>>(customers)));
                
                //for temporary purposes, simplifying
                foreach (Customer custItem in customers)
                {
                    Customer tempCustomer = custItem;
                    tempCustomer.LoanList = new List<Loan>();
                    customersOut.Add(tempCustomer);
                }
            }
            catch (Exception exp)
            {
                throw exp;
            }
            finally
            {
                
            }
            return customersOut;
        }

        public Customer CreateCustomer(Customer customer)
        {
            _dbContext.Customers.Add(customer);
            _dbContext.SaveChanges();
            return customer;
        }

        public Customer UpdateCustomer(Customer customer)
        {
            _dbContext.Customers.AddOrUpdate(customer);
            _dbContext.SaveChanges();
            return customer;
        }

        public CustomerLoanInstallmentDBOut GetPageOfCustomerLoanInstallment(CustomerLoaInstallmentDBIn objIn)
        {
            CustomerLoanInstallmentDBOut objOut = new CustomerLoanInstallmentDBOut();


            objOut = _dbExecuter.CustomerInstallmentGetPage(objIn);

            return objOut;
        }
    }
}
