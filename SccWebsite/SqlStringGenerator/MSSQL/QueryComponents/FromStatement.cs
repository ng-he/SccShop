using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlStringGenerator.MSSQL.QueryComponents
{
    public class FromStatement
    {
        public FromComponent FROM;

        internal FromStatement(StringBuilder QueryString) 
        { 
            FROM = new FromComponent(QueryString);
        }
    }
}
