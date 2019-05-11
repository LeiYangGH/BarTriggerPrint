using BarTriggerPrint.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarTriggerPrint.ViewModel
{
    public class Barcode2GeneratorViewModel : BarcodeGeneratorViewModel
    {

        public Barcode2GeneratorViewModel()
        {
            this.Name = "产品2";
            this.BarProper = new BarProper2();

        }
    }
}
