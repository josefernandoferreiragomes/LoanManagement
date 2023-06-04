using LoanManagement.DB.Data;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanManagement.DB.Dao
{
    public class LoanManagementDBContext: DbContext
    {

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Loan> Loans { get; set; }

        public DbSet<Installment> Installments { get; set; }

        public LoanManagementDBContext() : base("name=LoanManagement.DB.Dao.LoanManagementDBContext") 
        {
            Database.SetInitializer<LoanManagementDBContext>(new CreateDatabaseIfNotExists<LoanManagementDBContext>());
            
            //for reset purposes
            //Database.SetInitializer<LoanManagementDBContext>(new DropCreateDatabaseAlways<LoanManagementDBContext>());

        }

        protected override void OnModelCreating(System.Data.Entity.DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Loan>().Property(loan => loan.LoanValue).HasPrecision( 15,5);
            
            modelBuilder.Entity<Installment>().Property(installment => installment.InstallmentValue).HasPrecision(15, 5);
          
        }
    }
}
