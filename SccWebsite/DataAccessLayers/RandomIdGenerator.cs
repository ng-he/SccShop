using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using SqlStringGenerator.MSSQL;

namespace DAL
{
    public class RandomIdGenerator : MSSQL_Statements
    {
        static public string Get(int Length)
        {
            return 
                SELECT[LEFT(REPLACE(NEWID(), "-", ""), Length).AS("ID")].
                DISCONNECTED_QUERY(SccConnection.Conn).Rows[0].Field<string>("ID");
        }
    }
}
