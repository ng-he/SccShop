using SqlStringGenerator.MSSQL.InsertComponents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlStringGenerator.MSSQL
{
    public class InsertStatement
    {
        private StringBuilder DML_String;

        internal InsertStatement() 
        { 
            DML_String = new StringBuilder(@"INSERT INTO ");
        }  

        public ExtendableInsertStatement this[string Table]
        {
            get
            {
                DML_String.Append(Table + " ");
                return new ExtendableInsertStatement(DML_String);
            }
        }
    }
}
