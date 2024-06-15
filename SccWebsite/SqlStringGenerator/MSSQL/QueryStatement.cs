using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SqlStringGenerator.MSSQL.BuiltInFunction;

namespace SqlStringGenerator.MSSQL.QueryComponents
{
    public class QueryStatement
    {
        private StringBuilder QueryString;

        internal QueryStatement() 
        { 
            QueryString = new StringBuilder(@"SELECT ");
        }    

        public FromStatement this[params string[] Columns]
        {
            get
            {
                foreach(string Column in Columns)
                {
                    QueryString.Append(Column + ","); 
                }

                QueryString[QueryString.Length - 1] = ' ';

                return new FromStatement(QueryString);
            }
        }

        public FromStatement this[params Selectable[] SelObjes]
        {
            get
            {
                foreach (Selectable SelObj in SelObjes)
                {
                    QueryString.Append(SelObj.SqlStr + ",");
                }

                QueryString[QueryString.Length - 1] = ' ';

                return new FromStatement(QueryString);
            }
        }

        public ExecutableQuery this[params SelectableWithoutFrom[] SelObjes]
        {
            get
            {
                foreach (SelectableWithoutFrom SelObj in SelObjes)
                {
                    QueryString.Append(SelObj.SqlStr + ",");
                }

                QueryString[QueryString.Length - 1] = ' ';

                return new ExecutableQuery(QueryString);
            }
        }
    }
}
