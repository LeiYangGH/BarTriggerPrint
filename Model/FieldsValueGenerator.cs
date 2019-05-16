using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarTriggerPrint.Model
{
    public abstract class FieldsValueGenerator
    {
        protected string dateFormatString = "yyMMdd";
        protected int sNLength = 4;
        protected string componentType;
        public FieldsValueGenerator(string componentType)
        {
            this.componentType = componentType;
        }

        public string DirName { get; protected set; }
        public string GetFormatedDateString(DateTime dt)
        {
            return dt.ToString(this.dateFormatString);
        }
        public string GetFormatedSNString(int num)
        {
            int toMod = (int)Math.Floor(Math.Pow(10, this.sNLength));
            return (num % toMod).ToString().PadLeft(this.sNLength, '0');
        }
    }
}
