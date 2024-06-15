using SqlStringGenerator.MSSQL;
using SqlStringGenerator.MSSQL.QueryComponents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlStringGenerator.MSSQL.UpdateComponents
{
    public class ExtendableSetStatement : ExecutableDML 
    {
        internal ExtendableSetStatement(StringBuilder EarlierDML_String) : base(EarlierDML_String) { }

        public UpdateWhereClauseComponent WHERE(string Conditions)
        {
            return new UpdateWhereClauseComponent(ExecutableDML_String, Conditions);
        }
    }
}
