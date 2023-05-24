﻿using LoanManagement.DB.Dao;
using LoanManagement.DB.DaoSqlExecuters;
using LoanManagement.DB.Data;
using LoanManagement.DB.Interfaces;
using NLog;
using NLog.Config;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Metadata.Edm;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanManagement.DB.Repositories
{
    public class DBLoanManagerRepository : IDBLoanManagerRepository
    {
        private static readonly NLog.Logger Logger = NLog.LogManager.GetCurrentClassLogger();   
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
            //TO BE MOVED TO A CUSTOM LOGGER CLASS
            //LOG
            var config = new NLog.Config.LoggingConfiguration();

            // Targets where to log to: File and Console
            var logfile = new NLog.Targets.FileTarget("logfile") { FileName = @"C:\Users\josef\source\repos\josefernandoferreiragomes\LoanManagement\LogFiles\logfile.txt" };
            var logconsole = new NLog.Targets.ConsoleTarget("logconsole");

            // Rules for mapping loggers to targets            
            config.AddRule(LogLevel.Info, LogLevel.Fatal, logconsole);
            config.AddRule(LogLevel.Debug, LogLevel.Fatal, logfile);

            // Apply config           
            NLog.LogManager.Configuration = config;
        }

        public List<Customer> GetCustomers()
        {
            var query = from b in _dbContext.Customers.ToList<Customer>()
                        select b;
            return query.ToList();
        }

        public List<Customer> GetPageOfClassGeneric(int page, int pageSize, string nameFilter)
        {
            Logger.Info("GetPageOfClassGeneric");
            var query = _dbContext.Customers
                        .OrderBy(on=>on.CustomerName)
                        .Where(c => c.CustomerName.Contains(nameFilter))
                        .Skip((page-1)*pageSize)
                        .Take(pageSize);
            List<Customer> customers = query.ToList();
            List<Customer> customersOut = new List<Customer>();
            foreach (Customer custItem in customers)
            {
                Customer tempCustomer = custItem;
                tempCustomer.LoanList = new List<Loan>();
                customersOut.Add(tempCustomer);
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