using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SqlStringGenerator.MSSQL
{
    public class Selectable
    {
        protected internal string _sqlStr;

        public string SqlStr
        {
            get
            {
                return _sqlStr;
            }
        }

        public Selectable(string str) 
        { 
            _sqlStr = str;
        }
        
        public string Eq(object Value)
        {
            switch (Type.GetTypeCode(Value.GetType()))
            {
                case TypeCode.Byte:
                case TypeCode.SByte:
                case TypeCode.UInt16:
                case TypeCode.UInt32:
                case TypeCode.UInt64:
                case TypeCode.Int16:
                case TypeCode.Int32:
                case TypeCode.Int64:
                case TypeCode.Decimal:
                case TypeCode.Double:
                case TypeCode.Single:
                    return _sqlStr + "=" + Value.ToString() + " ";

                case TypeCode.Boolean:
                    if ((bool)Value)
                    {
                        return _sqlStr + "=1 ";
                    }
                    return _sqlStr + "=0 ";

                case TypeCode.String:
                    Regex Reg = new Regex(@"[^\u0000-\u007F]+");

                    if (Reg.IsMatch(Value.ToString()))
                    {
                        return _sqlStr + "=N'" + Value.ToString() + "' ";
                    }

                    return _sqlStr + "='" + Value.ToString() + "' ";

                case TypeCode.DateTime:
                    return _sqlStr + "='" + ((DateTime)Value).ToString("yyyy-MM-dd") + "' ";

                default:
                    return "<error clause>";
            }
        }

        public string NotEq(object Value)
        {
            switch (Type.GetTypeCode(Value.GetType()))
            {
                case TypeCode.Byte:
                case TypeCode.SByte:
                case TypeCode.UInt16:
                case TypeCode.UInt32:
                case TypeCode.UInt64:
                case TypeCode.Int16:
                case TypeCode.Int32:
                case TypeCode.Int64:
                case TypeCode.Decimal:
                case TypeCode.Double:
                case TypeCode.Single:
                    return _sqlStr + "<>" + Value.ToString() + " ";

                case TypeCode.Boolean:
                    if ((bool)Value)
                    {
                        return _sqlStr + "<>1 ";
                    }
                    return _sqlStr + "<>0 ";

                case TypeCode.String:
                    Regex Reg = new Regex(@"[^\u0000-\u007F]+");

                    if (Reg.IsMatch(Value.ToString()))
                    {
                        return _sqlStr + "<>N'" + Value.ToString() + "' ";
                    }

                    return _sqlStr + "<>'" + Value.ToString() + "' ";

                case TypeCode.DateTime:
                    return _sqlStr + "<>'" + ((DateTime)Value).ToString("yyyy-MM-dd") + "' ";

                default:
                    return "<error clause>";
            }
        }
    }
}
