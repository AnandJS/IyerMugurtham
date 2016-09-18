using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.IO;

namespace Mugurtham.Common.Utilities
{
    [MugurthamBaseAPIController]
    public static class ADODBHelper
    {
        //http://csharp.net-informations.com/dataadapter/updatecommand-sqlserver.htm

        public static void getDataSet()
        {
            try
            {

            }
            catch (Exception objEx)
            {
                Helpers.LogExceptionInFlatFile(objEx);
            }
        }

        public static void getDataSet1()
        {

            string connetionString = null;
            SqlConnection connection;
            SqlCommand command;
            SqlDataAdapter adapter = new SqlDataAdapter();
            DataSet ds = new DataSet();
            int i = 0;
            string firstSql = null;
            string secondSql = null;

            connetionString = "data source=103.235.104.24;initial catalog=VishwakarmaMugurtham;user id=VishwakarmaMugurthamAdmin;password=Swingsys@!1";
            firstSql = "Select * from portaluser";
            secondSql = "Select * from profilebasicinfo";
            connection = new SqlConnection(connetionString);


            //SqlDataAdapter objUpdateadapter = new SqlDataAdapter();
            string strSQL = string.Empty;
            try
            {
                connection.Open();

                command = new SqlCommand(firstSql, connection);
                adapter.SelectCommand = command;
                adapter.Fill(ds, "First Table");

                adapter.SelectCommand.CommandText = secondSql;
                adapter.Fill(ds, "Second Table");

                adapter.Dispose();
                command.Dispose();
                connection.Close();

                //retrieve first table data 
                for (i = 0; i <= ds.Tables[0].Rows.Count - 1; i++)
                {
                    //MessageBox.Show(ds.Tables[0].Rows[i].ItemArray[0] + " -- " + ds.Tables[0].Rows[i].ItemArray[1]);
                    //Helpers.LogMessage(ds.Tables[0].Rows[i].ItemArray[3] + " -- " + Helpers.EncodePasswordToBase64(ds.Tables[0].Rows[i].ItemArray[3].ToString()));


                    //updateData(ds.Tables[0].Rows[i].ItemArray[2].ToString(), Helpers.EncodePasswordToBase64(ds.Tables[0].Rows[i].ItemArray[3].ToString()));

                    strSQL = "update portaluser set password = '" + Helpers.EncodePasswordToBase64(ds.Tables[0].Rows[i].ItemArray[3].ToString()) + "' where loginid = '" + ds.Tables[0].Rows[i].ItemArray[2].ToString() + "'";

                    Helpers.LogMessageInFlatFile1(strSQL);

                    //objUpdateadapter.UpdateCommand = connection.CreateCommand();
                    //objUpdateadapter.UpdateCommand.CommandText = strSQL;
                    //objUpdateadapter.UpdateCommand.ExecuteNonQuery();

                }
                //objUpdateadapter.Dispose();
                //retrieve second table data 
                for (i = 0; i <= ds.Tables[1].Rows.Count - 1; i++)
                {
                    //MessageBox.Show(ds.Tables[1].Rows[i].ItemArray[0] + " -- " + ds.Tables[1].Rows[i].ItemArray[1]);

                }


            }
            catch (Exception objEx)
            {
                Helpers.LogExceptionInFlatFile(objEx);
            }
        }

        private static void updateData(string strLoginID, string strHashedPwdText)
        {
            string connetionString = null;
            SqlConnection connection;
            SqlDataAdapter adapter = new SqlDataAdapter();
            string sql = null;
            connetionString = "data source=103.235.104.24;initial catalog=VishwakarmaMugurtham;user id=VishwakarmaMugurthamAdmin;password=Swingsys@!1";
            connection = new SqlConnection(connetionString);
            sql = "update portaluser set password = '" + strHashedPwdText + "' where loginid = '" + strLoginID + "'";
            try
            {
                connection.Open();
                adapter.UpdateCommand = connection.CreateCommand();
                adapter.UpdateCommand.CommandText = sql;
                adapter.UpdateCommand.ExecuteNonQuery();
                //MessageBox.Show("Row updated !! ");

            }
            catch (Exception objEx)
            {
                Helpers.LogExceptionInFlatFile(objEx);
            }
        }
    }
}
