using SqlStringGenerator.MSSQL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class DataAdder
    {
        static public int AddNew(DTO.Account Acc)
        {
            return DAL.SccTables.Account.Insert(Acc);
        }

        static public int AddNew(DTO.PersonalInfo Info)
        {
            return DAL.SccTables.PersonalInfo.Insert(Info);
        }

        static public int AddNew(DTO.Product product)
        {
            return DAL.SccTables.Product.Insert(product);
        }

        static public int AddSpecifications(string productId, string categoryId, string[] specs)
        {
            StringBuilder valuesStr = new StringBuilder("'" + productId + "',");

            for (int i = 0; i < specs.Length; i++)
            {
                valuesStr.Append((int.TryParse(specs[i], out _) || float.TryParse(specs[i], out _) ? specs[i] : ("'" + specs[i] + "'")) + ",");
            }

            valuesStr[valuesStr.Length - 1] = ' ';

            return MSSQL_Statements
                .INSERT_INTO[categoryId + "_specifications"].VALUES(valuesStr.ToString(), true)
                .DISCONNECTED_EXECUTE(DAL.SccPublicConnection.Conn).UPDATE();
        }
    }
}
