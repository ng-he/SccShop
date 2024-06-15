using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlStringGenerator.MSSQL
{
    public class ExecutableDML
    {
        protected internal StringBuilder ExecutableDML_String;

        internal ExecutableDML(StringBuilder DMLString)
        {
            ExecutableDML_String = DMLString;
        }

        public int CONNECTED_EXECUTE(SqlConnection Conn)
        {
            Conn.Open();
            SqlCommand Command = new SqlCommand(ExecutableDML_String.ToString(), Conn);
            int Result = Command.ExecuteNonQuery();
            Conn.Close();
            
            return Result;
        }

        public DisconnectUpdater DISCONNECTED_EXECUTE(SqlConnection Conn)
        { 
            SqlDataAdapter Adapter = new SqlDataAdapter(ExecutableDML_String.ToString(), Conn);
            DataTable Tmp = new DataTable();
            Adapter.Fill(Tmp);
            Tmp.AcceptChanges();

            return new DisconnectUpdater(Adapter, Tmp);
        }

        public override string ToString()
        {
            return ExecutableDML_String.ToString();
        }
    }
}
