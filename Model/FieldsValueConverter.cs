using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarTriggerPrint.Model
{
    public abstract class FieldsValueConverter
    {
        protected string dateFormatString = "yyMMdd";

        public int sNLength { get; protected set; }
        public FieldsValueConverter(string dateFormatString, int sNLength)
        {
            this.dateFormatString = dateFormatString;
            this.sNLength = sNLength;
        }

        public virtual string ConvertDate(DateTime dt)
        {
            return dt.ToString(this.dateFormatString);
        }

        public virtual string ConvertSn(int num)
        {
            int toMod = (int)Math.Floor(Math.Pow(10, this.sNLength));
            return (num % toMod).ToString().PadLeft(this.sNLength, '0');
        }


    }
}
