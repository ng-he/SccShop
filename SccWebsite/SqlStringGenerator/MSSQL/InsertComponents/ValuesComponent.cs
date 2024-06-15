using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SqlStringGenerator.MSSQL.InsertComponents
{
    public class ValuesComponent : ExecutableDML 
    {
        internal ValuesComponent(StringBuilder EarlierDML_String, params object[] Values) : base(EarlierDML_String) 
        {
            ExecutableDML_String.Append(@"VALUES(");

            foreach (object Value in Values) 
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
                        ExecutableDML_String.Append(Value.ToString() + ",");
                        break;

                    case TypeCode.Boolean:
                        if ((bool)Value)
                        {
                            ExecutableDML_String.Append("1,");
                            break;
                        }
                        ExecutableDML_String.Append("0,");
                        break;

                    case TypeCode.String:
                        Regex Reg = new Regex(@"[^\u0000-\u007F]+");

                        if (Reg.IsMatch(Value.ToString()))
                        {
                            ExecutableDML_String.Append("N'" + Value.ToString() + "',");
                            break;
                        }

                        ExecutableDML_String.Append("'" + Value.ToString() + "',");
                        break;

                    case TypeCode.DateTime:
                        ExecutableDML_String.Append("'" + ((DateTime)Value).ToString("yyyy-MM-dd") + "',");
                        break;
                }
            }

            ExecutableDML_String[ExecutableDML_String.Length - 1] = ')';
        }

        internal ValuesComponent(StringBuilder EarlierDML_String, string valuesStr, bool useStr) : base(EarlierDML_String)
        {
            ExecutableDML_String.Append(@"VALUES(" + valuesStr + @")");
        }

        public ValuesComponent VALUES(params object[] Values)
        {
            return new ValuesComponent(ExecutableDML_String, Values);
        }
    }
}
