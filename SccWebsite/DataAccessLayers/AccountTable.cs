using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using SqlStringGenerator.MSSQL;

namespace DAL
{
    public class AccountTable : SccTable
    {
        public readonly MSSQL_Column Username = new MSSQL_Column("account_username", "account");
        public readonly MSSQL_Column Email = new MSSQL_Column("account_email", "account");

        public AccountTable() : base("account") { }

        public int Insert(DTO.Account Acc)
        {
            return MSSQL_Statements.
                INSERT_INTO["account"].VALUES(Acc.Id, Acc.Username, Acc.Email, Acc.Password, Acc.Role, false).
                DISCONNECTED_EXECUTE(SccConnection.Conn).UPDATE();
        }
    }
}
