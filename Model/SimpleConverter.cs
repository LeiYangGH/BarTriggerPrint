using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarTriggerPrint.Model
{
    public class SimpleConverter : FieldsValueConverter
    {
        public SimpleConverter(string s, int i) : base(s, i)
        {
        }
    }

    public class No340Converter : FieldsValueConverter
    {
        public No340Converter() : base("dd-MM-yy", 7)
        {

        }
    }

    public class No460Converter : FieldsValueConverter
    {
        //yy/MM?
        public No460Converter() : base("yyMM", 7)
        {

        }
    }

    public class No463Converter : FieldsValueConverter
    {
        public No463Converter() : base("yyMMdd", 4)
        {

        }
    }

    public class No465Converter : FieldsValueConverter
    {
        public No465Converter() : base("yy/MM/dd", 4)
        {

        }
    }


    public class No466Converter : FieldsValueConverter
    {
        public No466Converter() : base("yyyyMMdd", 5)
        {

        }
    }
}
