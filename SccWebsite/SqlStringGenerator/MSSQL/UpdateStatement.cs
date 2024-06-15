using SqlStringGenerator.MSSQL.UpdateComponents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlStringGenerator.MSSQL
{
    public class UpdateStatement
    {
        private StringBuilder DML_String;

        internal UpdateStatement()
        {
            DML_String = new StringBuilder(@"UPDATE ");
        }

        public SetStatement this[string Table]
        {
            get
            {
                DML_String.Append(Table + " ");
                return new SetStatement(DML_String);
            }
        }
    }
}
