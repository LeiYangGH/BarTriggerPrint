using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarTriggerPrint.Model
{
    public class No066Converter : FieldsValueConverter
    {
        public No066Converter() : base("NF前")
        {
            this.sNLength = 3;
        }

        protected override string ConvertDate(DateTime dt)
        {
            string ys = this.GetYearCharString(dt.Year);
            string ms = this.GetMonthCharString(dt.Month);
            string ds = this.GetDayCharString(dt.Day);
            string re = ys + ms + ds;
            return re;
        }

        public string GetYearCharString(int year)
        {
            if (year <= 2019)
                return (year - 2010).ToString();
            else if (year >= 2020 && year <= 2027)
            {
                return ((char)(year - 2020 + 65)).ToString();
            }
            else
                return "BADYEAR";
        }

        public string GetMonthCharString(int m)
        {
            if (m <= 9)
                return m.ToString();
            else if (m >= 10 && m <= 12)
            {
                return ((char)(m - 10 + 65)).ToString();
            }
            else
                return "BADMONTH";
        }


        public string GetDayCharString(int m)
        {
            if (m <= 9)
                return m.ToString();
            else if (m == 10)
            {
                return "0";
            }
            else if (m >= 11 && m <= 31)
            {
                return ((char)(m - 11 + 65)).ToString();
            }
            else
                return "BADDAY";
        }
    }
}
