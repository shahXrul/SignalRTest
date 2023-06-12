using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoaderTest
{
    internal class QueryRunner
    {
        public void RunMe()
        {
            //string connectionString = "data source=SSHAHUL1-MOBL1;User Id=sshahul1;Password=P@ssw0rd123;initial catalog=QuEST;persist security info=True;integrated security=False;multipleactiveresultsets=True;application name=Quest";
            //using (SqlConnection conn = new SqlConnection(connectionString))
            //{
            //    try
            //    {
            //        SqlCommand cmd = new SqlCommand("test_one_sp", conn);
            //        cmd.CommandText = "test_one_sp";
            //        cmd.CommandType = CommandType.StoredProcedure;
            //        // Add any required parameters here
            //        var returnParameter = cmd.Parameters.Add("@ReturnVal", SqlDbType.Int);
            //        returnParameter.Direction = ParameterDirection.ReturnValue;
            //        conn.Open();
            //        cmd.ExecuteNonQuery();
            //        var result = (int)returnParameter.Value;
            //        Console.WriteLine(result) ;
            //    }
            //    catch (Exception)
            //    {

            //        throw;
            //    }

            //}
        }

        public void RunMeInsert()
        {
            //string connectionString = "data source=SSHAHUL1-MOBL1;User Id=sshahul1;Password=P@ssw0rd123;initial catalog=QuEST;persist security info=True;integrated security=False;multipleactiveresultsets=True;application name=Quest";
            //using (SqlConnection conn = new SqlConnection(connectionString))
            //{
            //    try
            //    {
            //        SqlCommand cmd = new SqlCommand("test_one_insert_sp", conn);
            //        cmd.CommandType = CommandType.StoredProcedure;
            //        // Add any required parameters here
            //        var returnParameter = cmd.Parameters.Add("@ReturnVal", SqlDbType.Int);
            //        returnParameter.Direction = ParameterDirection.ReturnValue;
            //        conn.Open();
            //        cmd.ExecuteNonQuery();
            //        var result = (int)returnParameter.Value;
            //        Console.WriteLine(result);
            //    }
            //    catch (Exception)
            //    {

            //        throw;
            //    }

            //}
        }
    }
}
