using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreCore.Repository
{
    public class DBContext
    {
        private SqlConnection myConnection;
        private string databaseName;


        public DBContext(string databaseName, string serverName, string userName, string password)
        {
            this.databaseName = databaseName;
            myConnection = new SqlConnection("Server =" + serverName + "; User ID = " 
                                             + userName + "; Pwd = " + password);
        }

        public SqlConnection DbConnection()
        {
            var databaseString = "CREATE DATABASE " + databaseName;
            var myCommand = new SqlCommand(databaseString, myConnection);
            
            try
            {
                myConnection.Open();
                if (!CheckIfDatabaseExist())
                {
                    myCommand.ExecuteNonQuery();
                    CreateTable("Product");
                }
            }
            catch (Exception)
            {
                    // ignored
            }
            return myConnection;
        }

        private void CloseConnection()
        {
            if (myConnection.State == ConnectionState.Open)
            {
                myConnection.Close();
            }
        }

        public void CreateTable(string tableName)
        {
            var productTabelString = "CREATE TABLE [dbo].['" + tableName + "']("
                                     + "[ID] [int] IDENTITY(1,1) NOT NULL,"
                                     + "[ProductName] [nvarchar](50) NOT NULL,"
                                     + "[Description] [nvarchar](max) NOT NULL,"
                                     + "[Stock] [int] NOT NULL,"
                                     + "[Price] [decimal](18, 2) NOT NULL,"
                                     + "[CategoryId] [int] NULL,"
                                     + ") ON [PRIMARY]";
            using (var cmd = new SqlCommand(productTabelString, myConnection))
            {
                cmd.ExecuteNonQuery();
            }
        }
        private bool CheckIfDatabaseExist()
        {
            var str = "SELECT db_id('" + databaseName + "')";
            using (var command = new SqlCommand(str, myConnection))
            {
                return (command.ExecuteScalar() != DBNull.Value);
            }
        }

    }
}
