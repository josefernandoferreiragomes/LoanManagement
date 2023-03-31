using LoanManagement.DB.Data;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanManagement.DB.DaoSqlExecuters
{
    public class LoanManagementDBExecuter
    {
        SqlConnection sqlCon = null;
        String SqlconString = ConfigurationManager.ConnectionStrings["LoanManagementDB"].ConnectionString;
        public CustomerLoanInstallmentDBOut CustomerInstallmentGetPage(CustomerLoaInstallmentDBIn objIn)
        {
            CustomerLoanInstallmentDBOut ObjDbOut =new CustomerLoanInstallmentDBOut();
            ObjDbOut.ListOfItems = new List<CustomerLoanInstallmentDBOutItem>();

            
            using (sqlCon = new SqlConnection(SqlconString))
            {
                try
                {
                    sqlCon.Open();
                    SqlCommand sql_cmnd = new SqlCommand("SpGetPageOfCustomerInstalments", sqlCon);
                    sql_cmnd.CommandType = CommandType.StoredProcedure;
                    sql_cmnd.Parameters.AddWithValue("@CustomerId", SqlDbType.NVarChar).Value = objIn.CustomerId;
                    sql_cmnd.Parameters.AddWithValue("@PageSize", SqlDbType.NVarChar).Value = objIn.PageSize;
                    sql_cmnd.Parameters.AddWithValue("@LastPageLastInstallmentId", SqlDbType.Int).Value = objIn.LastPageLastInstallmentId;
                    SqlDataReader reader = sql_cmnd.ExecuteReader();

                    while (reader.Read())
                    {
                        CustomerLoanInstallmentDBOutItem item = new CustomerLoanInstallmentDBOutItem();
                        item.InstallmentId = (int)reader["CustomerId"];
                        item.CustomerName = (string)reader["CustomerName"];
                        item.LoanDescription = (string)reader["LoanDescription"];
                        item.InstallmentValue = (decimal)reader["InstallmentValue"];
                        item.InstallmentId = (int)reader["InstallmentId"];
                        ObjDbOut.ListOfItems.Add(item);
                    }

                }
                catch (Exception ex)
                {
                    //TODO Error handling
                    throw ex;
                }
                finally
                {
                    sqlCon.Close();
                }
            }
            return ObjDbOut;
        }
    }
}
