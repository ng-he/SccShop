using SqlStringGenerator.MSSQL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class SccTable
    {
        public string TableName { get; set; }   

        public SccTable(string TableName)
        {
            this.TableName = TableName;
        }   

        public DataTable SelectNonConditions(params string[] SelObjes)
        {
            return (new SCC_QueryNonConditions(TableName, SelObjes)).GetData();
        }

        public DataTable SelectNonConditions(params Selectable[] SelObjes)
        {
            return (new SCC_QueryNonConditions(TableName, SelObjes)).GetData();
        }

        public SCC_QueryWithConditions Select(params string[] SelObjes)
        {
            return (new SCC_QueryWithConditions(TableName, SelObjes));
        }

        public SCC_QueryWithConditions Select(params Selectable[] SelObjes)
        {
            return (new SCC_QueryWithConditions(TableName, SelObjes));
        }
    }
}
