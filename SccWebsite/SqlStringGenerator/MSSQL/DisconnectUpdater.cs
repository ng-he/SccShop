using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlStringGenerator.MSSQL
{
    public class DisconnectUpdater
    {
        private SqlDataAdapter _adapter;
        private DataTable _filledTable;

        public DisconnectUpdater(SqlDataAdapter adapter, DataTable filledTable)
        {
            _adapter = adapter;
            _filledTable = filledTable;
        }   

        public DataTable FilledTable() 
        { 
            return _filledTable; 
        }

        public SqlDataAdapter Adapter()
        {
            return _adapter;
        }

        public int UPDATE()
        {
            return _adapter.Update(_filledTable);
        }

        ~DisconnectUpdater() 
        { 
            _adapter.Dispose();
            _filledTable.Dispose();
        }
    }
}
