using SqlStringGenerator.MSSQL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class PersonalInfoTable : SccTable
    {
        public readonly MSSQL_Column PhoneNumber = new MSSQL_Column("phonenumber", "personal_info");

        public PersonalInfoTable() : base("personal_info") { }  

        public int Insert(DTO.PersonalInfo Info)
        {
            return MSSQL_Statements. 
                INSERT_INTO["personal_info"].VALUES(Info.AccountId, Info.FullName, Info.BirthDay, Info.PhoneNumber, Info.Gender).
                DISCONNECTED_EXECUTE(SccConnection.Conn).UPDATE();
        }
    }
}
