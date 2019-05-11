using BarTriggerPrint.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarTriggerPrint.ViewModel
{
    public class Barcode1GeneratorViewModel : BarcodeGeneratorViewModel
    {
        public Barcode1GeneratorViewModel()
        {
            this.Name = "产品1";
            this.BarProper = new BarProper1();
        }
    }
}
