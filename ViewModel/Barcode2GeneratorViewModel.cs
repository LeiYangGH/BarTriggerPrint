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
            this.Name = Constants.ProductName2;
            this.BarProper = new BarProper2();

        }
        public override string GenerateBarcode()
        {
            var p = this.BarProper as BarProper2;
            this.CurrentBarcode = $"{p.ProductDate.ToString("yyyyMMdd")}_{p.StartNumber}";
            return this.CurrentBarcode;
        }
    }
}
