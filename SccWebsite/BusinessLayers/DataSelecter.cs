using SqlStringGenerator.MSSQL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class DataSelecter
    {
        static public DataTable GetAllProduct()
        {
            return MSSQL_Statements
                .SELECT["*"].FROM["product, category, manufacturer"]
                .WHERE("product.category_id = category.category_id AND product.manufacturer_id = manufacturer.manufacturer_id")
                .DISCONNECTED_QUERY(DAL.SccPublicConnection.Conn);
        }

        static public DataRow GetProduct(string productId)
        {
            return MSSQL_Statements
                .SELECT["*"].FROM["product, category, manufacturer"]
                .WHERE("product.category_id = category.category_id AND product.manufacturer_id = manufacturer.manufacturer_id AND product_id = '" + productId + "'")
                .DISCONNECTED_QUERY(DAL.SccPublicConnection.Conn).Rows[0];
        }

        static public DataTable GetProductsByCategory(string categoryId)
        {
            return MSSQL_Statements
                .SELECT["*"].FROM["product", "category"]
                .WHERE("product.category_id = category.category_id AND category.category_id = '" + categoryId + "'")
                .DISCONNECTED_QUERY(DAL.SccPublicConnection.Conn);
        }

        static public DataTable GetProductsByName(string productName)
        {
            return MSSQL_Statements
                .SELECT["*"].FROM["product"]
                .WHERE("product_name LIKE N'%" + productName + "%'")
                .DISCONNECTED_QUERY(DAL.SccPublicConnection.Conn);
        }

        static public DataRow GetProductSpectifications(string productId, string category_id)
        {
            DataTable result = MSSQL_Statements
                .SELECT["*"].FROM[category_id + "_specifications"]
                .WHERE("product_id = '" + productId + "'")
                .DISCONNECTED_QUERY(DAL.SccPublicConnection.Conn);

            return result.Rows.Count > 0 ? result.Rows[0] : null;
        }

        static public DataTable GetAllCategory() 
        {
            DAL.CategoryTable Category = DAL.SccTables.Category;

            return Category.SelectNonConditions("*");
        }

        static public DataTable GetAllManufacturer()
        {
            DAL.ManufacturerTable Manufacturer = DAL.SccTables.Manufacturer;

            return Manufacturer.SelectNonConditions("*");   
        }
    }
}
