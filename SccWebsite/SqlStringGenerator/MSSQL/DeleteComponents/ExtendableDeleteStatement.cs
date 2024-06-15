using SqlStringGenerator.MSSQL.UpdateComponents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlStringGenerator.MSSQL.DeleteComponents
{
    public class ExtendableDeleteStatement : ExecutableDML
    {
        internal ExtendableDeleteStatement(StringBuilder EarlierDML_String) : base(EarlierDML_String) { }

        public UpdateWhereClauseComponent WHERE(string Conditions)
        {
            return new UpdateWhereClauseComponent(ExecutableDML_String, Conditions);
        }
    }
}
