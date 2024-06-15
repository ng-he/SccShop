using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlStringGenerator.MSSQL.InsertComponents
{
    public class ExtendableInsertStatement
    {
        private StringBuilder DML_String;
        internal ExtendableInsertStatement(StringBuilder EarlierDML_String) 
        { 
            DML_String = EarlierDML_String;
        }    

        public OnColumnsComponent this[params string[] Columns]
        {
            get
            {
                return new OnColumnsComponent(DML_String, Columns);
            }
        }

        public ValuesComponent VALUES(params object[] Values) 
        { 
            return new ValuesComponent(DML_String, Values);
        }

        public ValuesComponent VALUES(string valuesStr, bool useStr)
        {
            return new ValuesComponent(DML_String, valuesStr, useStr);
        }
    }
}
