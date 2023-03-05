-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE SpGetPageOfCustomerInstalments
	@CustomerId int
	, @PageSize int=2
	,@LastPageLastInstallmentId int=0
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    SELECT cust.CustomerId, cust.CustomerName, ln.LoanDescription, inst.Installment, inst.InstallmentId
	FROM Installments inst INNER JOIN Loans ln ON inst.LoanId = ln.LoanId INNER JOIN Customers cust ON ln.Customer_CustomerId=cust.CustomerId
	WHERE cust.CustomerId=@CustomerId
	AND inst.InstallmentId > @LastPageLastInstallmentId
	ORDER BY inst.InstallmentId OFFSET 0 ROWS FETCH NEXT 2 ROWS ONLY
END
