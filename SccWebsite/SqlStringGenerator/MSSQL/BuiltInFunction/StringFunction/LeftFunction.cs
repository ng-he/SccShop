using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlStringGenerator.MSSQL.BuiltInFunction.StringFunction
{
    public class LeftFunction : SelectableWithoutFrom
    {
        public LeftFunction(string Expr, int Length) :
            base("LEFT(" + Expr + "," + Length.ToString() + ")") { }

        public LeftFunction(SelectableWithoutFrom SelObj, int Length) 
            : base("LEFT(" + SelObj.SqlStr + "," + Length.ToString() + ")") { }

        public class WithColumnParams : SelectableWithFrom
        {
            public WithColumnParams(SelectableWithFrom SelObj, int Length) 
                : base("LEFT(" + SelObj.SqlStr + "," + Length.ToString() + ")") { }
        }
    }
}
