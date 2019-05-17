using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarTriggerPrint.Model
{
    public class No066Generator : FieldsValueGenerator
    {
        public No066Generator() : base("NF前")
        {
        }

        private string GetYearCharString(int year)
        {
            if (year <= 2019)
                return (year - 2010).ToString();
            else if (year >= 2020 && year <= 2027)
            {
                return ((char)(year - 2020 + 64)).ToString();
            }
            else
                return "BADYEAR";
        }

        private string GetMonthCharString(int m)
        {
            if (m <= 9)
                return m.ToString();
            else if (m >= 10 && m <= 12)
            {
                return ((char)(m - 10 + 64)).ToString();
            }
            else
                return "BADMONTH";
        }


        private string GetDayCharString(int m)
        {
            if (m <= 9)
                return m.ToString();
            else if (m == 10)
            {
                return "0";
            }
            else if (m >= 11 && m <= 31)
            {
                return ((char)(m - 11 + 64)).ToString();
            }
            else
                return "BADDAY";
        }
    }
}
