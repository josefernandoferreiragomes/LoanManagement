CREATE TABLE [dbo].[Installments] (
    [InstallmentId] INT             IDENTITY (1, 1) NOT NULL,
    [LoanId]        INT             NOT NULL,
    [Installment]   DECIMAL (15, 5) NOT NULL,
    CONSTRAINT [FK_Installments_Loans] FOREIGN KEY ([LoanId]) REFERENCES [dbo].[Loans] ([LoanId])
);

