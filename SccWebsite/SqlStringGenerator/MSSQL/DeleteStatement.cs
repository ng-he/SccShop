using SqlStringGenerator.MSSQL.DeleteComponents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlStringGenerator.MSSQL
{
    public class DeleteStatement
    {
        private StringBuilder DML_String;

        internal DeleteStatement()
        {
            DML_String = new StringBuilder(@"DELETE FROM ");
        }

        public ExtendableDeleteStatement this[string Table]
        {
            get
            {
                DML_String.Append(Table + " ");
                return new ExtendableDeleteStatement(DML_String);
            }
        }
    }
}
