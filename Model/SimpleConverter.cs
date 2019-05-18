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
        public No460Converter() : base("yyMM", 7)
        {

        }
    }

}
