using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlStringGenerator.MSSQL.QueryComponents
{
    public class WhereClauseComponent : ExecutableQuery
    {
        internal WhereClauseComponent(StringBuilder EarlierQueryString, string Conditions) : base(EarlierQueryString)
        { 
            ExecutableQueryString.Append(@"WHERE " + Conditions);
        } 
    }
}
