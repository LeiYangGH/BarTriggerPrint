using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarTriggerPrint.Model
{
    public class No386Converter : FieldsValueConverter
    {
        public No386Converter() : base("", 5)
        {
        }

        public override string ConvertDate(DateTime dt)
        {
            string ys = this.GetYearCharString(dt.Year);
            string ms = this.GetMonthCharString(dt.Month);
            string ds = this.GetDayCharString(dt.Day);
            string re = ys + ms + ds;
            return re;
        }

        private static Dictionary<int, string> yearDict = new Dictionary<int, string>()
        {
            { 2017,"H" },
            { 2018,"J" },
            { 2019,"K" },
            { 2020,"L" },
            { 2021,"M" },
            { 2022,"N" },
            { 2023,"P" },
            { 2024,"R" },
            { 2025,"S" },
            { 2026,"T" },
            { 2027,"V" },
            { 2028,"W" },
        };
        public string GetYearCharString(int year)
        {
            if (yearDict.ContainsKey(year))
            {
                return yearDict[year];
            }
            else
                return "BADYEAR";
        }

        public string GetMonthCharString(int m)
        {
            if (m <= 9)
                return m.ToString();
            else if (m == 10)
            {
                return "0";
            }
            else if (m >= 10 && m <= 12)
            {
                return ((char)(m - 11 + 65)).ToString();
            }
            else
                return "BADMONTH";
        }


        public string GetDayCharString(int d)
        {
            if (d >= 1 && d <= 31)
            {
                return d.ToString().PadLeft(2, '0');
            }
            else
                return "BADDAY";
        }
    }
}
