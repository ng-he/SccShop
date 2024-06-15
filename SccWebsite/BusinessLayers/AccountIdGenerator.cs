using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class AccountIdGenerator
    {
        public static string NewUserID()
        {
            return "USER" + DAL.RandomIdGenerator.Get(4);
        }

        public static string NewAdminID()
        {
            return "AD" + DAL.RandomIdGenerator.Get(4);
        }
    }
}
