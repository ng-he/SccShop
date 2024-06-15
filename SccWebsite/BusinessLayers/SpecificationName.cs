using DAL;
using SqlStringGenerator.MSSQL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class SpecificationName
    {
        static private Dictionary<string, List<string>> CatSpec = new Dictionary<string, List<string>>();

        static SpecificationName()
        {
            DataTable categories = DataSelecter.GetAllCategory();

            foreach (DataRow row in categories.Rows) 
            {
                string category = row.ItemArray[0].ToString();
                List<string> spec_lst = new List<string>();

                DataTable spec_tbl = MSSQL_Statements
                    .SELECT["*"].FROM[category + "_spec_name" + " ORDER BY spec_column_id"].DISCONNECTED_QUERY(SccPublicConnection.Conn);
                

                foreach(DataRow spec in spec_tbl.Rows)
                {
                    spec_lst.Add(spec.ItemArray[1].ToString());  
                }

                CatSpec.Add(category, spec_lst);
            }
        }

        static public List<string> Of(string category)
        {
            return CatSpec[category];
        }
    }
}
