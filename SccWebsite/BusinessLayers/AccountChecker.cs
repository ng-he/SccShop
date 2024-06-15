using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Reflection.Emit;

namespace BUS
{
    public class AccountChecker
    {
        // If existed "Username" in account, return password and role
        static public string[] UsernameExist(string UsernameStr)
        {
            DAL.AccountTable AccountTbl = DAL.SccTables.Account;

            DataTable AccList = 
                AccountTbl.Select("*").
                Where (
                    AccountTbl.Username.Eq(UsernameStr)
                );

            string[] Result = new string[2] {"", ""};

            if(AccList.Rows.Count > 0)
            {
                Result[0] = AccList.Rows[0].Field<string>("account_password");
                Result[1] = AccList.Rows[0].Field<string>("account_role");
            }

            return Result;
        }

        static public bool EmailExist(string EmailStr)
        {
            DAL.AccountTable AccountTbl = DAL.SccTables.Account;
            return 
                AccountTbl.Select("*").
                Where (
                    AccountTbl.Email.Eq(EmailStr)
                )
                .Rows.Count > 0;
        }
    }
}
