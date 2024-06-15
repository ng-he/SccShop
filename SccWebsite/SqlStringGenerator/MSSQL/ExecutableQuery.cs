using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace SqlStringGenerator.MSSQL
{
    public class ExecutableQuery
    {
        protected internal StringBuilder ExecutableQueryString;

        internal ExecutableQuery(StringBuilder QueryString) 
        { 
            ExecutableQueryString = QueryString;
        }

        public SqlDataReader CONNECTED_QUERY(SqlConnection Conn)
        {
            Conn.Open();
            SqlCommand Command = new SqlCommand(ExecutableQueryString.ToString(), Conn);
            SqlDataReader Result = Command.ExecuteReader();
            Conn.Close();
            
            return Result;
        }

        public DataTable DISCONNECTED_QUERY(SqlConnection Conn)
        {
            DataTable Result = new DataTable();
            using (SqlDataAdapter Adapter = new SqlDataAdapter(ExecutableQueryString.ToString(), Conn))
            {
                Adapter.Fill(Result);
                Result.AcceptChanges();
            }
           
            return Result;
        }

        public override string ToString()
        {
            return ExecutableQueryString.ToString();
        }
    }
}
