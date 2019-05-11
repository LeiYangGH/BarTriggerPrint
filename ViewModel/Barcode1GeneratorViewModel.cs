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

        public override string GenerateBarcode()
        {
            var p = this.BarProper as BarProper1;
            this.CurrentBarcode = $"{p.Catetory2}_{p.Shift}_{p.ProductDate}_{p.StartNumber}";
            return this.CurrentBarcode;
        }
    }
}
