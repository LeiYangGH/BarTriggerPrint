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

        public virtual string ConvertToValue<T>(T input) where T : struct
        {
            //if (typeof(T) == typeof(DateTime))
            if (input is DateTime)
            {
                DateTime dt = (DateTime)Convert.ChangeType(input, typeof(DateTime));
                return this.ConvertDate(dt);
            }
            else if (input is int)
            {
                int dt = (int)Convert.ChangeType(input, typeof(int));
                return this.ConvertSn(dt);
            }
            else
                return "WRONGTYPE";
        }


        protected virtual string ConvertDate(DateTime dt)
        {
            return dt.ToString(this.dateFormatString);
        }

        protected virtual string ConvertSn(int num)
        {
            int toMod = (int)Math.Floor(Math.Pow(10, this.sNLength));
            return (num % toMod).ToString().PadLeft(this.sNLength, '0');
        }


    }
}
