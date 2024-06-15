using SqlStringGenerator.MSSQL.UpdateComponents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlStringGenerator.MSSQL.UpdateComponents
{
    public class SetComponent
    {
        private StringBuilder DML_String;

        internal SetComponent(StringBuilder EarlierDML_String)
        {
            DML_String = EarlierDML_String;
            DML_String.Append(@"SET ");
        }

        public ExtendableSetStatement this[params string[] Exprs]
        {
            get
            {
                foreach (string Expr in Exprs)
                {
                    DML_String.Append(Expr + ",");
                }

                DML_String[DML_String.Length - 1] = ' ';

                return new ExtendableSetStatement(DML_String);
            }
        }
    }
}
