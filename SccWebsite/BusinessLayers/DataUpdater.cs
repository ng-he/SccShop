using SqlStringGenerator.MSSQL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class DataUpdater
    {
        static public int Update(DTO.Product product)
        {
            return DAL.SccTables.Product.Update(product);
        }

        static public int UpdateSpecifications(string productId, string categoryId, string[] specs)
        {
            StringBuilder expr = new StringBuilder("");

            for(int i = 0; i < specs.Length; i++)
            {
                expr.Append(string.Format("spec_{0} = {1},", 
                    (i + 1).ToString(), int.TryParse(specs[i], out _) || float.TryParse(specs[i], out _) ? specs[i] : "'" + specs[i] + "'"));
            }

            expr[expr.Length - 1] = ' ';

            return MSSQL_Statements
                .UPDATE[categoryId + "_specifications"].SET[expr.ToString()]
                .WHERE("product_id = '" + productId + "'")
                .DISCONNECTED_EXECUTE(DAL.SccPublicConnection.Conn).UPDATE();
        }
    }
}
