using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace BUS
{
    public class InfoChecker
    {
        static public bool PhoneNumberExist(string PhoneNumberStr)
        {
            DAL.PersonalInfoTable PersonalInfo = DAL.SccTables.PersonalInfo;

            return 
                PersonalInfo.Select("*").
                Where (
                    PersonalInfo.PhoneNumber.Eq(PhoneNumberStr)
                ).
                Rows.Count > 0;
        }
    }
}
