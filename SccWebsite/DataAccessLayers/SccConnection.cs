using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using System.Net.Configuration;
using System.Configuration;

namespace DAL
{
    internal class SccConnection
    {
        static internal SqlConnection Conn = new SqlConnection(
            "Data Source=DESKTOP-REV151O\\MSSQLSERVER2022;Initial Catalog=scc_management;Integrated Security=True"
            );
    }
}
