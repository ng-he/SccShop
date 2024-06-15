using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlStringGenerator.MSSQL
{
    public class SelectableWithoutFrom : Selectable
    {
        public SelectableWithoutFrom(string SqlStr) : base(SqlStr) { }  

        public SelectableWithoutFrom AS(string Title)
        {
            return new SelectableWithoutFrom(SqlStr + " AS [" +  Title + "]");
        }
    }
}
