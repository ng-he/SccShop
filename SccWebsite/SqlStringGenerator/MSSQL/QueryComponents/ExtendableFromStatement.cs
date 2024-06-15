using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;

namespace SqlStringGenerator.MSSQL.QueryComponents
{
    public class ExtendableFromStatement : ExecutableQuery
    {
        internal ExtendableFromStatement(StringBuilder EarlierQueryString) : base(EarlierQueryString) { }

        public WhereClauseComponent WHERE(string Conditions)
        {
            return new WhereClauseComponent(ExecutableQueryString, Conditions);
        }
    }
}
