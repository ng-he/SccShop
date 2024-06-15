using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlStringGenerator.MSSQL.QueryComponents
{
    public class FromComponent
    {
        private StringBuilder QueryString;

        internal FromComponent(StringBuilder EarlierQueryString) 
        { 
            QueryString = EarlierQueryString;
            QueryString.Append(@"FROM ");
        }

        public ExtendableFromStatement this[params string[] Tables]
        {
            get
            {
                foreach(string Table in Tables) 
                { 
                    QueryString.Append(Table + ",");
                }

                QueryString[QueryString.Length - 1] = ' ';

                return new ExtendableFromStatement(QueryString);
            }
        }
    }
}
