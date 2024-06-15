using SqlStringGenerator.MSSQL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class ProductTable : SccTable
    {
        public readonly MSSQL_Column Id = new MSSQL_Column("product_id", "product");
        public ProductTable() : base("product") { }

        public int Update(DTO.Product pro)
        {
            return MSSQL_Statements
                .UPDATE["product"]
                .SET[string.Format("product_name = N'{0}', category_id = '{1}', manufacturer_id = '{2}', unit_price = {3}, stock = {4}, product_description = N'{5}', picture_path = '{6}'", 
                    pro.Name, pro.CategoryId, pro.ManufacturerId, pro.UnitPrice, pro.Stock, pro.Description, pro.Picture)]
                .WHERE(Id.Eq(pro.Id))
                .DISCONNECTED_EXECUTE(SccConnection.Conn).UPDATE();
        }

        public int Insert(DTO.Product pro)
        {
            return MSSQL_Statements
                .INSERT_INTO["product"].VALUES(pro.Id, pro.Name, pro.CategoryId, pro.ManufacturerId, pro.UnitPrice, pro.Stock, pro.Description, pro.Picture)
                .DISCONNECTED_EXECUTE(SccConnection.Conn).UPDATE();
        }
    }

    
}
