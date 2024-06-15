using SqlStringGenerator.MSSQL;
using SqlStringGenerator.MSSQL.QueryComponents;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class SCC_QueryWithConditions
    {
        private ExtendableFromStatement _query;

        internal SCC_QueryWithConditions(string TableName, params string[] SelObjes)
        {
            _query = MSSQL_Statements.SELECT[SelObjes].FROM[TableName];
        }

        internal SCC_QueryWithConditions(string TableName, params Selectable[] SelObjes)
        {
            _query = MSSQL_Statements.SELECT[SelObjes].FROM[TableName];
        }

        public DataTable Where(string Conditions)
        {
            return _query.WHERE(Conditions).DISCONNECTED_QUERY(SccConnection.Conn);
        }
    }
}
