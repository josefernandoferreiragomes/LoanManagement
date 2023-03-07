CREATE PROCEDURE [dbo].[SpGetPageOfCustomerInstalmentsRowNumber]
	@CustomerId int=0,
	@PageSize int=2,
	@LastPageLastRowId int=0
AS
	BEGIN
		;with cte as(
		SELECT cust.CustomerId, cust.CustomerName, ln.LoanDescription, inst.Installment, inst.InstallmentId, ROW_NUMBER() OVER (ORDER BY inst.InstallmentId) AS RowId
		FROM Installments inst INNER JOIN Loans ln ON inst.LoanId = ln.LoanId INNER JOIN Customers cust ON ln.Customer_CustomerId=cust.CustomerId
		WHERE cust.CustomerId=@CustomerId OR @CustomerId =0
		)
	

		select * from cte WHERE RowId BETWEEN @LastPageLastRowId+1 AND @LastPageLastRowId+@PageSize
	END
	

RETURN 0
