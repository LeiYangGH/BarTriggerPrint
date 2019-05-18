using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarTriggerPrint.Model
{
    public class SimpleConverter : FieldsValueConverter
    {
        public SimpleConverter() : base("MMdd", 4)
        {
        }
    }
}
