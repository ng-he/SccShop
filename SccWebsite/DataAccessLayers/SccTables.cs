using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class SccTables
    {
        static public AccountTable Account = new AccountTable();
        static public PersonalInfoTable PersonalInfo = new PersonalInfoTable(); 
        static public ProductTable Product = new ProductTable();
        static public CategoryTable Category = new CategoryTable(); 
        static public ManufacturerTable Manufacturer = new ManufacturerTable();
    }
}
