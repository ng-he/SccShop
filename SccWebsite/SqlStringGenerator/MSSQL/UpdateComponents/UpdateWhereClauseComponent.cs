using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlStringGenerator.MSSQL.UpdateComponents
{
    public class UpdateWhereClauseComponent : ExecutableDML
    {
        internal UpdateWhereClauseComponent(StringBuilder EarlierDML_String, string Conditions) : base(EarlierDML_String)
        {
            ExecutableDML_String.Append(@" WHERE " + Conditions);
        }
    }
}
