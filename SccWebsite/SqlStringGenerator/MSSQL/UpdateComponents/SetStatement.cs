using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlStringGenerator.MSSQL.UpdateComponents
{
    public class SetStatement
    {
        public SetComponent SET;

        internal SetStatement(StringBuilder EarlierDML_String)
        {
            SET = new SetComponent(EarlierDML_String);
        }
    }
}
