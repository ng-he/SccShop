using SqlStringGenerator.MSSQL.QueryComponents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SqlStringGenerator.MSSQL
{
    public class MSSQL_Statements : SystemFunctions
    {
        static public QueryStatement SELECT { get { return new QueryStatement(); } }
        static public InsertStatement INSERT_INTO { get { return new InsertStatement(); } }
        static public UpdateStatement UPDATE { get {  return new UpdateStatement(); } }
        static public DeleteStatement DELETE_FROM { get {  return new DeleteStatement(); } }
    }
}
