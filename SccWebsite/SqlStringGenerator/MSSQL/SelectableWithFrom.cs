using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlStringGenerator.MSSQL
{
    public class SelectableWithFrom : Selectable
    {
        public SelectableWithFrom(string SqlStr) : base(SqlStr) { }

        public SelectableWithFrom AS(string Title)
        {
            return new SelectableWithFrom(SqlStr + " AS [" +  Title + "]");
        }
    }
}
