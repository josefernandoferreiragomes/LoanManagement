namespace LoanManagement.DB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        CustomerId = c.Int(nullable: false, identity: true),
                        CustomerName = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.CustomerId);
            
            CreateTable(
                "dbo.Loans",
                c => new
                    {
                        LoanId = c.Int(nullable: false, identity: true),
                        LoanDescription = c.String(),
                        LoanValue = c.Decimal(nullable: false, precision: 15, scale: 5),
                        Customer_CustomerId = c.Int(),
                    })
                .PrimaryKey(t => t.LoanId)
                .ForeignKey("dbo.Customers", t => t.Customer_CustomerId)
                .Index(t => t.Customer_CustomerId);
            
            CreateTable(
                "dbo.Installments",
                c => new
                    {
                        InstallmentId = c.Int(nullable: false, identity: true),
                        InstallmentValue = c.Decimal(nullable: false, precision: 15, scale: 5),
                        Loan_LoanId = c.Int(),
                    })
                .PrimaryKey(t => t.InstallmentId)
                .ForeignKey("dbo.Loans", t => t.Loan_LoanId)
                .Index(t => t.Loan_LoanId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Installments", "Loan_LoanId", "dbo.Loans");
            DropForeignKey("dbo.Loans", "Customer_CustomerId", "dbo.Customers");
            DropIndex("dbo.Installments", new[] { "Loan_LoanId" });
            DropIndex("dbo.Loans", new[] { "Customer_CustomerId" });
            DropTable("dbo.Installments");
            DropTable("dbo.Loans");
            DropTable("dbo.Customers");
        }
    }
}
