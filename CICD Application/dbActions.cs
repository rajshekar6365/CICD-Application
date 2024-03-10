using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace CICD_Application
{
    public class dbActions
    {
        string conString = "data source=.;initial catalog=CICDDb;Integrated security=True";
        SqlConnection sqlConnection;

        public dbActions() { 
            sqlConnection = new SqlConnection();
            sqlConnection.ConnectionString = conString;
            sqlConnection.Open();

        }
        public void InsertUser(string insertQuery)
        {
            SqlCommand cmd = sqlConnection.CreateCommand();
            cmd.Connection = sqlConnection;
            cmd.CommandType = CommandType.Text; 
            cmd.CommandText = insertQuery;
            int rec = cmd.ExecuteNonQuery();
        }
        public bool ValidateUser(string validateQuery)
        {
            SqlDataReader sqlRdr;
            SqlCommand cmd = sqlConnection.CreateCommand();
            cmd.Connection = sqlConnection;
            cmd.CommandType = CommandType.Text; 
            cmd.CommandText = validateQuery;
            sqlRdr = cmd.ExecuteReader();
            if (sqlRdr.Read())
                return true;
            else
                return false;
        }
    }
}
