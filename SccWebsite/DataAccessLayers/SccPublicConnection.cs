using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class SccPublicConnection
    {
        static public readonly SqlConnection Conn = new SqlConnection(
           "Data Source=DESKTOP-REV151O\\MSSQLSERVER2022;Initial Catalog=scc_management;Integrated Security=True"
        );
    }
}