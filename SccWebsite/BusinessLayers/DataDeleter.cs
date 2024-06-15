using SqlStringGenerator.MSSQL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class DataDeleter
    {
        static public int DeleteSpecifications(string productId, string categoryId)
        {
            return MSSQL_Statements
                .DELETE_FROM[categoryId + "_specifications"].WHERE("product_id = '" + productId + "'")
                .DISCONNECTED_EXECUTE(DAL.SccPublicConnection.Conn).UPDATE();
        }

        static public int DeleteProduct(string productId)
        {
            return MSSQL_Statements
                .DELETE_FROM["product"]
                .WHERE("product_id = '" + productId + "'")
                .DISCONNECTED_EXECUTE(DAL.SccPublicConnection.Conn).UPDATE();
        }
    }
}
