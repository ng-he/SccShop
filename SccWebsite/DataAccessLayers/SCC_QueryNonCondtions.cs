using SqlStringGenerator.MSSQL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class SCC_QueryNonConditions
    {
        private DataTable _result;

        internal SCC_QueryNonConditions(string TableName, params string[] SelObjes)
        {
            _result = MSSQL_Statements.SELECT[SelObjes].FROM[TableName].DISCONNECTED_QUERY(SccConnection.Conn);
        }

        internal SCC_QueryNonConditions(string TableName, params Selectable[] SelObjes)
        {
            _result = MSSQL_Statements.SELECT[SelObjes].FROM[TableName].DISCONNECTED_QUERY(SccConnection.Conn);
        }
        
        public DataTable GetData()
        {
            return _result;
        }
    }
}
