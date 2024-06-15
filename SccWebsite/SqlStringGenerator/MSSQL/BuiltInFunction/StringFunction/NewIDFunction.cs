using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlStringGenerator.MSSQL.BuiltInFunction.StringFunction
{
    public class NewIDFunction : SelectableWithoutFrom
    {
        public NewIDFunction() : base("NEWID()") { }  
    }
}
