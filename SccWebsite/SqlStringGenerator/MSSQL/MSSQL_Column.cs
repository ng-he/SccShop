using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Runtime.InteropServices.WindowsRuntime;

namespace SqlStringGenerator.MSSQL
{
    public class MSSQL_Column : SelectableWithFrom
    {
        public string Name { get; }    
        public string TableName { get; }     

        public MSSQL_Column(string name, string tableName) : base(tableName + "." + name)
        {
            Name = name;
            TableName = tableName;
        }                    

        public string Join(MSSQL_Column Other)
        {
            return _sqlStr + "=" + Other._sqlStr + " ";
        }
    }
}
