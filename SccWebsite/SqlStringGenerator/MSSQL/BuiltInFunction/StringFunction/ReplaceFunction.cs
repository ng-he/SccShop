using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlStringGenerator.MSSQL.BuiltInFunction.StringFunction
{
    public class ReplaceFunction : SelectableWithoutFrom
    {
        public ReplaceFunction(string Expr, string Seach, string Replacement) :
            base("REPLACE(" + Expr + ",'" + Seach + "','" + Replacement + "')") { }

        public ReplaceFunction(SelectableWithoutFrom SelObj, string Seach, string Replacement) :
            base("REPLACE(" + SelObj.SqlStr + ",'" + Seach + "','" + Replacement + "')") { }

        public class WithColumnParams : SelectableWithFrom
        {
            public WithColumnParams(SelectableWithFrom SelObj, string Seach, string Replacement)
                : base("REPLACE(" + SelObj.SqlStr + ",'" + Seach + "','" + Replacement + "')") { }
        }
    }
}
