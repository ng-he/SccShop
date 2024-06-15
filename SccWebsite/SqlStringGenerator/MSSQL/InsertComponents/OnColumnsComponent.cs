using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlStringGenerator.MSSQL.InsertComponents
{
    public class OnColumnsComponent
    {
        private StringBuilder DML_String;

        internal OnColumnsComponent(StringBuilder EarlierDML_String, params string[] Columns)
        {
            DML_String = EarlierDML_String;

            DML_String.Append("(");

            foreach (string Column in Columns) 
            {
                DML_String.Append(Column + ",");
            }

            DML_String[DML_String.Length - 1] = ')';
        }

        public ValuesComponent VALUES(params object[] Values)
        {
            return new ValuesComponent(DML_String, Values);
        }

    }
}
