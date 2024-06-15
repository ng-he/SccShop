using SqlStringGenerator.MSSQL.BuiltInFunction;
using SqlStringGenerator.MSSQL.BuiltInFunction.StringFunction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlStringGenerator.MSSQL
{
    public class SystemFunctions
    {
        /// <summary>
        /// Build in function LEFT
        /// </summary>
        /// <param name="Expr"></param>
        /// <param name="Length"></param>
        /// <returns></returns>
        static public LeftFunction LEFT(string Expr, int Length)
        {
            return new LeftFunction(Expr, Length);
        }

        static public LeftFunction LEFT(SelectableWithoutFrom SelObj, int Length)
        {
            return new LeftFunction(SelObj, Length);
        }

        static public LeftFunction.WithColumnParams LEFT(SelectableWithFrom SelObj, int Length)
        {
            return new LeftFunction.WithColumnParams(SelObj, Length);
        }

        /// <summary>
        /// Built in function REPLACE
        /// </summary>
        /// <param name="Expr"></param>
        /// <param name="Search"></param>
        /// <param name="Replacement"></param>
        /// <returns></returns>
        static public ReplaceFunction REPLACE(string Expr, string Search, string Replacement) 
        {
            return new ReplaceFunction(Expr, Search, Replacement);
        }

        static public ReplaceFunction REPLACE(SelectableWithoutFrom SelObj, string Search, string Replacement)
        {
            return new ReplaceFunction(SelObj, Search, Replacement);
        }

        static public ReplaceFunction.WithColumnParams REPLACE(SelectableWithFrom SelObj, string Search, string Replacement)
        {
            return new ReplaceFunction.WithColumnParams(SelObj, Search, Replacement);
        }

        /// <summary>
        /// Built in function NEWID
        /// </summary>
        /// <returns></returns>
        static public NewIDFunction NEWID() 
        {
            return new NewIDFunction();
        }
    }
}
